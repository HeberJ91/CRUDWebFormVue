using javax.jws;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDWebFormVue
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [System.Web.Services.WebMethod]
        public static string getinfo()
        {
            OrderedDictionary Respond = new OrderedDictionary();
            
            try
            {
                Conexiones con = new Conexiones();
                DataTable dt = con.ExecuteDataTable("Select * from Empleados");

                Respond.Add("empleados", con.DataTableToJson(dt));
            }
            catch (Exception ex)
            {
                Respond.Add("Error", ex.Message);

            }

            return new JavaScriptSerializer().Serialize(Respond);
        }



  
    }


}