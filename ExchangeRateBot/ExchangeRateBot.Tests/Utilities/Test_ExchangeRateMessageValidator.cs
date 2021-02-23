using ExchangeRateBot.Library.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRateBot.Tests.Utilities
{
    [TestClass]
    public class Test_ExchangeRateMessageValidator
    {
        [DataRow("@test /test USD 2010-01-01", true, null)]
        [DataRow("@test /test USD 1996-01-01 BY", true, null)]
        [DataRow("@test /test USD 1996-01-01 BY", true, null)]
        [DataRow("@test /test USD 2010-01-01 BY", true, null)]
        [DataRow("@test /test PPP 1996-01-01 BY", false, "Invalid currency code!")]
        [DataRow("@test /test PPP 2010-01-01 UA", false, "Invalid currency code!")]
        [DataRow("@test /test USD 1950-01-01 BY", false, "Invalid date!")]
        [DataRow("@test /test USD 2010-50-01 BY", false, "Invalid date!")]
        [DataRow("@test /test USD 2010-01-50 BY", false, "Invalid date!")]
        [DataRow("@test /test USD 1950-01-01 UA", false, "Invalid date!")]
        [DataRow("@test /test USD 2010-50-01 UA", false, "Invalid date!")]
        [DataRow("@test /test USD 2010-01-50 UA", false, "Invalid date!")]
        [DataTestMethod]
        public void ExchangeRateMessageValidator_Validate_ValidatesMessages(string message, bool expected, string expectedErrorMessage)
        {
            // Arrange
            var messageValidator = new ExchangeRateMessageValidator();

            // Act
            messageValidator.SetNewInputRequest(message);
            bool actual = messageValidator.Validate();
            string actualErrorMessage = messageValidator.GetErrorMessage();

            // Assert
            Assert.AreEqual(actual, expected);
            Assert.AreEqual(actualErrorMessage, expectedErrorMessage);
        }
    }
}
