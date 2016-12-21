using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace HongLouBook
{
    public partial class Form1 : Form
    {
        
        DBconnect db = new DBconnect();
        DataTable dt;
        string keyword;
        string line;
        
        public Form1()
        {
            InitializeComponent();
            choose_comboBox1.Items.Add(new Item("书名", "book_name"));
            choose_comboBox1.Items.Add(new Item("作者", "author"));
            choose_comboBox1.Items.Add(new Item("出版社", "press"));
            //choose_comboBox1.Items.Add(new Item("目录", "catalog"));
            choose_comboBox1.SelectedIndex = 0;
            //
            
        }

        private void seanch_button_Click(object sender, EventArgs e)
        {
            show_listBox.Visible = true;
            show_listBox.Items.Clear();
            bookshow1.clearbook();
            Item item = (Item)choose_comboBox1.SelectedItem;

            keyword = textBox1.Text;
            line = item.Value;
            dt = db.SelectAllLine(line, keyword);
            if (dt.Rows.Count > 0)
            {
                show_listBox.Items.Add(dt.Rows[0][line].ToString());
                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][line].ToString() != dt.Rows[i - 1][line].ToString())
                        show_listBox.Items.Add(dt.Rows[i][line].ToString());
                }
                show_listBox.SelectedIndex = 0;
            }
        }


        private void 导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "txt|*.txt";
            dlg.Title = "导入";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                db.dropTable();
                db.createTable();
                bookdo(dlg.FileName);
                //new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(bookdo)).Start(dlg.FileName);
            }
            show_listBox.Items.Clear();
            textBox1.Text = "";
            bookshow1.clearbook();
            progressBar1.Value = 0;
            progressBar1.Visible = false;
        }
        public void bookdo(object obj)
        {
            GetBooks bk = new GetBooks(obj.ToString());
            bk.onbar+=new GetBooks.bar(barchange);
            bk.getBook();
            bk.dbbook();

        }
        private void barchange(int total,int current)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new GetBooks.bar(barchange), new object[] { total, current });
            }
            else
            {
                this.progressBar1.Maximum = total;
                this.progressBar1.Value = current;
            }
 
        }

        private void show_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow[] rows = dt.Select(line + " like '" + show_listBox.Text + "'");
            bookshow1.setlable(rows);
        }

        private void 插入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bookinput bp = new Bookinput();
            bp.Show();
        }

    }
}
