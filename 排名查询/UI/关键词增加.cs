using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 排名查询.UI
{
    public partial class 关键词增加 : CCSkinMain
    {
        public 关键词增加(string url)
        {
            InitializeComponent();
            Url = url;
        }

        /// <summary>
        /// 判断是否打开
        /// </summary>
        public static bool open = false;

        /// <summary>
        /// 查询的链接
        /// </summary>
        private string Url = string.Empty;

        /// <summary>
        /// 软件初始化
        /// </summary>
        private void 关键词增加_Load(object sender, EventArgs e)
        {
            ChuShiHua();
            open = true;
        }

        BLL.Start st = new BLL.Start();

        /// <summary>
        /// 初始化
        /// </summary>
        private void ChuShiHua()
        {
            //清空原有，否则无法添加新的
            if (list_from.Items.Count > 0)
            {
                list_from.Items.Clear();
            }
            //先声明
            ListViewItem item = null;
            int id = 0;
           
            foreach (string urs in st.GetKeywords(Url))
            {
                id++;
                item = new ListViewItem(id.ToString());
                //标题赋值
                item.SubItems.Add(urs);
                //保存
                list_from.Items.Add(item);

            }
        }


        /// <summary>
        /// 添加关键词
        /// </summary>
        private void Button_Add_Click(object sender, EventArgs e)
        {
            string[] Kyewords = TextBox_keyword.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);//字符串分割
            BLL.XMLS xml = new BLL.XMLS();
            string value = xml.UpdateXmlKyewords(Url, Kyewords) ? "更新成功~" : "更新失败~";
            MessageBox.Show(value);
            ChuShiHua();
            TextBox_keyword.Text = string.Empty;
        }

        /// <summary>
        /// 窗体关闭后
        /// </summary>
        private void 关键词增加_FormClosed(object sender, FormClosedEventArgs e)
        {
            open = false;
        }
    }
}
