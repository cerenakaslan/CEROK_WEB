using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CEROK_WEBAPP.Models;

namespace CEROK_WEBAPP.Controllers
{
    public class HastaController : Controller
    {
        
        public ActionResult HastaView()
        {
            IEnumerable<HastaModel> hastas = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7086/api/");

                //Called Member default GET All records  
                //GetAsync to send a GET request   
                // PutAsync to send a PUT request  
                var responseTask = client.GetAsync("hasta");
                responseTask.Wait();

                //To store result of web api response.   
                var result = responseTask.Result;

                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<HastaModel>>();
                    readTask.Wait();

                    hastas = readTask.Result;
                }
                else
                {
                    //Error response received   
                    hastas = Enumerable.Empty<HastaModel>();
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }

                return View(hastas);
            }

        }           
        }
}








   /* public class DoktorController : Controller
    {
        Uri baseAdress = new Uri ("https://localhost:7086");
        HttpClient httpClient;

        public DoktorController()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = baseAdress;
        }
        public IActionResult DoktorView()
        {
            
            List<DoktorController> doktors = new List<DoktorController>();
            HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress+"/api/Doktor").Result;
            if(response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                doktors = JsonConvert.DeserializeObject<List<DoktorController>>(data);
            }
            return View(doktors);
        }
    }
}
   */