﻿using System.Web;
using System.Web.Mvc;

namespace pt12lolMvc4Application.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}