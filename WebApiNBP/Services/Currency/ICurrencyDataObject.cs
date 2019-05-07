using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiNBP.Services.Currency.Model;

namespace WebApiNBP.Services.Currency
{
    public interface ICurrencyDataObject
    {
        List<CurrencyObject> GetLastDays(string curr, int days);
        List<CurrencyObject> GetDateFromTo(string curr, DateTime dateFrom, DateTime dateTo);
    }
}
