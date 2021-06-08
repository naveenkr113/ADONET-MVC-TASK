using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DDONET_MVC_TASK.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DDONET_MVC_TASK.DAL
{

    public class contactsrepository:clscon
    {
        public List<Combine> Disp_Rec()
        {
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select fst_nam,lst_nam,cpny, prf_nam from tbl_Contacts,tbl_Profession where prof_id=prf_id", con);
                SqlDataReader dr = cmd.ExecuteReader();
                List<Combine> obj = new List<Combine>();
                while (dr.Read())
                {
                    Combine ab = new Combine();

                }

                dr.Close();
                cmd.Dispose();
                con.Close();
                return obj;
            }
    }
}