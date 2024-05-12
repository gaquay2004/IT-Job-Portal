using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfJobFinding
{
    public class BaseDAO
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.cnnStr);
        DBConnection dbConn = new DBConnection();

        protected string stringFormat;
        public BaseDAO  (string stringFormat)
        {
            this.stringFormat = stringFormat;
        }
        

        public void Insert()
        {
            
            string sqlStr = string.Format(stringFormat);
            dbConn.Execute(sqlStr);
            
        }

        public void Update()
        {
           
            string sqlStr = string.Format(stringFormat);
            dbConn.Execute(sqlStr);
        }

        public void Delete()
        {
            string sqlStr = string.Format(stringFormat);
            dbConn.Execute(sqlStr);
        }

        public DataTable Load()
        {
            string sqlStr = string.Format(stringFormat);
            return dbConn.Load(sqlStr);
        }
    }
}
