using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CCWin;

namespace 排名查询
{
    public partial class 查询排名 : CCSkinMain
    {
        public 查询排名()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;//不设置这个无法则无法跨线程
        }

        private void btn_查询开始_Click(object sender, EventArgs e)
        {

        }

        BLL.Start st = new BLL.Start();
        private void 查询排名_Load(object sender, EventArgs e)
        {
            st.ChuShiHua();
            ChuShiHua();
        }

        private void ChuShiHua()
        {

            if (cmb_urls.Items.Count > 0)
            {
                //清空combobox
                cmb_urls.DataSource = null;
                cmb_urls.Items.Clear();
            }

            //绑定数据
            cmb_urls.DataSource = st.GetUrls();
            comboBox_url.DataSource = cmb_urls.DataSource;  
            //cmb_urls.DisplayMember = "Strtemname";// 指定显示的数据项
            //cmb_urls.ValueMember = "Strindex";  //指定comboBox1.SelectedValue返回的数据项
        }

        private void txt_wenben_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void ckb_指定UR查询_Click(object sender, EventArgs e)
        {
            if (ckb_url.Checked == true)
            {
                MessageBox.Show("您现在已经选择了指定UR查询，查询的格式为：关键词&链接" + "\n" + "切勿忘记关键词和链接中间有个&" + "\n" + "一行一条查询数据", "温馨提示");
            }
            else
            {
                MessageBox.Show("您已经关闭了指定UR查询，目前您只需要每行输入一个关键词即可","温馨提示");
            }
        }

        private void button_chaxun_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 收录查询数
        /// </summary>
        private int SiteCount = 0;

        /// <summary>
        /// 查询收录
        /// </summary>
        /// <param name="url">链接</param>
        private void SiteButton(string url)
        {
            var thread = new System.Threading.Thread(new System.Threading.ThreadStart(() =>
            {
                if (url.Length > 3)
                {
                    string[] Site = Ranking.GetSite("BaiDu", url);
                    //自增序号
                    SiteCount++;
                    //先声明
                    ListViewItem item = null;
                    //getFirstVisiblePosition() + 1
                    //获取编号
                    item = new ListViewItem(SiteCount.ToString());
                    //赋值标题
                    item.SubItems.Add(Site[1]);

                    //收录情况
                    item.SubItems.Add(Site[0]);

                    //快照日期
                    item.SubItems.Add(Site[2]);

                    //赋值状态
                    item.SubItems.Add(url.Trim());

                    //保存
                    list_site.Items.Add(item);
                }


            })) { IsBackground = true };

            thread.Start();
        }

        /// <summary>
        /// 收录查询
        /// </summary>
        private void btn_site_Click(object sender, EventArgs e)
        {
            if (txt_site.Text.Trim().Length < 3)
            {
                return;
            }

            string[] SiteUrls = txt_site.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);//字符串分割

            for (int i = 0; i < SiteUrls.Length;i++ )
            {
                if (SiteUrls[i].Trim().Contains("http"))
                {
                    SiteButton(SiteUrls[i].Trim());
                    btn_site.Enabled = false;
                    btn_site.Text = "查询中~（" + (i + 1) + "/" + SiteUrls.Length + "）";
                }
                else
                {
                    MessageBox.Show("您的链接格式不正确，请输入完整的链接，如http(s)://www.baidu.com");
                    break;
                }
            }
            //查询完成后，重新进行初始化
            btn_site.Enabled = true;
            btn_site.Text = "查询";
            txt_site.Text = string.Empty;
            
        }
        
        private void lbe_urls_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UI.地址增删 dz = new UI.地址增删();

            if (!UI.地址增删.open)
            {
                dz.Show();
            }
        }


        /// <summary>
        /// POST数据提交
        /// </summary>
        private void btn_APItijiao_Click(object sender, EventArgs e)
        {
            if (txt_api.Text.Trim().Length < 1)
            {
                MessageBox.Show("请输入正确的API提交地址~","警告");
                return;
            }
            else if (txt_APIurl.Text.Trim().Length < 1)
            {
                MessageBox.Show("需要提交的网址不能为空","警告");
                return;
            }


        }

        /// <summary>
        /// 关键词界面唤出
        /// </summary>
        private void Label_keyword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!UI.关键词增加.open)
            {
                UI.关键词增加 kw = new UI.关键词增加(comboBox_url.Text);
                kw.Show();
            }
        }

        /// <summary>
        /// 唯一时钟
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DAL.GlobalValue.State)
            {
                ChuShiHua();
                DAL.GlobalValue.State = false;
            }
        }

        /// <summary>
        /// 链接改变时
        /// </summary>
        private void cmb_urls_TextChanged(object sender, EventArgs e)
        {
            if (cmb_urls.Text.Count() > 1)
            {
                txt_shuru.Text = string.Empty;
                foreach (string value in st.GetKeywords(cmb_urls.Text))
                {
                    txt_shuru.AppendText(value + "\n");
                }
            }
        }

        private void txt_shuru_MouseLeave(object sender, EventArgs e)
        {
            MessageBox.Show("离开你");
        }





    }
}

