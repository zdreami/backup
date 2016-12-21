using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HongLouBook
{
    public class book
    {
        public int id;
        public string book_name;//书名
        public string author;//作者
        public string press;//出版社
        //public DateTime p_date;//出版日期
        public string p_date;//出版日期
        public int pages;//页数
        public int completely;//是否完整==
        public string introduction;//简介
        public string author_introduction;//作者简介
        //public string[] catalog;//目录
        public int[] catalogNumber;//目录页码
        public string bookurl;

        public List<string> catalogs=new List<string>();
        public List<int> catalogsNumber = new List<int>();

        public void catalogadd(string catalog)
        {
            //if (catalog.IndexOf("\t") != -1)
            //{
            //    string[] li = catalog.Split('\t');
            //    catalogs.Add(li[0]);
            //    catalogsNumber.Add(int.Parse(li[1]));
            //}
            //else
                catalogs.Add(catalog);  
        }
    }
}
