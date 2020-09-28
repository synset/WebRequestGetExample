using System;
using System.Collections.Generic;  
using System.IO;  
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace DropIt.Controllers{

    public class UploadController : Controller
    {
        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            List<string> filenames = new List<string>();

            try
            {
                if (file.ContentLength > 0)
                {
                    string _fileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _fileName);
                    file.SaveAs(_path);
                    filenames.Add(_fileName);
                }
                ViewBag.Message = "File Uploaded Successfully";

                return View(filenames);
            }
            catch
            {
                ViewBag.Message = "File upload failed";
                return View();
            }
        }

        







        //public ActionResult GetResult()
        //{
        //    string responseFromServer;
        //    WebRequest request = WebRequest.Create("https://localhost:44380/api/speakers/");
        //    request.Credentials = CredentialCache.DefaultCredentials;
        //    WebResponse response = request.GetResponse();

        //    using (Stream dataStream = response.GetResponseStream())
        //    {
        //        StreamReader reader = new StreamReader(dataStream);
        //        responseFromServer = reader.ReadToEnd();
        //    }
        //    var mySpeakerList = JsonConvert.DeserializeObject<List<Speaker>>(responseFromServer);
        //    ViewBag.Javascript = "<script language='javascript' type='text/javascript'>alert('Code 201 - succeed');</script>";
        //    return View(mySpeakerList);
        //}


        //public IActionResult PostRequest()
        //{
        //    return View();
        //}

        //[HttpGet]
        //public IActionResult PostResult()
        //{
        //    Speaker speaker = new Speaker();
        //    return View(speaker);
        //}

        //[HttpPost]
        //public ActionResult PostResult(Speaker speaker)
        //{
        //    Speaker returnSpeaker = speaker;

        //    string postData = JsonConvert.SerializeObject(speaker);
        //    byte[] bytes = Encoding.UTF8.GetBytes(postData);
        //    var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44380/api/speakers");
        //    httpWebRequest.Method = "POST";
        //    httpWebRequest.ContentLength = bytes.Length;
        //    httpWebRequest.ContentType = "application/json";

        //    using (Stream requestStream = httpWebRequest.GetRequestStream())
        //    {
        //        requestStream.Write(bytes, 0, bytes.Count());
        //    }
        //    var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

        //    return View(returnSpeaker);
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }  
}  