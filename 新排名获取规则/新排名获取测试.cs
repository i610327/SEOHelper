using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FeaturesBLL;
using System.Threading;


namespace 新排名获取规则
{
    public partial class Form_windows : Form
    {
        public Form_windows()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void button_huoqu_Click(object sender, EventArgs e)
        {
            Operate op = new Operate("baidu");

            if (op.Included(txt_url.Text.Trim()))
            {
                MessageBox.Show("收录");
            }
            else
            {
                MessageBox.Show("没有收录");
            }
        }

        private void Form_windows_Load(object sender, EventArgs e)
        {

        }


        Operate op = new Operate("so");

        private void button_paiming_Click(object sender, EventArgs e)
        {
            //
            //MessageBox.Show("您查询的排名为：" + op.GetRanking(txt_url.Text, "https://www.chinaname.cn", 30));
           

            //Thread t1 = new Thread(GetRanking);
            //t1.Start("起名网");
           
            WaitCallback w = new WaitCallback(GetRanking);
            
            //启动多个线程查看各个关键词的排名
            ThreadPool.QueueUserWorkItem(w, "起名网");
            ThreadPool.QueueUserWorkItem(w, "取名网");
            ThreadPool.QueueUserWorkItem(w, "宝宝起名");
            ThreadPool.QueueUserWorkItem(w, "公司起名");
            ThreadPool.QueueUserWorkItem(w, "品牌起名");
            ThreadPool.QueueUserWorkItem(w, "中华取名网");
            ThreadPool.QueueUserWorkItem(w, "中国起名网");

        }

        private string url = "https://www.chinaname.cn";

        private void GetRanking(object keyword)
        {
            txt_text.AppendText(keyword + "排名为：" + op.GetRanking(keyword.ToString(), url, 30) + "\r\n");
        }



    }
}
