﻿using System.Web;
using System.Web.Mvc;

namespace DDONET_MVC_TASK
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
