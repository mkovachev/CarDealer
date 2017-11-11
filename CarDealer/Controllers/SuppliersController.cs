using CarDealer.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Web.Controllers
{
    [Route("suppliers")]
    public class SuppliersController : Controller
    {
        private readonly ISupplierService suppliers;

        public SuppliersController(ISupplierService suppliers) => this.suppliers = suppliers;

        [Route("{supplierType}")]
        public IActionResult ByType(string supplierType)
        {       
            var suppliersByType = this.suppliers.GetSuppliersByType(supplierType);

            return View(suppliersByType);
        }
    }
}