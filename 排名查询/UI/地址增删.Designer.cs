namespace 排名查询.UI
{
    partial class 地址增删
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.list_from = new System.Windows.Forms.ListView();
            this.col_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_url = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsp_caidan = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.TextBox_url = new CCWin.SkinControl.SkinTextBox();
            this.Button_Add = new CCWin.SkinControl.SkinButton();
            this.cmsp_caidan.SuspendLayout();
            this.SuspendLayout();
            // 
            // list_from
            // 
            this.list_from.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_id,
            this.col_url});
            this.list_from.ContextMenuStrip = this.cmsp_caidan;
            this.list_from.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.list_from.FullRowSelect = true;
            this.list_from.GridLines = true;
            this.list_from.Location = new System.Drawing.Point(7, 31);
            this.list_from.Name = "list_from";
            this.list_from.Size = new System.Drawing.Size(295, 174);
            this.list_from.TabIndex = 16;
            this.list_from.UseCompatibleStateImageBehavior = false;
            this.list_from.View = System.Windows.Forms.View.Details;
            // 
            // col_id
            // 
            this.col_id.Text = "编号";
            this.col_id.Width = 42;
            // 
            // col_url
            // 
            this.col_url.Text = "网址";
            this.col_url.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col_url.Width = 246;
            // 
            // cmsp_caidan
            // 
            this.cmsp_caidan.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.cmsp_caidan.Name = "cmsp_caidan";
            this.cmsp_caidan.Size = new System.Drawing.Size(95, 26);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(9, 224);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(59, 17);
            this.skinLabel1.TabIndex = 17;
            this.skinLabel1.Text = "添加网址:";
            // 
            // TextBox_url
            // 
            this.TextBox_url.BackColor = System.Drawing.Color.Transparent;
            this.TextBox_url.DownBack = null;
            this.TextBox_url.Icon = null;
            this.TextBox_url.IconIsButton = false;
            this.TextBox_url.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.TextBox_url.IsPasswordChat = '\0';
            this.TextBox_url.IsSystemPasswordChar = false;
            this.TextBox_url.Lines = new string[0];
            this.TextBox_url.Location = new System.Drawing.Point(70, 218);
            this.TextBox_url.Margin = new System.Windows.Forms.Padding(0);
            this.TextBox_url.MaxLength = 32767;
            this.TextBox_url.MinimumSize = new System.Drawing.Size(28, 28);
            this.TextBox_url.MouseBack = null;
            this.TextBox_url.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.TextBox_url.Multiline = false;
            this.TextBox_url.Name = "TextBox_url";
            this.TextBox_url.NormlBack = null;
            this.TextBox_url.Padding = new System.Windows.Forms.Padding(5);
            this.TextBox_url.ReadOnly = false;
            this.TextBox_url.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBox_url.Size = new System.Drawing.Size(158, 28);
            // 
            // 
            // 
            this.TextBox_url.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBox_url.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_url.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.TextBox_url.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.TextBox_url.SkinTxt.Name = "BaseText";
            this.TextBox_url.SkinTxt.Size = new System.Drawing.Size(148, 18);
            this.TextBox_url.SkinTxt.TabIndex = 0;
            this.TextBox_url.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.TextBox_url.SkinTxt.WaterText = "";
            this.TextBox_url.TabIndex = 18;
            this.TextBox_url.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextBox_url.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.TextBox_url.WaterText = "";
            this.TextBox_url.WordWrap = true;
            // 
            // Button_Add
            // 
            this.Button_Add.BackColor = System.Drawing.Color.Transparent;
            this.Button_Add.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.Button_Add.DownBack = null;
            this.Button_Add.Location = new System.Drawing.Point(232, 218);
            this.Button_Add.MouseBack = null;
            this.Button_Add.Name = "Button_Add";
            this.Button_Add.NormlBack = null;
            this.Button_Add.Size = new System.Drawing.Size(65, 28);
            this.Button_Add.TabIndex = 19;
            this.Button_Add.Text = "添加";
            this.Button_Add.UseVisualStyleBackColor = false;
            this.Button_Add.Click += new System.EventHandler(this.Button_Add_Click);
            // 
            // 地址增删
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(309, 259);
            this.Controls.Add(this.Button_Add);
            this.Controls.Add(this.TextBox_url);
            this.Controls.Add(this.skinLabel1);
            this.Controls.Add(this.list_from);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "地址增删";
            this.Opacity = 0.9D;
            this.ShowDrawIcon = false;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "地址增删";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.地址增删_FormClosed);
            this.Load += new System.EventHandler(this.地址增删_Load);
            this.cmsp_caidan.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView list_from;
        private System.Windows.Forms.ColumnHeader col_id;
        private System.Windows.Forms.ColumnHeader col_url;
        private System.Windows.Forms.ContextMenuStrip cmsp_caidan;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinTextBox TextBox_url;
        private CCWin.SkinControl.SkinButton Button_Add;
    }
}