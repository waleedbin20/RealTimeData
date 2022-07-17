using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using RealTimeWebUI.Model;


using System.Collections.Generic;

using System.Net.Http;


namespace RealTimeWebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {

            _logger = logger;
            _configuration = configuration;
        }


        
       /* public IActionResult Update()
        {
            new ReceiverHub().changeinflag();

            return NoContent();
        }*/

        public IActionResult Index()
        {
            HttpClient client = new HttpClient();

            var URL = _configuration.GetValue<string>("ServerURL:serverEdnpoint");

            HttpResponseMessage message =  client.GetAsync($"{URL}/api/material").Result;

            IEnumerable<MaterialViewModel> material = null;
            if (message.IsSuccessStatusCode)
            {
                material = message.Content.ReadAsAsync<IEnumerable<MaterialViewModel>>().Result;
              
            }

            ViewBag.BaseURL = URL; 
            return View(material);

        }



    }
}
