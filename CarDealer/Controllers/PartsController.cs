using CarDealer.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Web.Controllers
{
    [Route("parts")]
    public class PartsController : Controller
    {
        private readonly IPartService parts;

        public PartsController(IPartService parts) => this.parts = parts;

        [Route(nameof(All))]
        public IActionResult All()
        {
            return View(this.parts.GetAllParts());
        }
    }
}