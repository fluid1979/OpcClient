using System;
using System.Data;
using System.Configuration;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data.SqlClient;



namespace OPCDialog
{
    /// <summary>
    /// Summary description for db_load
    /// </summary>
    public class db_load
    {
        static string connStr = ConfigurationManager.ConnectionStrings["mysql"].ConnectionString.ToString();
        MySqlConnection myconn = new MySqlConnection(connStr);


        public db_load()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //返回所需值
        public String reader_data(String tempsql, String sum_col)
        {
            String temp_pd = "0";
            myconn.Open();
            MySqlCommand mycommand = new MySqlCommand(tempsql, myconn);
            MySqlDataReader myreader = mycommand.ExecuteReader();

            if (myreader.Read())
            {
                temp_pd = myreader[sum_col].ToString();
            }
            myreader.Close();
            myconn.Close();
            return temp_pd;
        }

        //返回多值
        public String[] reader_data(String tempsql, String[] sum_col, int k)
        {
            String[] temp_pd = new String[k];

            myconn.Open();
            MySqlCommand mycommand = new MySqlCommand(tempsql, myconn);
            MySqlDataReader myreader = mycommand.ExecuteReader();

            if (myreader.Read())
            {
                for (int j = 0; j < k; j++)
                {
                    temp_pd[j] = myreader[sum_col[j]].ToString();
                }
            }
            else
            {
                for (int j = 0; j < k; j++)
                {
                    temp_pd[j] = "0";
                }
            }
            myreader.Close();
            myconn.Close();
            return temp_pd;
        }

        public bool db_exec(String str_sql)
        {
            myconn.Open();
            MySqlCommand mycomm = new MySqlCommand(str_sql, myconn);
            try
            {
                mycomm.ExecuteNonQuery();
                myconn.Close();
                return true;
            }
            catch 
            {
                
                myconn.Close();
                return false;
            }

        }

        public object return_first_row(string str)
        {
            myconn.Open();
            MySqlCommand mycomm = new MySqlCommand(str, myconn);
            try
            {
                object ob = mycomm.ExecuteScalar();
                myconn.Close();
                return ob;
            }
            catch 
            {
                myconn.Close();
                return null;
            }
        }

        //返回dataset
        public DataSet return_ds(String tempsql)
        {
            myconn.Open();
            MySqlDataAdapter mysda = new MySqlDataAdapter(tempsql, myconn);
            DataSet myds = new DataSet();
            mysda.Fill(myds);
            myconn.Close();
            return myds;
        }

        //调用存储过程
        public bool callStoreProceed(String xxxxxbbbb,DateTime delltime)
        {
            bool result = false;
            MySqlCommand mycomm = new MySqlCommand();
            try
            {
                myconn.Open();               
                mycomm.CommandType = CommandType.StoredProcedure;
                mycomm.Connection = myconn;
                mycomm.CommandText = "sp_al";  

                MySqlParameter[] mpara = new MySqlParameter[2];
                mpara[0] = new MySqlParameter("ProjDTUCode", MySqlDbType.VarChar);
                mpara[0].Value = xxxxxbbbb;
                mpara[1] = new MySqlParameter("MeasureTime", MySqlDbType.DateTime);
                mpara[1].Value = delltime;
                mycomm.Parameters.Add(mpara[0]);
                mycomm.Parameters.Add(mpara[1]);
                mycomm.ExecuteNonQuery();
                result = true;
            }
            catch
            {
                mycomm.Connection.Close();
                mycomm.Dispose();
                result = false;
            }
            finally
            {
                mycomm.Connection.Close();
                mycomm.Dispose();
            }
            return result;
        }

        public bool ExecuteSqlTran(List<string> SQLStringList)
        {
            myconn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = myconn;

            MySqlTransaction trans = myconn.BeginTransaction();
            

            //设置该Command将在事务trans中执行
            cmd.Transaction = trans;
            try
            {
                int count = 0;
                for (int i = 0; i < SQLStringList.Count; i++)
                {
                    
                    string strsql = SQLStringList[i].ToString();
                    if (strsql.Trim().Length > 1)
                    {
                        cmd.CommandText = strsql;
                        count= cmd.ExecuteNonQuery();
                    }

                }
                trans.Commit();
                return true;
            }
            catch 
            {
                trans.Rollback();
                return false;

            }
            finally
            {
                myconn.Close();
            }

        }

    }
}