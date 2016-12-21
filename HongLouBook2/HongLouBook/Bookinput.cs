using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HongLouBook
{
    public partial class Bookinput : Form
    {
        public Bookinput()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            book bk = new book();
            bk.author = author_textBox.Text;
            bk.author_introduction = author_introduction_textBox.Text;
            bk.book_name = book_name_textBox.Text;
            bk.introduction = introduction_textBox.Text;
            bk.p_date = p_date_textBox.Text;
            if (pages_textBox.Text != string.Empty)
                bk.pages = int.Parse(pages_textBox.Text);
            else
                bk.pages = 0;
            bk.press = press_textBox.Text;
            foreach (string s in catalog_textBox.Lines)
            {
                bk.catalogadd(s);
            }
            //bk.completely = completely_checkBox;
            if (completely_checkBox.Checked)
            {
                bk.completely = 1;
            }
            else
                bk.completely = 0;
            DBconnect db = new DBconnect();
            if (db.insertinfo(bk) == 0)
            {
                MessageBox.Show("导入成功");
                foreach (Control str in Controls)
                {
                    if (str is TextBox)
                    {
                        str.Text = string.Empty;
                    }
                }
            }
        }

    }
}
