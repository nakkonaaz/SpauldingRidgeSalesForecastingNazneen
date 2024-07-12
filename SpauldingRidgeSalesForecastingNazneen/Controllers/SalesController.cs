using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SpauldingRidgeSalesForecastingNazneen.Contexts;
using SpauldingRidgeSalesForecastingNazneen.Models;
using SpauldingRidgeSalesForecastingNazneen.ViewModels;
using System.Linq;
using System.Text;
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
            return View(new SalesQueryViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(SalesQueryViewModel model)
        {
            if (model.Year != 0)
            {
                var salesData = await _context.Orders
                    .Join(_context.Products,
                          order => order.OrderId,
                          product => product.OrderId,
                          (order, product) => new { order, product })
                    .Where(x => x.order.OrderDate.Year == model.Year)
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
                    .Where(x => x.order.OrderDate.Year == model.Year)
                    .SumAsync(x => x.product.Sales);

                // Calculate total sales
                var totalSales = salesData.Sum(x => x.TotalSales);
                var finalSales = totalSales - returnsData;

                model.TotalSales = finalSales;
                model.SalesData = salesData;
            }

            if (model.Percentage != 0 && model.SalesData != null)
            {
                foreach (var item in model.SalesData)
                {
                    item.IncrementedSales = item.TotalSales * (1 + (model.Percentage / 100));
                }

                model.TotalIncrementedSales = model.TotalSales * (1 + (model.Percentage / 100));
            }

            TempData["SalesData"] = JsonConvert.SerializeObject(model.SalesData);

            return View(model);
        }


        [HttpPost]
        public IActionResult DownloadCsv(SalesQueryViewModel model)
        {
            var salesData = model.SalesData;
            var builder = new StringBuilder();
            builder.AppendLine("State,Percentage Increase,Sales Value");

            foreach (var sale in salesData)
            {
                builder.AppendLine($"{sale.State},{model.Percentage},{sale.IncrementedSales}");
            }

            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "forecasted_sales.csv");
        }

        // GET: Sales/Chart
        public IActionResult Chart(int year, double percentage)
        {
            var salesDataJson = TempData["SalesData"] as string;
            var salesData = salesDataJson != null ? JsonConvert.DeserializeObject<List<SalesViewModel>>(salesDataJson) : null;

            if (salesData == null)
            {
                return RedirectToAction("Index");
            }

            foreach (var item in salesData)
            {
                item.IncrementedSales = item.TotalSales * (1 + (percentage / 100));
            }

            var chartData = new SalesChartViewModel
            {
                Year = year,
                SalesData = salesData
            };

            return View("Chart", chartData);
        }

        // GET: Sales/BreakdownChart
        public IActionResult BreakdownChart(int year, double percentage)
        {
            var salesDataJson = TempData["SalesData"] as string;
            var salesData = salesDataJson != null ? JsonConvert.DeserializeObject<List<SalesViewModel>>(salesDataJson) : null;

            if (salesData == null)
            {
                return RedirectToAction("Index");
            }

            foreach (var item in salesData)
            {
                item.IncrementedSales = item.TotalSales * (1 + (percentage / 100));
            }

            var breakdownChartData = new BreakdownChartViewModel
            {
                Year = year,
                SalesData = salesData
            };

            return View("BreakdownChart", breakdownChartData);
        }

    }
}
