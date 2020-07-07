/*
 * Created by SharpDevelop.
 * User: cheng
 * Date: 2020/6/11
 * Time: 11:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MyComputerTools.DoWork;
using MyComputerTools.DoWork.dataInfo;
using MyComputerTools.DoWork.remote;
using MyComputerTools.publicUtils;

namespace MyComputerTools
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		

		private RunInfo runInfo=null;
		private DoCmd doCmd=new DoCmd();
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			//服务器自动连接
			connServer();
			//应用运行时间
			timer1.Start();
			//心跳包监控
			timer2.Start();
			//从服务器获取命令
			timergetCommandList.Start();
			
		}
		
		private int heathb=10;
		private bool iscommandrun=false;
		/**
		 心跳包发送
		 **/
		void Timer2Tick(object sender, EventArgs e)
		{
			try{
				if(!runInfo.Islogin){
					lblMyLifeHave.Text="服务器未登录，不进行心跳包的发送，请重启程序";
					return;
				}
				//10秒一次。登录状态才能发送
				if(heathb==0 && runInfo.Islogin){
					LogHelper.WriteLog("发送心跳包");
					//发送心跳，并且重置为10
					sendheartbeat();
					heathb=10;
				}else{
					heathb--;
				}
				//设置倒计时
				lblMyLifeHave.Text="剩余："+heathb+"秒";
				
			}catch(Exception ex){
				LogHelper.WriteLog("心跳包发送出错！",ex);
			}
		}
		/**
		 * 发送心跳包，告诉服务器，我活着哩！
		 * */
		void sendheartbeat(){
			LoginWork loginWork =LoginWork.Instance;
			runInfo=loginWork.doSendHeartBeat();
			if(runInfo.RetCode==RetCode.RELOGIN){
				connServer();
			}
		}
		/*
		 * 连接服务器，获取tokenValue；(登录)
		 */
		void connServer(){
			LoginWork loginWork =LoginWork.Instance;
			runInfo=loginWork.doLogin();
			if(runInfo.Islogin){
				lblNowServerConnection.Text="服务器已登录，正常获取到token";
			}
		}
		/**
		 * 应用运行时间
		 * 
		 * 
		 * */
		void Timer1Tick(object sender, EventArgs e)
		{
			lblProRunTime.Text=publicUtils.publicUtils.getRunTime(serverRunTimeCount++);
		}
		/**
		 * 程序运行的时间
		 * */
		public int serverRunTimeCount=0;
		/// <summary>
		///  获取指令
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void TimergetCommandListTick(object sender, EventArgs e)
		{
			try{
				if(iscommandrun)return;
				if(!runInfo.Islogin)return;
				
				LoginWork loginWork =LoginWork.Instance;
				runInfo = loginWork.doGetCmd();
				if(runInfo.RetCode==RetCode.GETCMDSUCCESS){
					if(string.IsNullOrEmpty(runInfo.RetMsg)){
						iscommandrun=false;
					}else{
						iscommandrun=true;
						if(!string.IsNullOrEmpty(runInfo.RetJson.RetData.Cmd)){
							doCmd.doSomething(runInfo.RetJson.RetData.Cmd,runInfo.RetJson);
						}
						
					}
				}
				iscommandrun=false;
			}
			catch(Exception ex){
				LogHelper.WriteLog("获取指令出现错误",ex);
			}
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			LogHelper.WriteLog("系统启动");
		}

	}
}
