using CarDealer.Services.Contracts;
using CarDealer.Services.ServiceModels.Parts;
using CarDealer.Web.ViewModels.PartsViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace CarDealer.Web.Controllers
{
    //[Route("parts")]
    public class PartsController : Controller
    {
        private const int PageSize = 25;

        private readonly IPartService parts;
        private readonly ISupplierService suppliers;

        public PartsController(IPartService parts, ISupplierService suppliers)
        {
            this.parts = parts;
            this.suppliers = suppliers;
        }

        //[Route(nameof(All))]
        public IActionResult All(int page = 1)
            => View(new PartPaginationViewModel
            {
                Parts = this.parts.GetAllParts(page, PageSize),
                Current = page,
                TotalPages = (int)Math.Ceiling(this.parts.TotalPages() / (double)PageSize)

            });

        //[Route(nameof(Add))]
        public IActionResult Add()
        {
            // dropdown for suppliers
            return View(new PartWithSuppliersServiceModel
            {
                Suppliers = this.suppliers
                .GetAllSuppliers()
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                })
            });
        }

        [HttpPost]
        //[Route(nameof(Add))]
        public IActionResult Add(int id, PartWithSuppliersServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.parts.Add(
                 model.Name,
                 model.Price,
                 model.Quantity,
                 model.SupplierId
                 );

            return RedirectToAction(nameof(All));
        }

        //[Route(nameof(Edit) + "/{id}")]
        public IActionResult Edit(int id)
        {
            var part = this.parts.GetPartById(id);

            if (part == null)
            {
                return NotFound();
            }

            // dropdown for suppliers
            return View(new PartWithSuppliersServiceModel
            {
                Suppliers = this.suppliers
                .GetAllSuppliers()
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                })
            });
        }

        [HttpPost]
        //[Route(nameof(Edit) + "/{id}")]
        public IActionResult Edit(int id, PartWithSuppliersServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.parts.Edit(
                id,
                model.Name,
                model.Price,
                model.Quantity,
                model.SupplierId
                );

            return RedirectToAction(nameof(All));
        }

        public IActionResult Delete(int id) => View(id);

        public IActionResult DeleteFromDb(int id)
        {
            this.parts.Delete(id);

            return RedirectToAction(nameof(All));
        }
    }
}