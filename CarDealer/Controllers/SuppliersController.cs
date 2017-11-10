using CarDealer.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Web.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISupplierService suppliers;

        public SuppliersController(ISupplierService suppliers) => this.suppliers = suppliers;

        [Route("suppliers/{type}")]
        public IActionResult ByType(string type)
        {       
            var suppliersByType = this.suppliers.GetSuppliersByType(type);

            return View(suppliersByType);
        }
    }
}