/*
 * 由SharpDevelop创建。
 * 用户： cheng
 * 日期: 2020/7/6
 * 时间: 15:37
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace MyComputerTools.DoWork.dataInfo.Json
{

	/// <summary>
	/// Description of RetJson.
	/// </summary>
	public class RetJson
	{
		private string retCode;
		
		private string retMsg;
		
		private retData retData;
		
		public RetJson()
		{
		}
		/// <summary>
		/// 返回代码，0成功，1失败
		/// </summary>
		public string RetCode {
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

		public retData RetData {
			get {
				return retData;
			}
			set {
				retData = value;
			}
		}
	}
	public class retData{
		private string username;
		private string tokenvalue;
		private string cmd;
		private string cmd_id;
		public string Username {
			get {
				return username;
			}
			set {
				username = value;
			}
		}

		public string Tokenvalue {
			get {
				return tokenvalue;
			}
			set {
				tokenvalue = value;
			}
		}

		public string Cmd {
			get {
				return cmd;
			}
			set {
				cmd = value;
			}
		}

		public string Cmd_id {
			get {
				return cmd_id;
			}
			set {
				cmd_id = value;
			}
		}
	}
}
