using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DDONET_MVC_TASK.Models
{
    public abstract class clscon
    {
        protected SqlConnection con = new SqlConnection();
        public clscon()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        }
    }
}