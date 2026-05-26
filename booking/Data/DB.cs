using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace booking.Data
{
    public class DB
    {
        protected SqlConnection cnMain;
        protected DataSet dsMain;
        protected SqlDataAdapter daMain;

        public DB()
        {
            try
            {
                cnMain = new SqlConnection(DbConfig.ConnectionString);
                dsMain = new DataSet();
            }
            catch (SystemException e)
            {
                MessageBox.Show(e.Message, "Database Error");
            }
        }

        public void FillDataSet(string sql, string table)
        {
            try
            {
                daMain = new SqlDataAdapter(sql, cnMain);
                cnMain.Open();
                daMain.Fill(dsMain, table);
                cnMain.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected bool UpdateDataSource(string sql, string table, bool refreshData = false)
        {
            try
            {
                cnMain.Open();
                daMain.Update(dsMain, table);
                cnMain.Close();
                if (refreshData)
                    FillDataSet(sql, table);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}