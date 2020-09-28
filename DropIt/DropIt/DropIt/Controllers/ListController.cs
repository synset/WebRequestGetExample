using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DropIt.Controllers
{
    public class ListController : Controller
    {
        // GET: File
        public ActionResult ListFiles()
        {
            IEnumerable<string> files = Directory.EnumerateFiles(Server.MapPath("~/UploadedFiles"));
            return View(files);
            
        }
    }
}