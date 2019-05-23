using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace API_PowerBI_AzureAD.Controllers
{
    public class HomeController : Controller
    {
        public ContentResult Index()
        {
            return Content("api available in ~/api/values");
        }
    }
}
