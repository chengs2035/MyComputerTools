/*
 * Created by SharpDevelop.
 * User: cheng
 * Date: 2020/7/6
 * Time: 10:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Text;
using System.Web;
using MyComputerTools.DoWork.dataInfo;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using MyComputerTools.DoWork.dataInfo.Json;
using MyComputerTools.publicUtils;
using Newtonsoft.Json;
namespace MyComputerTools.DoWork.remote
{
	/// <summary>
	/// Description of LoginWork.
	/// </summary>
	public class LoginWork
	{
		private static RunInfo runinfo=null;


		public static LoginWork Instance{
			get{
				lock (padlock) {
					if (instance == null) {
						instance=new LoginWork();
					}
					return instance;
				}
			}
		}
		/// <summary>
		/// 获取图片队列id，一会上传图片有用
		/// </summary>
		/// <returns></returns>
		public RetJson doGetPicList(){
			try{
				Dictionary<String, String> reqparams = new Dictionary<String, String>();
				reqparams.Add("FUNCTION","GET_PIC_ID");
				reqparams.Add("key01",runinfo.Key01);
				reqparams.Add("username",runinfo.Username);
				reqparams.Add("tokenvalue",runinfo.TokenValue);
				string rec=publicUtils.publicUtils.PostUrl(runinfo.Url,reqparams);
				RetJson rj=JsonConvert.DeserializeObject<RetJson>(rec);
				return rj;
			}
			catch(Exception ex){
				LogHelper.WriteLog("获取图片队列id失败",ex);
			}
			return null;
		}
		/// <summary>
		/// 发送图片到服务器
		/// </summary>
		/// <param name="base64"></param>
		/// <returns></returns>
		public RunInfo doSendPic(string base64){
			RetJson rj=doGetPicList();
			
			if(rj==null || rj.RetData.Cmd_id=="" || rj.RetData.Cmd_id=="0"){
				return null;
			}
			
			Dictionary<String, String> reqparams = new Dictionary<String, String>();
			reqparams.Add("FUNCTION","SAVE_PIC");
			reqparams.Add("key01",runinfo.Key01);
			reqparams.Add("username",runinfo.Username);
			reqparams.Add("tokenvalue",runinfo.TokenValue);
			reqparams.Add("CMD_ID",rj.RetData.Cmd_id);
			reqparams.Add("PIC_BASE64",HttpUtility.UrlEncode(base64));
			

			string rec=publicUtils.publicUtils.PostUrl(runinfo.Url,reqparams);
			
			return null;
			
		}
		/// <summary>
		/// 心跳包发送
		/// </summary>
		/// <returns></returns>
		public RunInfo doSendHeartBeat(){
			try{
				Dictionary<String, String> reqparams = new Dictionary<String, String>();
				reqparams.Add("FUNCTION","IMALIVE");
				reqparams.Add("key01",runinfo.Key01);
				reqparams.Add("username",runinfo.Username);
				reqparams.Add("tokenvalue",runinfo.TokenValue);
				string rec=publicUtils.publicUtils.PostUrl(runinfo.Url,reqparams);
				
				RetJson rj=JsonConvert.DeserializeObject<RetJson>(rec);
				if(rj.RetCode=="-1"){
					//登录失败，需要重新登录
					runinfo.Islogin=false;
					runinfo.RetCode=RetCode.RELOGIN;
				}else if(rj.RetMsg=="IMALIVE"){
					//登录成功，并且心跳发送成功
					runinfo.Islogin=true;
					runinfo.RetCode=RetCode.LOGINSUCCESS;
				}else{
					//心跳包发送后没有登录状态回来，则为登录失败，需要重新登录
					runinfo.Islogin=false;
					runinfo.RetCode=RetCode.RELOGIN;
				}
		
				
			}
			catch(Exception ex){
				LogHelper.WriteLog("心跳包发送失败",ex);
			}
			return runinfo;
			
		}
		/// <summary>
		/// 登录
		/// </summary>
		/// <returns>统一运行信息</returns>
		public RunInfo doLogin(){
			try {
				string tokenKey = runinfo.Username + runinfo.Pwd;
				byte[] result = Encoding.Default.GetBytes(tokenKey);    //tbPass为输入密码的文本框
				MD5 md5 = new MD5CryptoServiceProvider();
				byte[] output = md5.ComputeHash(result);
				tokenKey = BitConverter.ToString(output).Replace("-", "");
				tokenKey = tokenKey.ToLower();
				
				Dictionary<String, String> reqparams = new Dictionary<String, String>();
				reqparams.Add("FUNCTION", "LOGIN");
				reqparams.Add("key01", runinfo.Key01);
				reqparams.Add("username", runinfo.Username);
				reqparams.Add("tokenKey", tokenKey);
				
				runinfo.TokenValue = publicUtils.publicUtils.PostUrl(runinfo.Url, reqparams);
				
				RetJson rj = JsonConvert.DeserializeObject<RetJson>(runinfo.TokenValue);
				
				if (rj.RetCode == "0") {
					runinfo.TokenValue = rj.RetData.Tokenvalue;
					runinfo.Islogin = true;
					return runinfo;
				}
				
			}
			catch(Exception ex){
				LogHelper.WriteLog("登录失败",ex);
			}
			runinfo.Islogin = false;
			return new RunInfo();
		}
		/// <summary>
		/// 获取命令
		/// </summary>
		/// <returns></returns>
		public RunInfo doGetCmd(){
			try{
				Dictionary<String, String> reqparams = new Dictionary<String, String>();
				reqparams.Add("FUNCTION","CMD");
				reqparams.Add("key01",runinfo.Key01);
				reqparams.Add("username",runinfo.Username);
				reqparams.Add("tokenvalue",runinfo.TokenValue);
				string rec=publicUtils.publicUtils.PostUrl(runinfo.Url,reqparams);
				
				RetJson rj=JsonConvert.DeserializeObject<RetJson>(rec);
				runinfo.RetJson=rj;
				if(rj.RetMsg=="OUTTIME"){
					//登录失败，需要重新登录
					runinfo.Islogin=false;
					runinfo.RetCode=RetCode.RELOGIN;
				}else{
					runinfo.Islogin=true;
					runinfo.RetCode=RetCode.GETCMDSUCCESS;
					runinfo.RetMsg=rec;
				}
			}
			catch(Exception ex){
				LogHelper.WriteLog("获取命令失败",ex);
			}
			return runinfo;
		}
		
		/// <summary>
		/// 构造函数
		/// </summary>
		private LoginWork(){
			//临时这样写，后续改到配置文件中
			runinfo =new RunInfo();
			runinfo.Url="";
			runinfo.Username="";
			runinfo.Pwd="";
			runinfo.Key01="";
		}

		private static readonly object padlock = new object();
		private static LoginWork instance=null;
	}
}
