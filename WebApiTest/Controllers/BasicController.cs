using Microsoft.AspNetCore.Mvc;

namespace WebApiTest.Controllers
{
    /// <summary>
    /// show how to basicly access the querystring, form data and header from http request.
    /// </summary>
    public class BasicController : Controller
    {

        [Route("api/basic/querystring")]
        public string QueryString()
        {
            // http://localhost/api/test/querystring?a=1&b=2&c=3
            var a = Request.Query["a"];
            var b = Request.Query["b"];
            var c = Request.Query["c"];
            return $"Test query string : {a}{b}{c}";
        }

        //same as above
        //[Route("api/basic/querystring")]
        //public string QueryString([FromQuery]string a, [FromQuery]string b, [FromQuery]string c)
        //{
        //    return $"Test query string : {a}{b}{c}";
        //}



        [Route("api/basic/form")]
        public string Form()
        {
            // Front-end js
            //<div>
            //    <p><button onclick="starttest();">test</button></p> 
            //    <p>Response</p>
            //    <p id="responsebox"></p>
            //</div>

            //<script>
            //    function starttest() {
            //        var requestform = new FormData();
            //        requestform.set("testvalue1", "tst1");
            //        requestform.set("testvalue2", "tst2");
            //        var req = new XMLHttpRequest();
            //        req.open("POST", "http://localhost:port/api/basic/form");
            //        req.send(requestform);
            //        req.onreadystatechange = function () {
            //            if (req.readyState == 3) {
            //                document.getElementById("responsebox").innerText = req.responseText;
            //            }
            //        }
            //    }
            //</script>

            var a = Request.Form["a"];
            var b = Request.Form["b"];
            var c = Request.Form["c"];
            return $"Test query string : {a}{b}{c}";
        }

        // same as above
        //[Route("api/basic/form")]
        //public string Form([FromForm]string a, [FromForm]string b, [FromForm]string c)
        //{
        //    return $"Test query string : {a}{b}{c}";
        //}

        [Route("api/basic/cookie")]
        public string Cookie()
        {
            // Front-end cookies
            //<div>
            //    <p><button onclick="starttest();">test</button></p>
            //    <p>Response</p>
            //    <p id="responsebox"></p>
            //</div>
            //<script>
            //    function starttest() {
            //        document.cookie = "testcookie=val1; expires=Thu, 18 Dec 2022 12:00:00 UTC; path=/";
            //        var req = new XMLHttpRequest();
            //        req.open("POST", "http://localhost:port/basic/cookie");
            //        req.send();
            //        req.onreadystatechange = function () {
            //            if (req.readyState == 3) {
            //                document.getElementById("responsebox").innerText = req.responseText;
            //            }
            //        }
            //    }
            //</script>
            var testcookie = Request.Cookies["testcookie"];
            return testcookie;
        }

        [Route("api/basic/header")]
        public string Header()
        {
            //<div>
            //    <p><button onclick="starttest();">test</button></p>
            //    <p>Response</p>
            //    <p id="responsebox"></p>
            //</div>
            //<script>
            //    function starttest() {
            //        var req = new XMLHttpRequest();
            //        req.open("POST", "http://localhost:port/api/basic/header");
            //        req.setRequestHeader("testheader1", "value1");
            //        req.setRequestHeader("testheader1", "value2");
            //        req.send();
            //        req.onreadystatechange = function () {
            //            if (req.readyState == 3) {
            //                document.getElementById("responsebox").innerText = req.responseText;
            //            }
            //        }
            //    }
            //</script>
            var testheader1 = Request.Headers["testheader1"];
            var testheader2 = Request.Headers["testheader2"];
            return $"{testheader1}{testheader2}";
        }

        // same with above
        //[Route("api/basic/header")]
        //public string Header([FromHeader]string testheader1, [FromHeader]string testheader2)
        //{
        //    return $"{testheader1}{testheader2}";
        //}

    }
}