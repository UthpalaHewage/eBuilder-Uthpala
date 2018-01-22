using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp_ebuilder.Authorizer;

namespace WebApp_ebuilder.Controllers
{
    public class BaseController : Controller
    {
       public string BaseUrl = "https://technocoders.azurewebsites.net/api/";
       protected virtual new CustomPrincipal User
       {
            get { return HttpContext.User as CustomPrincipal; }
       }
    }


}