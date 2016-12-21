using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HongLouBook
{
    class GetBooks
    {
        string fileurl ;
        //= @"F:\hl.txt";
        List<book> bk = new List<book>();
        public GetBooks(string fileurl)
        {
            this.fileurl = fileurl;
        }

        public void getBook()
        {
            int i = 0;
            int bknum=-1;
            //FileStream file = new FileStream(bookurl, FileMode.Open);
            string[] lines = File.ReadAllLines(fileurl);
            while (i<lines.Count())
            {
                if (lines[i] == "作者：")
                {
                    bk.Add(new book());
                    bknum++;
                    bk[bknum].id = bknum;
                    bk[bknum].book_name = lines[i - 1].Substring(0, lines[i - 1].LastIndexOf("》")+1); //去除原书名后作者名
                    bk[bknum].author = lines[++i];
                    i++;
                }
                if (lines[i] == "出版社：")
                {
                    bk[bknum].press = lines[++i];
                    i++;
                }
                if (lines[i] == "出版日期：")
                {
                    bk[bknum].p_date = lines[++i];
                    i++;
                }
                if (lines[i] == "页数：")
                {
                    if (lines[i + 1] != "")
                    {
                        bk[bknum].pages = int.Parse(lines[++i].Replace("页", ""));
                    }
                    i++;
                }
                if (lines[i] == "正文完整性：")
                {
                    if (lines[++i] == "是")
                        bk[bknum].completely = 1;
                    else
                        bk[bknum].completely = 0;
                    i++;
                }
                if (lines[i] == "简介：")
                {
                    while (lines[i+1] != "作者简介：")
                        bk[bknum].introduction = lines[++i].Replace("'", "’");
                    i++;
                }
                if (lines[i] == "作者简介：")
                {
                    bk[bknum].author_introduction = lines[++i].Replace("'", "’");
                    i++;
                }
                if (lines[i] == "目录：")
                {
                    //int pages=0;
                    while (lines[i + 2] != "作者：")
                    {
                        //deal
                        bk[bknum].catalogadd(lines[++i].Replace("'","’"));
                        //bk[bknum].catalog[pages] = lines[++i];
                        if (i+3>lines.Count())
                        { 
                            break; 
                        }
                    }
                    i++;
                }
                i++;
            }
            //foreach(string line in lines)
            //{
            //    Console.WriteLine(line);
            //    //string a = lines[count - 1];
            //}
        }
        public delegate void bar(int total, int n);
        public event bar onbar;

        public void dbbook()
        {
            int i=0;
            DBconnect db = new DBconnect();
            foreach (book ibk in bk)
            {
                if(onbar!=null)
                    onbar(bk.Count,i++);
                db.insertinfo(ibk);
            }

        }
    }

}

