/*
 * Created by SharpDevelop.
 * User: cheng
 * Date: 2020/6/16
 * Time: 10:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using MyComputerTools.DoWork.dataInfo.Json;
using MyComputerTools.DoWork.image;
using MyComputerTools.DoWork.remote;
using MyComputerTools.publicUtils;

namespace MyComputerTools.DoWork
{
	/// <summary>
	/// Description of DoCmd.
	/// </summary>
	public class DoCmd
	{
		public DoCmd()
		{
			
		}
		
		public void doSomething(String cmd,RetJson retJson){
			    LogHelper.WriteLog("doSomething："+cmd);
				//重启指令
				if("RESTART".Equals(cmd)){
					 //Process.Start("shutdown.exe", "-r");
					 // By Default the Restart will take place after 30 Seconds
					 //if you want to change the Delay try this one
					 restartComputer();
				}else if("RESTART_EXPLORER".Equals(cmd)){
					restartExplorer();
				}else if("GET_PICTURE".Equals(cmd)){
					//获取截图
					//ImageComp.Instance.
					getPicture(retJson);
				}else if("GET_STACKS".Equals(cmd)){
					//获取堆栈信息
				}else if("GET_ALL_THREAD".Equals(cmd)){
					//获取所有线程信息
				}else if("RESTART_TEAMVIEWER".Equals(cmd)){
					//重启TV
					restartTeamViewer();
				}
		}
		
		public void getPicture(RetJson retjson){
			
			ImageComp inst=ImageComp.Instance;
			string str=inst.saveScrFile();
			LoginWork loginwork=LoginWork.Instance;
			
			loginwork.doSendPic(str);
			
		}
		
		/// <summary>
		/// 重启TEAMVIEWER
		/// </summary>
		public void restartTeamViewer(){
			Process[] processAlls=Process.GetProcessesByName("TeamViewer");
			foreach (var process in processAlls) {
				Debug.WriteLine(process.ProcessName);
				process.Kill();
				//Debug.WriteLine(process.MainModule.FileName);
			}
			//Process.Start("","");
		
		}
		/// <summary>
		/// 重启Explorer
		/// </summary>
		public void restartExplorer(){
			Process[] processAlls=Process.GetProcessesByName("explorer");
			if(processAlls.Length>0){
				Debug.WriteLine(processAlls[0].ProcessName);
				//processAlls[0].Close();
				processAlls[0].Kill();
				//processAlls[0].Start();
			}
		}
		/// <summary>
		/// 重启计算机
		/// </summary>
		public void restartComputer(){
			Process.Start("shutdown.exe","-r -t 10");
		}
	}
}
