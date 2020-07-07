/*
 * Created by SharpDevelop.
 * User: cheng
 * Date: 2020/7/6
 * Time: 10:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using MyComputerTools.DoWork.dataInfo.Json;

namespace MyComputerTools.DoWork.dataInfo
{
	/// <summary>
	/// Description of RunInfo.
	/// </summary>
	public class RunInfo
	{
		public RunInfo()
		{
		}
		/// <summary>
		/// 是否登录
		/// </summary>
		private bool islogin=false;
		private string url;
		private string username;
		private string pwd;
		private string key01;
		private string tokenValue;
		
		private RetCode retCode;
		private string retMsg;
		
		private RetJson retJson;
		
		public string Url {
			get {
				return url;
			}
			set {
				url = value;
			}
		}

		public string Username {
			get {
				return username;
			}
			set {
				username = value;
			}
		}

		public string Pwd {
			get {
				return pwd;
			}
			set {
				pwd = value;
			}
		}

		public string Key01 {
			get {
				return key01;
			}
			set {
				key01 = value;
			}
		}

		public string TokenValue {
			get {
				return tokenValue;
			}
			set {
				tokenValue = value;
			}
		}

		public bool Islogin {
			get {
				return islogin;
			}
			set {
				islogin = value;
			}
		}

		public RetCode RetCode {
			get {
				return retCode;
			}
			set {
				retCode = value;
			}
		}

		public string RetMsg {
			get {
				return retMsg;
			}
			set {
				retMsg = value;
			}
		}

		public RetJson RetJson {
			get {
				return retJson;
			}
			set {
				retJson = value;
			}
		}
	}
}
