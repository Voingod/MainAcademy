﻿using System.Web;
using System.Web.Mvc;

namespace Hello_CodeFirst_MVC_my
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}