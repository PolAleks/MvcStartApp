using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Models.Context;
using MvcStartApp.Models.Db;
using System.Threading.Tasks;
using System;

namespace MvcStartApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IBlogRepository _repo;

        public UsersController(IBlogRepository userRepository)
        {
            _repo = userRepository;
        }
        public async Task<IActionResult> Index()
        {
            var authors = await _repo.GetUsers();
            return View(authors);
        }

        // GET
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }
        // POST
        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            await _repo.AddUser(user);
            return View(user);
        }
    }
}
