using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp_ebuilder.Authorizer;

namespace WebApp_ebuilder.Views
{
   

        public abstract class BaseViewPage : WebViewPage
        {
            public virtual new CustomPrincipal User
            {
                get { return base.User as CustomPrincipal; }
            }


        }

        public abstract class BaseViewPage<TModel> : WebViewPage<TModel>
        {
            public virtual new CustomPrincipal User
            {
                get { return base.User as CustomPrincipal; }
            }


        }
    
}
