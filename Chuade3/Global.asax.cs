using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Chuade3.Models;

namespace Chuade3
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            // Khởi tạo bảng không có dữ liệu cho Database mà mình vừa liên kết với DataContext
            // Database.SetInitializer(new DropCreateDatabaseIfModelChanges<QLBHDatacontext>());
            Database.SetInitializer(new DataInitializer());
        }
    }
}
