using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CRUDWebFormVue
{
    internal class Conexiones
    {
        string _LastSQLErrorMessage = string.Empty;
      
        string _ConnectionString = "Persist Security Info=False; Data Source =" + @"EEHNB180097\SQLEXPRESS" + "; Initial Catalog = Empresa; User ID=admin;Password=Heber91$$$";


        public DataTable ExecuteDataTable(string SQLSentence)
        {
            DataTable ExecuteDataTable = null;
            System.Data.SqlClient.SqlConnection oCnn = new System.Data.SqlClient.SqlConnection();

            //   oCnn = GetSqlConnection();

            oCnn.ConnectionString = _ConnectionString;
            oCnn.Open();

            System.Data.SqlClient.SqlDataAdapter daSQLCommand;
            DataTable dtResultado = new DataTable();
            daSQLCommand = new System.Data.SqlClient.SqlDataAdapter(SQLSentence, oCnn);


            daSQLCommand.Fill(dtResultado);
            ExecuteDataTable = dtResultado;



            oCnn.Close();
            oCnn.Dispose();
            daSQLCommand.Dispose();

            return ExecuteDataTable;
        }


        public bool ExecuteCommand(string SQLSentence, bool IsStoredProcedure = false)
        {
            bool ExecuteCommand = false;
            _LastSQLErrorMessage = string.Empty;

            System.Data.SqlClient.SqlConnection oCnn = new System.Data.SqlClient.SqlConnection();
            oCnn.ConnectionString = _ConnectionString;
            oCnn.Open();

            System.Data.SqlClient.SqlCommand SQLCommand = new System.Data.SqlClient.SqlCommand(SQLSentence, oCnn);
            SQLCommand.CommandType = (IsStoredProcedure == false ?  CommandType.Text : CommandType.StoredProcedure);

            try
            {
                SQLCommand.ExecuteNonQuery();
                ExecuteCommand = true;
            }
            catch (SqlException oExcep)
            {
                _LastSQLErrorMessage = string.Format("SQL-Message: {0}", oExcep.Message.ToString());
                throw;
            }

            catch (Exception oExcep)
            {
                _LastSQLErrorMessage = string.Format("Message: {0}", oExcep.Message.ToString());
                throw;
            }
            oCnn.Close();
            oCnn.Dispose();
            SQLCommand.Dispose();
            return ExecuteCommand;
        }


        public string DataTableToJson(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                Dictionary<string, object> row;

                System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();


                foreach (DataRow dr in dt.Rows)
                {
                    row = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    rows.Add(row);
                }
                return serializer.Serialize(rows);


            }
            else
                return "[]";
        }

    }
}