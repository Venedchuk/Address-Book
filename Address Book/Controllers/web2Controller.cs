using Address_Book.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Address_Book.Controllers
{
    public class web2Controller : Controller
    {
        DataAdapter dataAdapter = new DataAdapter();
        public ActionResult Index()
        {
            var url = Request.Url.LocalPath;

            return View(dataAdapter.GetUsers(url));
        }

    }
}