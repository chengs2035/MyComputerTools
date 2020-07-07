/*
 * 由SharpDevelop创建。
 * 用户： cheng
 * 日期: 2020/6/11
 * 时间: 12:49
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MyComputerTools.publicUtils
{
	/// <summary>
	/// Description of public.
	/// </summary>
	public class publicUtils
	{
		public publicUtils()
		{
		}
		public const int oneDaySec = 86400;
//一天的秒数
		
		public static string getRunTime(int runtimeCount)
		{
			TimeSpan ts = new TimeSpan(0, 0, runtimeCount);
			return ts.Days + "天" + ts.Hours + "小时" + ts.Minutes + "分钟" + ts.Seconds + "秒";
		}
		
		public  static string PostUrl(string url, string postData,string str)
		{
			HttpWebRequest request = null;
			if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase)) {
				request = WebRequest.Create(url) as HttpWebRequest;
				ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
				request.ProtocolVersion = HttpVersion.Version11;
　　　　　　　　　// 这里设置了协议类型。
				ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;// SecurityProtocolType.Tls1.2; 
				request.KeepAlive = false;
				ServicePointManager.CheckCertificateRevocationList = true;
				ServicePointManager.DefaultConnectionLimit = 100;
				ServicePointManager.Expect100Continue = false;
                
			} else {
				request = (HttpWebRequest)WebRequest.Create(url);
			}

			request.Method = "POST";    //使用get方式发送数据
			request.ContentType = "application/x-www-form-urlencoded";
			request.Referer = null;
			request.AllowAutoRedirect = true;
			request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.2; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
			request.Accept = "*/*";

			byte[] data = Encoding.UTF8.GetBytes(postData);
			Stream newStream = request.GetRequestStream();
			newStream.Write(data, 0, data.Length);
			newStream.Close();

			//获取网页响应结果
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			Stream stream = response.GetResponseStream();
			//client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
			string result = string.Empty;
			using (StreamReader sr = new StreamReader(stream)) {
				result = sr.ReadToEnd();
			}

			return result;
		}
		public static string PostUrl(string url,Dictionary<String, String> postData){
			try{
				if(postData==null || postData.Count==0){
					throw new Exception("postData must be not null");
				}
				StringBuilder sb=new StringBuilder();
				sb.Append("version=0.1");
				foreach(var key in postData.Keys){
					string value="";
					if(postData.TryGetValue(key,out value)){
						sb.Append("&");
						sb.Append(key);
						sb.Append("=");
						sb.Append(value);
						
					}
				}
				return PostUrl(url, sb.ToString());
			}catch{
				return "TRY_CATCH";
			}
		}
		public  static string PostUrl(string url, string postData)
		{
			try {
				return PostUrl(url, postData,"");
			// disable once EmptyGeneralCatchClause
			} catch {
				return "TRY_CATCH";
				//ex.StackTrace.
			}
			
		}

		private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
		{
			return true; //总是接受  
		}
		
	}
}
