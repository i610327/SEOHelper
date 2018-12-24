namespace 排名查询.UI
{
    partial class 关键词增加
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
            this.Button_Add = new CCWin.SkinControl.SkinButton();
            this.TextBox_keyword = new CCWin.SkinControl.SkinTextBox();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.list_from = new System.Windows.Forms.ListView();
            this.col_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_keyword = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsp_caidan = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsp_caidan.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button_Add
            // 
            this.Button_Add.BackColor = System.Drawing.Color.Transparent;
            this.Button_Add.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.Button_Add.DownBack = null;
            this.Button_Add.Location = new System.Drawing.Point(53, 389);
            this.Button_Add.MouseBack = null;
            this.Button_Add.Name = "Button_Add";
            this.Button_Add.NormlBack = null;
            this.Button_Add.Size = new System.Drawing.Size(133, 43);
            this.Button_Add.TabIndex = 23;
            this.Button_Add.Text = "添加";
            this.Button_Add.UseVisualStyleBackColor = false;
            this.Button_Add.Click += new System.EventHandler(this.Button_Add_Click);
            // 
            // TextBox_keyword
            // 
            this.TextBox_keyword.BackColor = System.Drawing.Color.Transparent;
            this.TextBox_keyword.DownBack = null;
            this.TextBox_keyword.Icon = null;
            this.TextBox_keyword.IconIsButton = false;
            this.TextBox_keyword.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.TextBox_keyword.IsPasswordChat = '\0';
            this.TextBox_keyword.IsSystemPasswordChar = false;
            this.TextBox_keyword.Lines = new string[0];
            this.TextBox_keyword.Location = new System.Drawing.Point(10, 243);
            this.TextBox_keyword.Margin = new System.Windows.Forms.Padding(0);
            this.TextBox_keyword.MaxLength = 32767;
            this.TextBox_keyword.MinimumSize = new System.Drawing.Size(28, 28);
            this.TextBox_keyword.MouseBack = null;
            this.TextBox_keyword.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.TextBox_keyword.Multiline = true;
            this.TextBox_keyword.Name = "TextBox_keyword";
            this.TextBox_keyword.NormlBack = null;
            this.TextBox_keyword.Padding = new System.Windows.Forms.Padding(5);
            this.TextBox_keyword.ReadOnly = false;
            this.TextBox_keyword.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBox_keyword.Size = new System.Drawing.Size(236, 136);
            // 
            // 
            // 
            this.TextBox_keyword.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBox_keyword.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_keyword.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.TextBox_keyword.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.TextBox_keyword.SkinTxt.Multiline = true;
            this.TextBox_keyword.SkinTxt.Name = "BaseText";
            this.TextBox_keyword.SkinTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBox_keyword.SkinTxt.Size = new System.Drawing.Size(226, 126);
            this.TextBox_keyword.SkinTxt.TabIndex = 0;
            this.TextBox_keyword.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.TextBox_keyword.SkinTxt.WaterText = "";
            this.TextBox_keyword.TabIndex = 22;
            this.TextBox_keyword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextBox_keyword.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.TextBox_keyword.WaterText = "";
            this.TextBox_keyword.WordWrap = true;
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.skinLabel1.Location = new System.Drawing.Point(21, 208);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(206, 27);
            this.skinLabel1.TabIndex = 21;
            this.skinLabel1.Text = "添加关键词(一行一个)";
            // 
            // list_from
            // 
            this.list_from.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_id,
            this.col_keyword});
            this.list_from.ContextMenuStrip = this.cmsp_caidan;
            this.list_from.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.list_from.FullRowSelect = true;
            this.list_from.GridLines = true;
            this.list_from.Location = new System.Drawing.Point(10, 27);
            this.list_from.Name = "list_from";
            this.list_from.Size = new System.Drawing.Size(236, 174);
            this.list_from.TabIndex = 20;
            this.list_from.UseCompatibleStateImageBehavior = false;
            this.list_from.View = System.Windows.Forms.View.Details;
            // 
            // col_id
            // 
            this.col_id.Text = "编号";
            this.col_id.Width = 42;
            // 
            // col_keyword
            // 
            this.col_keyword.Text = "关键词";
            this.col_keyword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col_keyword.Width = 185;
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
            // 关键词增加
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(257, 446);
            this.Controls.Add(this.Button_Add);
            this.Controls.Add(this.TextBox_keyword);
            this.Controls.Add(this.skinLabel1);
            this.Controls.Add(this.list_from);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "关键词增加";
            this.Opacity = 0.95D;
            this.ShowDrawIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "关键词增加";
            this.TitleCenter = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.关键词增加_FormClosed);
            this.Load += new System.EventHandler(this.关键词增加_Load);
            this.cmsp_caidan.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinButton Button_Add;
        private CCWin.SkinControl.SkinTextBox TextBox_keyword;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private System.Windows.Forms.ListView list_from;
        private System.Windows.Forms.ColumnHeader col_id;
        private System.Windows.Forms.ColumnHeader col_keyword;
        private System.Windows.Forms.ContextMenuStrip cmsp_caidan;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
    }
}