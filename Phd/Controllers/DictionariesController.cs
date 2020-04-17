using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Phd.Models;

namespace Phd.Controllers
{
    public class DictionariesController : Controller
    {
        private readonly PhdContext _context;
        public DictionariesController(PhdContext phdContext)
        {
            _context = phdContext;
        }
    }
}