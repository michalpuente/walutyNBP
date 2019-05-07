using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiNBP.API;
using WebApiNBP.Services.Currency.Model;

namespace WebApiNBP.Services.Currency.Impl
{
    public class CurrencyDataObject : ICurrencyDataObject
    {
        RestClient client = new RestClient();

        public List<CurrencyObject> GetLastDays(string curr, int days)
        {
            client.endPoint = $"http://api.nbp.pl/api/exchangerates/rates/A/{curr}/last/{days}?format=json";

            string myResponse = client.MakeRequest();
            dynamic jsonObject = JsonConvert.DeserializeObject(myResponse);

            var currencyCourse = new List<CurrencyObject>();

            CurrencyObject c;

            int i = 0;
            foreach (var item in jsonObject.rates)
            {
                c = new CurrencyObject
                {
                    Code = curr.ToUpper(),
                    CourseNumber = jsonObject.rates[i].no,
                    EffectiveDate = jsonObject.rates[i].effectiveDate,
                    CurrencyValue = decimal.Parse(jsonObject.rates[i].mid.ToString())
                };
                currencyCourse.Add(c);
                i++;
            }

            return currencyCourse.OrderBy(x=>x.CurrencyValue).ToList();
        }

        public List<CurrencyObject> GetDateFromTo(string curr, DateTime dateFrom, DateTime dateTo)
        {

            string dtFrom = dateFrom.ToString("yyyy-MM-dd");
            string dtTo = dateTo.ToString("yyyy-MM-dd");


            client.endPoint = $"http://api.nbp.pl/api/exchangerates/rates/A/{curr}/{dtFrom}/{dtTo}?format=json";

            string myResponse = client.MakeRequest();
            dynamic jsonObject = JsonConvert.DeserializeObject(myResponse);

            var currencyCourse = new List<CurrencyObject>();

            CurrencyObject c;

            int i = 0;
            foreach (var item in jsonObject.rates)
            {
                c = new CurrencyObject
                {
                    Code = curr.ToUpper(),
                    CourseNumber = jsonObject.rates[i].no,
                    EffectiveDate = jsonObject.rates[i].effectiveDate,
                    CurrencyValue = decimal.Parse(jsonObject.rates[i].mid.ToString())
                };
                currencyCourse.Add(c);
                i++;
            }

            return currencyCourse.OrderBy(x => x.CurrencyValue).ToList();
        }
    }
}
