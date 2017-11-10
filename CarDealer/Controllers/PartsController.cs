using CarDealer.Services.Contracts;
using CarDealer.Services.ServiceModels.Parts;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Web.Controllers
{
    [Route("parts")]
    public class PartsController : Controller
    {
        private readonly IPartService parts;

        public PartsController(IPartService parts) => this.parts = parts;

        [Route(nameof(All))]
        public IActionResult All(int page = 1) => View(this.parts.GetAllParts(page));

        [Route(nameof(Edit) + "/{id}")]
        public IActionResult Edit(int id)
        {
            var part = this.parts.GetPartById(id);

            if (part == null)
            {
                return NotFound();
            }

            return View(new PartListingServiceModel
            {
                Name = part.Name,
                Price = part.Price,
                Supplier = part.Supplier,
                Quantity = part.Quantity
            });
        }

        [HttpPost]
        [Route(nameof(Edit) + "/{id}")]
        public IActionResult Edit(int id, PartListingServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.parts.Edit(
                id,
                model.Name,
                model.Price,
                model.Supplier,
                model.Quantity = 1
                );

            return RedirectToAction(nameof(All));
        }
    }
}