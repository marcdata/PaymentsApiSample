using PaymentsLogic.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests
{
    public class OneTimePaymentCalculatorTests
    {
        // Using strings within inline data, as literals are handled better than initialized classes or structs.
        [Theory]
        [InlineData(100, 10, "03-14-2022", 89.70, "03-29-2022")]
        [InlineData(500, 75, "04-08-2022", 421.25, "04-25-2022")]
        public void TestKnownCases(double balance, double paymentAmount, string paymentDateString, double expectedBalance, string expectedNextDateString)
        {
            var paymentDate = DateTime.Parse(paymentDateString);

            // Act
            var resultTuple = new OneTimePaymentCalculator().MakeOneTimePayment((decimal)paymentAmount, paymentDate, (decimal)balance, useMatch: true);

            // Assert
            Assert.Equal((decimal)expectedBalance, resultTuple.balanceRemaining);
            var expectedPaymentDate = DateTime.Parse(expectedNextDateString);
            Assert.Equal(expectedPaymentDate, resultTuple.nextPaymentDate);
        }

        [Fact]
        public void ExpectedFailingCase()
        {
            var balance = 100m;
            var payment = 101m;

            // act, assert
            Assert.ThrowsAny<Exception>(() => new OneTimePaymentCalculator().MakeOneTimePayment(payment, new DateTime(2022, 01, 01), balance));
        }
    }
}
