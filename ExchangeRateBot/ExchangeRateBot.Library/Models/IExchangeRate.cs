using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRateBot.Library.Models
{
    public interface IExchangeRate
    {
        decimal GetRate();
        string GetHomeCurrency();
        string GetTargetCurrency();
    }
}
