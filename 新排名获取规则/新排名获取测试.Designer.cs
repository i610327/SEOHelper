namespace 新排名获取规则
{
    partial class Form_windows
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_huoqu = new System.Windows.Forms.Button();
            this.txt_url = new System.Windows.Forms.TextBox();
            this.button_paiming = new System.Windows.Forms.Button();
            this.txt_text = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_huoqu
            // 
            this.button_huoqu.Location = new System.Drawing.Point(45, 141);
            this.button_huoqu.Name = "button_huoqu";
            this.button_huoqu.Size = new System.Drawing.Size(136, 32);
            this.button_huoqu.TabIndex = 0;
            this.button_huoqu.Text = "查询收录";
            this.button_huoqu.UseVisualStyleBackColor = true;
            this.button_huoqu.Click += new System.EventHandler(this.button_huoqu_Click);
            // 
            // txt_url
            // 
            this.txt_url.Location = new System.Drawing.Point(12, 23);
            this.txt_url.Multiline = true;
            this.txt_url.Name = "txt_url";
            this.txt_url.Size = new System.Drawing.Size(388, 112);
            this.txt_url.TabIndex = 1;
            // 
            // button_paiming
            // 
            this.button_paiming.Location = new System.Drawing.Point(213, 141);
            this.button_paiming.Name = "button_paiming";
            this.button_paiming.Size = new System.Drawing.Size(136, 32);
            this.button_paiming.TabIndex = 2;
            this.button_paiming.Text = "查询排名";
            this.button_paiming.UseVisualStyleBackColor = true;
            this.button_paiming.Click += new System.EventHandler(this.button_paiming_Click);
            // 
            // txt_text
            // 
            this.txt_text.Location = new System.Drawing.Point(406, 22);
            this.txt_text.Multiline = true;
            this.txt_text.Name = "txt_text";
            this.txt_text.Size = new System.Drawing.Size(337, 151);
            this.txt_text.TabIndex = 3;
            // 
            // Form_windows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 181);
            this.Controls.Add(this.txt_text);
            this.Controls.Add(this.button_paiming);
            this.Controls.Add(this.txt_url);
            this.Controls.Add(this.button_huoqu);
            this.Name = "Form_windows";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form_windows_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_huoqu;
        private System.Windows.Forms.TextBox txt_url;
        private System.Windows.Forms.Button button_paiming;
        private System.Windows.Forms.TextBox txt_text;
    }
}

