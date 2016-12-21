using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
namespace SD

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool shut = false;
        public string runcmd(string command)
        {
            //实例一个Process类，启动一个独立进程
            Process p = new Process();
            //设定程序名
            p.StartInfo.FileName = "cmd.exe";
            //设定程式执行参数  
            p.StartInfo.Arguments = "/c " + command;
            //关闭Shell的使用
            p.StartInfo.UseShellExecute = false;   
            //重定向标准输入     
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            //设置不显示窗口
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            return p.StandardOutput.ReadToEnd();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            string cmdcode;
            if (Hour.SelectedItem == null || Minutes.SelectedItem == null)
            {
                return;
            }
            if (shut == false)
            {
                int nowH = DateTime.Now.Hour;
                int nowM = DateTime.Now.Minute;
                int nowS = DateTime.Now.Second;
                int aimH = int.Parse(Hour.SelectedItem.ToString());
                int aimM = int.Parse(Minutes.SelectedItem.ToString()); 
                if (aimM < nowM)
                {
                    aimM += 60;
                    aimH--;
                }
                if (aimH < nowH)
                {
                    aimH += 24;
                }
                int time = (aimH - nowH) * 60 * 60 + (aimM - nowM) * 60-nowS;
                cmdcode="shutdown.exe -s -t "+ time.ToString();
                //System.Diagnostics.Process.Start("cmd", "/c start/b shutdown.exe -s -t " + time.ToString());
                button1.Text = "取消";
                shut = true;
            }
            else
            {
                cmdcode="shutdown -a";
                button1.Text = "关机";
                shut = false;
            }
            runcmd(cmdcode);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //小时
            for (int i = 10; i < 24; i++)
            {
                if(i<10)
                    Hour.Items.Add("0" + i.ToString());
                else
                    Hour.Items.Add(i.ToString());
            }

            //分钟
            for (int i = 0; i < 60; i+=5)
            {
                if(i<10)
                    Minutes.Items.Add("0" + i.ToString());
                else
                    Minutes.Items.Add(i.ToString());
            }
        }

        private void Hour_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
