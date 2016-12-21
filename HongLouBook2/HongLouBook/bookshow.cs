using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HongLouBook
{
    public partial class bookshow : UserControl
    {
        List<string> line = new List<string>();
        DataRow[] bookrows;
        BookForm bf;

        public bookshow()
        {
            InitializeComponent();
            
            line.Add("book_name");
            line.Add("author");
            line.Add("press");
            line.Add("p_date");
            line.Add("pages");
            line.Add("introduction");
            line.Add("author_introduction");
            line.Add("completely");
            line.Add("catalog");
            //line.Add("book");
        }
        public void setlable( DataRow[] rows)
        {
            bookrows = rows;
            bookName_comboBox1.Items.Clear();
            foreach (DataRow dr in rows)
            {
                bookName_comboBox1.Items.Add(dr["book_name"] + "," + dr["author"]);
                //bookName_comboBox1.Items.Add(dr["book_name"] + "," + dr["author"]);
            }
            bookName_comboBox1.SelectedIndex = 0;
            //showbook();
        }
        public void clearbook()
        { 
            book_name_showlabel.Text = "";
            author_showlabel.Text = "";
            press_showlabel.Text = "";
            p_date_showlabel.Text = "";
            pages_showlabel.Text = "";
            introduction_showlabel.Text = "";
            author_introduction_showlabel.Text = "";
            completely_showlabel.Text = "";
            catalog_showlabel.Text = "";
            //book_showlabel.Text = "";
            bookName_comboBox1.Items.Clear();
            bookName_comboBox1.Visible = false;
        }
        protected void showbook()
        {
            Graphics g = comboBox1.CreateGraphics();
            bookName_comboBox1.Visible = false;
            comboBox1.Items.Clear();
            comboBox1.Visible = false;
            for (int i = 0; i < bookrows.Length; i++)
            {
                if ((bookrows[i]["book_name"] + "," + bookrows[i]["author"]).Equals(bookName_comboBox1.Text.ToString()))
                {
                    foreach (string s in line)
                    {
                        if (s == "catalog")
                        {
                            int width = 0;
                            foreach (string cat in bookrows[i][s].ToString().Split('\n'))
                            {
                                if (cat != "")
                                {
                                    this.comboBox1.Items.Add(cat);
                                    int newwidth = (int)g.MeasureString(cat, comboBox1.Font).Width + 8;
                                    if (newwidth > width)
                                    {
                                        width = newwidth;
                                    }
                                }


                            }
                            //this.comboBox1.Items.AddRange(bookrows[i][s].ToString().Split('\n'));
                            if (width != 0)
                            {
                                comboBox1.DropDownWidth = width;
                                comboBox1.Visible = true;
                                comboBox1.SelectedIndex = 0;
                            }
                        }
                        else
                        {

                            this.Controls[s + "_showlabel"].Text = bookrows[i][s].ToString();
                        }
                    }
                }
            }
            if (bookrows.Length > 1)
            {
                bookName_comboBox1.Visible = true;
            }
 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            showbook();
        }

        private void book_showlabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (null == bf || bf.IsDisposed)
            {
                bf = new BookForm();
                bf.Show();//如果之前未打开，则打开。
            }
            else
            {
                bf.Activate();//之前已打开，则给予焦点，置顶。
            }
            bf.Text = book_name_showlabel.Text.ToString();
            bf.Controls["textBox1"].Text = System.IO.File.ReadAllText(Environment.CurrentDirectory + @"\Book\" + book_name_showlabel.Text + ".txt");
        }
    }
}
