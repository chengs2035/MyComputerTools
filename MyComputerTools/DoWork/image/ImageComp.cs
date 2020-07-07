/*
 * Created by SharpDevelop.
 * User: cheng
 * Date: 2020/6/17
 * Time: 10:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace MyComputerTools.DoWork.image
{
	/// <summary>
	/// Description of ImageComp.
	/// </summary>
	public class ImageComp
	{

		private static readonly object padlock = new object();
		private static ImageComp instance = null;
		private ImageComp()
		{
			
		}
		public static ImageComp Instance {
			get {
				lock (padlock) {
					if (instance == null) {
						instance = new ImageComp();
					}
					return instance;
				}
			}
		}
		/**
		 * 
		 * 
		 * 获取屏幕截图
		 * 		 
		 */
		public string saveScrFile()
		{
			string UserPhoto ="";
			Bitmap myImage = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

			Graphics g = Graphics.FromImage(myImage);

			g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height));

			IntPtr dc1 = g.GetHdc();

			g.ReleaseHdc(dc1);
			
			//myImage.Save(@"D:\screen0.jpg",System.Drawing.Imaging.ImageFormat.Jpeg);
			
			using (MemoryStream ms1 = new MemoryStream()){
				
				myImage.Save(ms1,System.Drawing.Imaging.ImageFormat.Jpeg);
				byte[] arr1 = new byte[ms1.Length];
				ms1.Position = 0;
                ms1.Read(arr1, 0, (int)ms1.Length);
                ms1.Close();
                UserPhoto = Convert.ToBase64String(arr1);
			}
			return UserPhoto;
		}
		public string saveScrFile111(){
			
			Bitmap myImage = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

			Graphics g = Graphics.FromImage(myImage);

			g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height));

			IntPtr dc1 = g.GetHdc();

			g.ReleaseHdc(dc1);
			
			
			BinaryFormatter binFormatter = new BinaryFormatter();
	      	MemoryStream memStream = new MemoryStream();
	     	binFormatter.Serialize(memStream, myImage);
	      	byte[] bytes = memStream.GetBuffer();
	      	string base64 = Convert.ToBase64String(bytes);
	      	return base64;
		}
	}
}
