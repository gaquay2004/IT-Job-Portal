using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfJobFinding
{
    public class DBConnection
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.cnnStr);
        
        public void Execute(string sqlStr)
        {
            try
            {
                // Ket noi
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                if (cmd.ExecuteNonQuery() > 0)
                    MessageBox.Show("Connection attempt successfully");
                else
                    MessageBox.Show("Server not existed.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection attempt unsuccessful. Please check your server connection." + ex);
            }
            finally
            {
                conn.Close();
            }
        }
        public DataTable Load(string sqlStr)
        {       
            try
            {
                conn.Open();               
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                DataTable datatable = new DataTable();
                adapter.Fill(datatable);
                return datatable;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
            return new DataTable();
        }
    }
}
