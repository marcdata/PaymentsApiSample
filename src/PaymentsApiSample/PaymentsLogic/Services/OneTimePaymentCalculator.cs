using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentsLogic.Services
{
    public class OneTimePaymentCalculator
    {
        public (decimal balanceRemaining, DateTime nextPaymentDate, decimal matchAmount) MakeOneTimePayment(decimal paymentAmount, DateTime paymentDate, decimal beginningBalance, bool? useMatch = true)
        {
            var matchAmount = useMatch.Value ? CalculateMatchAmount(paymentAmount) : 0m;
            var balanceRemaining = beginningBalance - paymentAmount - matchAmount;

            if(balanceRemaining < 0)
            {
                throw new InvalidOperationException($"Payment and match would result in overpay.");
                // Check with PM or SME to see how should be handled. 
            }

            var nextPaymentDate = paymentDate.AddDays(15);
            while(nextPaymentDate.DayOfWeek == DayOfWeek.Saturday || nextPaymentDate.DayOfWeek == DayOfWeek.Sunday)
            {
                nextPaymentDate = nextPaymentDate.AddDays(1);
            }

            return (balanceRemaining, nextPaymentDate, matchAmount);
        }

        private decimal CalculateMatchAmount(decimal amount)
        {
            var percentMatch = amount switch
            {
                _ when (amount > 0m && amount < 10.0m) => 0.01m,
                _ when 10 <= amount & amount < 50 => 0.03m,
                _ when amount >= 50 => 0.05m,
                _ => throw new ArgumentOutOfRangeException(nameof(amount), $"No match amount defined for amount; check sign.")
            };

            return percentMatch * amount;
        }
    }
}
