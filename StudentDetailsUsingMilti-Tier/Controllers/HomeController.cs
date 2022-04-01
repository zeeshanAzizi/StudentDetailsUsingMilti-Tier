using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentDetailsUsingMilti_Tier.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BussinessLayer;
using CommonLayer.Models;
namespace StudentDetailsUsingMilti_Tier.Controllers
{
    public class HomeController : Controller
    {
        private StudentBussiness bussiness = new StudentBussiness();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            
            _logger = logger; 
        }

        public IActionResult Index()
        {
            var std = bussiness.GetStudents();
            return View(std);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            var res = bussiness.CreateStudent(student);
            if (res)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("error", "Error in create Employee!");
                return View(student);
            }
        }
        public IActionResult Delete(int id)
        {
            var std = bussiness.DeleteStudent(id);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var std = bussiness.GetStudentsById(id);
            return View(std);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            var std = bussiness.UpdateStudent(student);
            if (std)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("error", "Error in Updating Employee!");
                return View(student);

            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
