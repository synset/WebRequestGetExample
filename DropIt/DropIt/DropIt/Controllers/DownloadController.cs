using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DropIt.Controllers
{
    public class DownloadController : Controller
    {
        [HttpGet]
        public ActionResult DownloadFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DownloadFile(string fileName)
        {
            return View();
        }
    }
}