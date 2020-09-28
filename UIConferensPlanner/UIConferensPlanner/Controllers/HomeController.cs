using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using UIConferensPlanner.Models;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace RestApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult GetResult()
        {
            string responseFromServer;
            WebRequest request = WebRequest.Create("https://localhost:44380/api/speakers/");
            request.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = request.GetResponse();

            using (Stream dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();
            }
            var mySpeakerList = JsonConvert.DeserializeObject<List<Speaker>>(responseFromServer);
            ViewBag.Javascript = "<script language='javascript' type='text/javascript'>alert('Code 201 - succeed');</script>";
            return View(mySpeakerList);
        }

        public IActionResult PostRequest()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PostResult()
        {
            Speaker speaker = new Speaker();
            return View(speaker);
        }

        [HttpPost]
        public ActionResult PostResult(Speaker speaker)
        {
            Speaker returnSpeaker = speaker;

            string postData = JsonConvert.SerializeObject(speaker);
            byte[] bytes = Encoding.UTF8.GetBytes(postData);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44380/api/speakers");
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentLength = bytes.Length;
            httpWebRequest.ContentType = "application/json";

            using (Stream requestStream = httpWebRequest.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Count());
            }
            var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            return View(returnSpeaker);
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}