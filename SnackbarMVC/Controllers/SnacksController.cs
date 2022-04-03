using Microsoft.AspNetCore.Mvc;
using Snackbar.MVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Snackbar.MVC.Controllers
{
    public class SnacksController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public SnacksController(IHttpClientFactory clientFactory)
        {
            this._clientFactory = clientFactory;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<SnackViewModel> vmSnacks = null;                        // de JsonSerializer negeert de klasse naam, en matched/serialiseert alleen de properties 

            var request = new HttpRequestMessage(HttpMethod.Get, "snacks");     // 'snacks' is de naam van de controller, route/url opbouw = baseaddress + controller + param
            var client = _clientFactory.CreateClient("SnacksApi");              // 'SnacksApi'is de naam van de HttpFactory configuratie, zie StartUp en appsettings.config 
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var stream = await response.Content.ReadAsStreamAsync();
                //var jsonString = new StreamReader(stream).ReadToEnd();
                var jsonOptions = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true                          //standaard is de serializer case sensitive, met deze optie insensive
                };
                vmSnacks = await JsonSerializer.DeserializeAsync<IEnumerable<SnackViewModel>>(stream, jsonOptions);
            }
            else
            {
                vmSnacks = new List<SnackViewModel>();
            }

            return View(vmSnacks);
        }
    }
}
