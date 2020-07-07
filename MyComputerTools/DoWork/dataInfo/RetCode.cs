/*
 * Created by SharpDevelop.
 * User: cheng
 * Date: 2020/7/6
 * Time: 12:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace MyComputerTools.DoWork.dataInfo
{
	/// <summary>
	/// Description of RetCode.
	/// </summary>
	public enum  RetCode
	{
		/// <summary>
		/// 登录成功
		/// </summary>
		LOGINSUCCESS=0,
		/// <summary>
		/// 重新登录
		/// </summary>
		RELOGIN=1,
		/// <summary>
		/// 心跳包发送成功
		/// </summary>
		SENDHEARTSEET,
		/// <summary>
		/// 获取命令成功
		/// </summary>
		GETCMDSUCCESS
	}
}
