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
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select fst_nam,lst_nam,cpny, prf_nam from tbl_Contacts,tbl_Profession where tbl_Contacts.prf_id = tbl_Profession.prf_id", con);
                SqlDataReader dr = cmd.ExecuteReader();
                List<Combine> obj = new List<Combine>();
                while (dr.Read())
                {
                    Combine ab = new Combine();
                Contacts cont = new Contacts();
                Profession prof = new Profession();
                cont.fst_nam = dr[0].ToString();
                 cont.lst_nam  = dr[1].ToString();
                 cont.cpny = dr[2].ToString();
                   prof.prf_nam = dr[3].ToString();
                ab.contacts = cont;
                ab.profession = prof;
                obj.Add(ab);
                    
                }
                

                dr.Close();
                cmd.Dispose();
                con.Close();
                return obj;
            }
        public List<Profession> prof()

        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("select*from tbl_Profession", con);
            SqlDataReader dr = cmd.ExecuteReader();
            List<Profession> obj = new List<Profession>();
            while (dr.Read())
            {
                Profession prof = new Profession();
                 prof.prf_id = Convert.ToInt32(dr[0]);
                prof.prf_nam = dr[1].ToString();
                obj.Add(prof);
            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            return obj;
        }

        public void Create_Rec(Contacts cont)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("insert tbl_Contacts values( @cntid, @fstnam, @lstnam, @cpny, @prfid)", con);
            cmd.Parameters.AddWithValue("cntid", cont.cnt_id);
            cmd.Parameters.AddWithValue("fstnam", cont.fst_nam);
            cmd.Parameters.AddWithValue("lstnam", cont.lst_nam);
            cmd.Parameters.AddWithValue("cpny", cont.cpny);
            cmd.Parameters.AddWithValue("prfid", cont.prof_id);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
    }
}