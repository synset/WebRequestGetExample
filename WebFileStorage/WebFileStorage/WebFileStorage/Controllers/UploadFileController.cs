using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebFileStorage.Controllers
{
    public class UploadFileController : Controller
    {
        // GET: UploadFile
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            string fileName = Path.GetFileName(file.FileName);
            string path = Path.Combine(Server.MapPath("~FilesUploaded"), fileName);
            file.SaveAs(path);

            return View();
        }

    }
}