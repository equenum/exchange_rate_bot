using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRateBot
{
    /// <summary>
    /// Represents a list of supported countries.
    /// </summary>
    public enum SupportedContries
    {
        BY,
        UA
    }

    /// <summary>
    /// Represents a list of supported currencies fo Ukraine.
    /// </summary>
    public enum SupportedCurrenciesUA 
    {
        AZN,
        BYN,
        BYR,
        CHF,
        CNY,
        CZK,
        DKK,
        EUR,
        GBP,
        HUF,
        ILS,
        JPY,
        KZT,
        MDL,
        NOK,
        PLZ,
        RUB,
        SEK,
        SGD,
        TMT,
        TRY,
        UAH,
        USD,
        UZS,
        GEL
    }

    /// <summary>
    /// Represents a list of supported currencies fo Belarus.
    /// </summary>
    public enum SupportedCurrenciesBY
    {
        AZN,
        UAH,
        CHF,
        CNY,
        CZK,
        DKK,
        EUR,
        GBP,
        HUF,
        ILS,
        JPY,
        KZT,
        MDL,
        NOK,
        PLZ,
        RUB,
        RUR,
        SEK,
        SGD,
        TMT,
        TRY,
        USD,
        UZS,
        GEL
    }

    /// <summary>
    /// Represents a list of command strategy command types.
    /// </summary>
    public enum CommandType
    { 
        ExchangeRate,
        Help,
        Now,
        ShowCurrListBY,
        ShowCurrListUA,
        Start
    }
}
