/*
 * Created by SharpDevelop.
 * User: cheng
 * Date: 2020/6/11
 * Time: 11:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MyComputerTools
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblNowServerConnection;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblMyLifeHave;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lblServerRunTime;
		private System.Windows.Forms.Label lblProRunTime;
		private System.Windows.Forms.Timer timer2;
		private System.Windows.Forms.Timer timergetCommandList;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.lblNowServerConnection = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblMyLifeHave = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.lblServerRunTime = new System.Windows.Forms.Label();
			this.lblProRunTime = new System.Windows.Forms.Label();
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			this.timergetCommandList = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "我的电脑工具";
			this.notifyIcon1.Visible = true;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(5, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(123, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "当前服务器连接：";
			// 
			// lblNowServerConnection
			// 
			this.lblNowServerConnection.Location = new System.Drawing.Point(134, 9);
			this.lblNowServerConnection.Name = "lblNowServerConnection";
			this.lblNowServerConnection.Size = new System.Drawing.Size(368, 23);
			this.lblNowServerConnection.TabIndex = 2;
			this.lblNowServerConnection.Text = "lbl1";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(5, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(123, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "心跳发送倒计时：";
			// 
			// lblMyLifeHave
			// 
			this.lblMyLifeHave.Location = new System.Drawing.Point(134, 32);
			this.lblMyLifeHave.Name = "lblMyLifeHave";
			this.lblMyLifeHave.Size = new System.Drawing.Size(368, 23);
			this.lblMyLifeHave.TabIndex = 4;
			this.lblMyLifeHave.Text = "label3";
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
			// 
			// lblServerRunTime
			// 
			this.lblServerRunTime.Location = new System.Drawing.Point(5, 55);
			this.lblServerRunTime.Name = "lblServerRunTime";
			this.lblServerRunTime.Size = new System.Drawing.Size(123, 23);
			this.lblServerRunTime.TabIndex = 9;
			this.lblServerRunTime.Text = "程序运行时间：";
			// 
			// lblProRunTime
			// 
			this.lblProRunTime.Location = new System.Drawing.Point(134, 55);
			this.lblProRunTime.Name = "lblProRunTime";
			this.lblProRunTime.Size = new System.Drawing.Size(368, 23);
			this.lblProRunTime.TabIndex = 10;
			this.lblProRunTime.Text = "label6";
			// 
			// timer2
			// 
			this.timer2.Interval = 1000;
			this.timer2.Tick += new System.EventHandler(this.Timer2Tick);
			// 
			// timergetCommandList
			// 
			this.timergetCommandList.Interval = 5000;
			this.timergetCommandList.Tick += new System.EventHandler(this.TimergetCommandListTick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(514, 75);
			this.Controls.Add(this.lblProRunTime);
			this.Controls.Add(this.lblServerRunTime);
			this.Controls.Add(this.lblMyLifeHave);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblNowServerConnection);
			this.Controls.Add(this.label1);
			this.Name = "MainForm";
			this.Text = "MyComputerTools";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.ResumeLayout(false);

		}
	}
}
