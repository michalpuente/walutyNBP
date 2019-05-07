using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiNBP.Models;
using WebApiNBP.Services.Currency;
using WebApiNBP.Services.Currency.Model;

namespace WebApiNBP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICurrencyDataObject _currencyDataObject;

        public HomeController(ICurrencyDataObject currencyDataObject)
        {
            _currencyDataObject = currencyDataObject;
        }

        public IActionResult Index(string currency, int? count)
        {
            if (currency == null)
            {
                currency = "eur";
            }

            DateTime todayDate = DateTime.Now;
            var monthStart = new DateTime(todayDate.Year, todayDate.Month, 1);

            List<CurrencyObject> currencyList;

            ViewBag.Currency = currency.ToUpper(); //np. EUR, USD
            ViewBag.NumberOfDays = count;

            if (count.HasValue)
            {
                currencyList = _currencyDataObject.GetLastDays(currency.ToLower(), (int)count);
                ViewBag.CourseName = $"Ostatnie {count} odczytów";
                ViewBag.Radio = 2;
            }
            else
            {
                currencyList = _currencyDataObject.GetDateFromTo(currency.ToLower(), monthStart, todayDate);
                ViewBag.CourseName = "Kursy z bieżącego miesiąca";
                ViewBag.Radio = 1;
            }

            return View(currencyList);
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
