﻿using Microsoft.AspNetCore.Mvc;
using StudentPortal.Web.Models;

namespace StudentPortal.Web.Controllers
{
    public class StudentsController : Controller
    {

        public StudentsController( )
        {
            
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddStudentViewModel viewModel)
        {
            return View();
        }
    }
}
