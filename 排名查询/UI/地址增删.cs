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
    public partial class 地址增删 : CCSkinMain
    {
        public 地址增删()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 判断是否打开
        /// </summary>
        public static bool open = false;

        private void 地址增删_Load(object sender, EventArgs e)
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
            foreach (string urs in st.GetUrls())
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
        /// 提交按钮被点击
        /// </summary>
        private void Button_Add_Click(object sender, EventArgs e)
        {
            
            if (TextBox_url.Text.Trim().Length < 1)
            {
                MessageBox.Show("链接格式错误~","警告");
                return;
            }

            BLL.XMLS xml = new BLL.XMLS();
            string value = xml.AddXmlUrl(TextBox_url.Text.Trim()) ? "添加成功~" : "添加失败,请您检查是否已经存在同类型的值~";
            MessageBox.Show(value,"温馨提示");
            ChuShiHua();
            TextBox_url.Text = string.Empty;
            
        }

        /// <summary>
        /// 关闭后赋值
        /// </summary>
        private void 地址增删_FormClosed(object sender, FormClosedEventArgs e)
        {
            open = false;
        }



    }
}
