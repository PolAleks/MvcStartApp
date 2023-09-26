using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Models.Context;
using MvcStartApp.Models.Db;
using System.Threading.Tasks;

namespace MvcStartApp.Controllers
{
    public class LogsController : Controller
    {
        private readonly ILoggerRepository _logger;
        public LogsController(ILoggerRepository logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            Request[] request = await _logger.GetLogData();
            return View(request);
        }
    }
}
