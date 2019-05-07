using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiNBP.Services.Currency;
using WebApiNBP.Services.Currency.Impl;

namespace WebApiNBP.IoC
{
    public static class MyIoCInstaller
    {
        public static void AddMyServices(this IServiceCollection services)
        {
            services.AddTransient<ICurrencyDataObject, CurrencyDataObject>();
        }
    }
}
