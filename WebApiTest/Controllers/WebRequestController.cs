using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace WebApiTest.Controllers
{

    [ApiController]
    public class WebRequestController : ControllerBase
    {
        [Route("api/request/basic")]
        public string CallApi()
        {
            string url = "";
            WebRequest request = WebRequest.Create(url);
            // processing the request body
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string resp = reader.ReadToEnd();
            return resp;
        }

        [Route("api/request/complicated")]
        public string CallComplicatedApi()
        {
            var url = "";
            WebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("headervalue", "headerval");
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";
            StringBuilder postData = new StringBuilder();
            postData.Append($"formvalue1={HttpUtility.UrlEncode("val1")}&");
            postData.Append($"formvalue2={HttpUtility.UrlEncode("val2")}");

            var dat = System.Text.Encoding.UTF8.GetBytes(postData.ToString());
            using (var stream = request.GetRequestStream())
            {
                stream.Write(dat, 0, dat.Length);
            }

            WebResponse response = request.GetResponse();
            Stream str = response.GetResponseStream();
            StreamReader reader = new StreamReader(str);
            string resp = reader.ReadToEnd();
            return resp;
        }
    }
}