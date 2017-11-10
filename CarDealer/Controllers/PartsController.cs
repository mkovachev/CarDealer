using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Web.Controllers
{
    public class PartsController : Controller
    {
        public IActionResult All()
        {
            return View();
        }
    }
}