using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRateBot.Library.Models
{
    /// <summary>
    /// Represents an input exchanre rate request.
    /// </summary>
    public class InputRequest : IInputRequest
    {
        public string Currency { get; set; }
        public string Country { get; set; }
        public string Date { get; set; }
    }
}
