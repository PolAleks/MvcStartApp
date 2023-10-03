using Microsoft.AspNetCore.Mvc;
using MvcStartApp.BLL.Services;
using MvcStartApp.DAL.Interfaces;
using MvcStartApp.Models.Db;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvcStartApp.Controllers
{
    public class LogsController : Controller
    {
        private readonly IRequestServices _requestService;
        public LogsController(IRequestServices requestService)
        {
            _requestService = requestService;
        }

        public async Task<IActionResult> Index()
        {
            var request = await _requestService.GetRequestAsync();
            if (request.StatusCode == BLL.Services.StatusCode.OK)
            {
                return View(request.Data);
            }
            return RedirectToAction("Error");
        }
    }
}
