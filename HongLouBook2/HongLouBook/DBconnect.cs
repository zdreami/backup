using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;

namespace HongLouBook
{
    class DBconnect
    {
        SQLiteConnection con =null;
        SQLiteCommand cmd = new SQLiteCommand();
        public DBconnect()
        {
            try
            {
                //con.ConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\zdream\Documents\HLBook.mdf;Integrated Security=True;User Instance=True";
                //con.ConnectionString = @"Data Source= HL.sdf";
                string dbPath = "Data Source =" + Environment.CurrentDirectory + "/HL.db";
                con = new SQLiteConnection(dbPath);
                con.Open();
                cmd.Connection = con;
                IsTableExist();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void IsTableExist()
        {
            //表不存在则创建表
            cmd.CommandText = "SELECT COUNT(*) FROM sqlite_master where type='table' and name='hlbase';";
            if (0 == Convert.ToInt32(cmd.ExecuteScalar()))
            {
                createTable();
                GetBooks bk = new GetBooks(Environment.CurrentDirectory + @"\hl.txt");
                bk.getBook();
                bk.dbbook();
                //table - Student does not exist.
            }
            else
            {
                //table - Student does exist.
            }
        } 

        public void dropTable()
        {
            cmd.CommandText = "DROP TABLE IF EXISTS hlbase";
            cmd.ExecuteNonQuery();
        }

        public void createTable()
        {
            try
            {
                //if (con.State != ConnectionState.Open)
                //    con.Open();
                //FileInfo file = new FileInfo("CREATE TABLE hlbase()");
                //cmd.CommandText = file.OpenText().ReadToEnd();
                cmd.CommandText = @"CREATE TABLE IF NOT EXISTS hlbase (
                                      id                    INTEGER          PRIMARY KEY AUTOINCREMENT NOT NULL,
                                      book_name             NVARCHAR(150)    NOT NULL,
                                      author                NCHAR(15)        NOT NULL,
                                      press                 NVARCHAR(100)    ,
                                      p_date                NCHAR(20)        ,
                                      pages                 int              ,
                                      introduction          NVARCHAR(1000)   DEFAULT NULL,
                                      author_introduction   NVARCHAR(1000)   DEFAULT NULL,
                                      completely            bit              NOT NULL,
                                      catalog               ntext
                                    );";
                cmd.ExecuteNonQuery();

                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public DataTable SelectAllLine(string line,string keyword)
        {
            //无防注入
            if (keyword.IndexOf("_") == -1)
                keyword = "%" + keyword + "%";
            string select="SELECT * FROM hlbase WHERE " + line + " LIKE'"+keyword+"'";
            SQLiteDataAdapter da = new SQLiteDataAdapter(select, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable SelectLine(string line, string keyword)
        {
            //无防注入
            string select = "SELECT DISTINCT " + line + " FROM hlbase WHERE " + line + " LIKE'%" + keyword + "%'";
            SQLiteDataAdapter da = new SQLiteDataAdapter(select, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public int insertinfo(book bk)
        {
            try
            {
                string cat="";
                foreach (string c in bk.catalogs)
                {
                    cat += c+"\n";
                }
                cmd.CommandText = "insert into hlbase(book_name,author,press,p_date,pages,introduction,author_introduction,completely,catalog) values('" + bk.book_name + "','" + bk.author + "','" + bk.press + "','" + bk.p_date + "'," + bk.pages + ",'" + bk.introduction + "','" + bk.author_introduction + "'," + bk.completely + ",'" + cat + "')";
                //cmd.CommandText = "insert into hlbase(id,book_name,author,press,p_date,pages,introduction,author_introduction,completely,catalog) values('" + bk.id + "','" + bk.book_name + "','" + bk.author + "','" + bk.press + "','" + bk.p_date + "'," + bk.pages + ",'" + bk.introduction + "','" + bk.author_introduction + "'," + bk.completely + ",'" + cat + "')";
                cmd.ExecuteNonQuery();
                return 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return 1;
            }
            
        }


    }
}
