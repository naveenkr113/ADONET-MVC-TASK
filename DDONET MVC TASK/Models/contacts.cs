using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDONET_MVC_TASK.Models
{
    public class Contacts
    {
        public Int32 cnt_id { get; set; }
        public string fst_nam { get; set; }
        public string lst_nam { get; set; }
        public string cpny { get; set; }
        public int prof_id { get; set; }
    }

    public class Profession
    {
        public int prf_id { get; set; }
        public string prf_nam { get; set; }
    }

    public class Combine
    {
        public Contacts contacts { get; set; }
        public Profession profession { get; set; }
    }
}

