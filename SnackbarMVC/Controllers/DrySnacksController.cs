using Microsoft.AspNetCore.Mvc;
using Snackbar.Core.Entities;
using Snackbar.MVC.Models;
using Snackbar.MVC.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Snackbar.MVC.Controllers
{
    public class DrySnacksController : Controller
    {
        private readonly IApiService<Snack> apiService;

        public DrySnacksController(IApiService<Snack> apiService)
        {
            this.apiService = apiService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Snack> vmSnacks = await apiService.GetAsync("snacks");
            return View(vmSnacks);
        }
    }
}
