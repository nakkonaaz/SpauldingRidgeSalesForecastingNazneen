using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpauldingRidgeSalesForecastingNazneen.Contexts;
using SpauldingRidgeSalesForecastingNazneen.Models;
using SpauldingRidgeSalesForecastingNazneen.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace SpauldingRidgeSalesForecastingNazneen.Controllers
{
    public class SalesController : Controller
    {
        private readonly SpauldingDbContext _context;

        public SalesController(SpauldingDbContext context)
        {
            _context = context;
        }

        // GET: Sales
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(int year)
        {
            var salesData = await _context.Orders
                .Join(_context.Products,
                      order => order.OrderId,
                      product => product.OrderId,
                      (order, product) => new { order, product })
                .Where(x => x.order.OrderDate.Year == year)
                .GroupBy(x => x.order.State)
                .Select(g => new SalesViewModel
                {
                    State = g.Key,
                    TotalSales = g.Sum(x => x.product.Sales)
                }).ToListAsync();

            var returnsData = await _context.OrdersReturns
                .Join(_context.Orders,
                      returnOrder => returnOrder.OrderId,
                      order => order.OrderId,
                      (returnOrder, order) => new { returnOrder, order })
                .Join(_context.Products,
                      combined => combined.order.OrderId,
                      product => product.OrderId,
                      (combined, product) => new { combined.returnOrder, combined.order, product })
                .Where(x => x.order.OrderDate.Year == year)
                .SumAsync(x => x.product.Sales);

            // Calculate total sales
            var totalSales = salesData.Sum(x => x.TotalSales);
            var finalSales = totalSales - returnsData;

            ViewBag.TotalSales = finalSales;
            return View("SalesDetails", salesData);
        }
    }
}
