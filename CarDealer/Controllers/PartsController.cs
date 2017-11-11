using CarDealer.Services.Contracts;
using CarDealer.Services.ServiceModels.Parts;
using CarDealer.Web.ViewModels.PartsViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CarDealer.Web.Controllers
{
    [Route("parts")]
    public class PartsController : Controller
    {
        private const int PageSize = 25;

        private readonly IPartService parts;

        public PartsController(IPartService parts) => this.parts = parts;

        [Route(nameof(All))]
        public IActionResult All(int page = 1)
            => View(new PartPaginationViewModel
            {
                Parts = this.parts.GetAllParts(page, PageSize),
                Current = page,
                TotalPages = (int)Math.Ceiling(this.parts.TotalPages() / (double) PageSize)
                
            });

        [Route(nameof(Add))]
        public IActionResult Add(int id)
        {
            return View();
        }

        [HttpPost]
        [Route(nameof(Add))]
        public IActionResult Add(int id, PartExtendedServiceModel model)
        {
            return View();
        }

        [Route(nameof(Edit) + "/{id}")]
        public IActionResult Edit(int id)
        {
            var part = this.parts.GetPartById(id);

            if (part == null)
            {
                return NotFound();
            }

            return View(new PartExtendedServiceModel
            {
                Name = part.Name,
                Price = part.Price,
                Supplier = part.Supplier,
                Quantity = part.Quantity
            });
        }

        [HttpPost]
        [Route(nameof(Edit) + "/{id}")]
        public IActionResult Edit(int id, PartExtendedServiceModel model)
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