using Microsoft.AspNetCore.Mvc;
using SnackbarMVC.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SnackbarMVC.Controllers
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
            IEnumerable<SnackViewModel> vm = null;

            var request = new HttpRequestMessage(HttpMethod.Get, "snacks");
            var client = _clientFactory.CreateClient("SnacksApi");

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                vm = await JsonSerializer.DeserializeAsync
                    <IEnumerable<SnackViewModel>>(responseStream);
            }
            else
            {
                vm = new List<SnackViewModel>(); ;
            }

            return View(vm);
        }
    }
}
