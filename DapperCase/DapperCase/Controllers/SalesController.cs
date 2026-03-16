using DapperCase.Services;
using Microsoft.AspNetCore.Mvc;

namespace DapperCase.Controllers
{
    public class SalesController : Controller
    {
        private readonly ISalesService _salesService;

        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var values = await _salesService.GetPagedSales(page, 20);
            return View(values);
        }
    }
}