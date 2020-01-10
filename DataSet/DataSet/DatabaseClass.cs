using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataSet
{
    public class DatabaseClass:IDisposable
    {
        SqlConnection conn;

        public DatabaseClass()
        {
            Open();
        }

        public void Open()
        {
            if(conn == null)
            {
                string strConn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                conn = new SqlConnection(strConn);
                conn.Open();
            }
            else
            {

            }
        }
        public void Close()
        {
            if (conn != null)
            {
                conn.Close();
            }
            else
            {

            }
        }

        public void ExecuteSQL(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }

        public SqlDataReader ExecuteReader(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            return cmd.ExecuteReader();
        }

        ~DatabaseClass()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
            ReleaseNativeResource();
        }
        private void ReleaseNativeResource()
        {
            conn.Dispose();
        }

        
    }
}