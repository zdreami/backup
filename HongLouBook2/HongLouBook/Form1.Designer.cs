namespace HongLouBook
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.seanch_button = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.导入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.插入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.choose_comboBox1 = new System.Windows.Forms.ComboBox();
            this.show_listBox = new System.Windows.Forms.ListBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.bookshow1 = new HongLouBook.bookshow();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // seanch_button
            // 
            resources.ApplyResources(this.seanch_button, "seanch_button");
            this.seanch_button.Name = "seanch_button";
            this.seanch_button.UseVisualStyleBackColor = true;
            this.seanch_button.Click += new System.EventHandler(this.seanch_button_Click);
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导入ToolStripMenuItem,
            this.插入ToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // 导入ToolStripMenuItem
            // 
            resources.ApplyResources(this.导入ToolStripMenuItem, "导入ToolStripMenuItem");
            this.导入ToolStripMenuItem.Name = "导入ToolStripMenuItem";
            this.导入ToolStripMenuItem.Click += new System.EventHandler(this.导入ToolStripMenuItem_Click);
            // 
            // 插入ToolStripMenuItem
            // 
            resources.ApplyResources(this.插入ToolStripMenuItem, "插入ToolStripMenuItem");
            this.插入ToolStripMenuItem.Name = "插入ToolStripMenuItem";
            this.插入ToolStripMenuItem.Click += new System.EventHandler(this.插入ToolStripMenuItem_Click);
            // 
            // choose_comboBox1
            // 
            resources.ApplyResources(this.choose_comboBox1, "choose_comboBox1");
            this.choose_comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.choose_comboBox1.FormattingEnabled = true;
            this.choose_comboBox1.Name = "choose_comboBox1";
            // 
            // show_listBox
            // 
            resources.ApplyResources(this.show_listBox, "show_listBox");
            this.show_listBox.FormattingEnabled = true;
            this.show_listBox.Name = "show_listBox";
            this.show_listBox.SelectedIndexChanged += new System.EventHandler(this.show_listBox_SelectedIndexChanged);
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            // 
            // bookshow1
            // 
            resources.ApplyResources(this.bookshow1, "bookshow1");
            this.bookshow1.Name = "bookshow1";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.bookshow1);
            this.Controls.Add(this.show_listBox);
            this.Controls.Add(this.choose_comboBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.seanch_button);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button seanch_button;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 导入ToolStripMenuItem;
        private System.Windows.Forms.ComboBox choose_comboBox1;
        private System.Windows.Forms.ListBox show_listBox;
        private bookshow bookshow1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStripMenuItem 插入ToolStripMenuItem;
    }
}

