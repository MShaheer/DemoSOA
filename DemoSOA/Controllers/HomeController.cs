using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using DemoSOA.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DemoSOA.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           

            return View();
        }


        //public ActionResult client() {

        //    DemoSOA.Controllers.Billmastermodel.billmasters model = null;
        //    var client = new HttpClient();
           
        //    var task =
        //        client.GetAsync(
        //        "http://localhost:51632/api/BillmasterApi")
        //        .ContinueWith((taskwithresponse) =>
        //        {
                   
        //            var response = taskwithresponse.Result;
        //            var readtask = response.Content.ReadAsAsync<DemoSOA.Controllers.Billmastermodel.billmasters>();
        //           readtask.Wait();
        //            model = readtask.Result;
        //        });
        //    task.Wait();
        //    return View(model.results);


        //}


        public async Task<ActionResult> client()
        {
            DemoSOA.Controllers.Billmastermodel.billmasters model = null;
         //   List<DemoSOA.Controllers.Billmastermodel.billmasters> mode = null;
            using (HttpClient httpclient = new HttpClient())
            {
                model = JsonConvert.DeserializeObject<DemoSOA.Controllers.Billmastermodel.billmasters>(
                    await httpclient.GetStringAsync("http://localhost:51632/api/BillmasterApi")
                );
            }
            return View(model.results);
        }





    }
}
