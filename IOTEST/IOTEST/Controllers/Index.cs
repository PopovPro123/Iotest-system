﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IOTEST.Controllers
{
    [Route("/")]
    public class IndexController : Controller
    {
        public IActionResult Index()
        {
            ViewData.Add("Title", "IOTEST");

            return View();
        }
    }
}
