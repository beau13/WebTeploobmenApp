using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebTeploobmenApp.Data;
using WebTeploobmenApp.Models;

namespace WebTeploobmenApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TeploobmenContext _context;

        public HomeController(ILogger<HomeController> logger, TeploobmenContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Variants.ToList());
        }

        public IActionResult Parameters(int id)
        {
            Variant variant = _context.Variants.Find(id) ?? new Variant();
            Formulas.Data data = variant;
            return View(data);
        }

        public IActionResult Calc(CalcViewModel viewModel)
        {
            int yCount = viewModel.H0 * 2 + 1;
            double[,] result = new double[yCount, 8];

            Func<Formulas.Data, double, double>[] funcs =
            {
                Formulas.CalcY,
                Formulas.Calc1exp,
                Formulas.Calc1mexp,
                Formulas.CalcV,
                Formulas.CalcO,
                Formulas.CalcTMat,
                Formulas.CalcTGas,
                Formulas.CalcTDifference,
            };

            for (int i = 0; i < 8; i++)
            {
                for (int y = 0; y < yCount; y++)
                {
                    result[y, i] = Math.Round(funcs[i](viewModel, y / 2.0), 2);
                }
            }

            viewModel.ResultTable = result;

            _context.Variants.Add(new Variant(viewModel));
            _context.SaveChanges();

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
