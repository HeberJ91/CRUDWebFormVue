using System.Collections.Generic;
using System.Data;

namespace CRUDWebFormVue
{
    internal class Conexiones
    {

        public DataTable ExecuteDataTable(string SQLSentence)
        {
            DataTable ExecuteDataTable = null;
            System.Data.SqlClient.SqlConnection oCnn = new System.Data.SqlClient.SqlConnection();

            //   oCnn = GetSqlConnection();
            string servidor = @"EEHNB180097\SQLEXPRESS";
            oCnn.ConnectionString = "Persist Security Info=False; Data Source =" + servidor + "; Initial Catalog = Empresa; User ID=admin;Password=Heber91$$$";
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