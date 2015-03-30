using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace briefcase.Controllers
{
    public class BaseController : Controller
    {
        protected BriefcaseEntities Db;

        public BaseController()
        {
            this.Db = new BriefcaseEntities();
        }
    }
}