using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Phd.Controllers
{
    public class DicsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}