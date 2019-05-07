using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiNBP.Services.Currency.Model
{
    public class CurrencyObject
    {
        public string Code { get; set; } //Code
        public string CourseNumber { get; set; } //No
        public string EffectiveDate { get; set; } //EffectiveDate

        [DisplayFormat(DataFormatString = "{0:n4}")]
        public decimal CurrencyValue { get; set; } //Mid
    }
}
