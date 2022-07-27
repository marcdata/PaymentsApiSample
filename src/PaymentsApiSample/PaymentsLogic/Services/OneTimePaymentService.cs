using PaymentsLogic.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsLogic.Services
{
    public interface IOneTimePaymentService
    {
        public Task<OneTimePaymentView> PostPayment(int userId, decimal amount);
    }

    public class OneTimePaymentService : IOneTimePaymentService
    {
        IUserBalanceService _userBalanceService;

        public OneTimePaymentService(
            IUserBalanceService userBalanceService
            )
        {
            _userBalanceService = userBalanceService ?? throw new ArgumentNullException(nameof(userBalanceService));
        }

        public async Task<OneTimePaymentView> PostPayment(int userId, decimal amount)
        {
            // Steps. 
            // Get balance for user.
            // Calculate remaining balance from prospective payment
            // TODO: decrement actual balance, actual post/persist the transaction
            // return viewdata to caller.

            if(amount <= 0)
            {
                throw new InvalidOperationException($"Amount to be paid is zero or less than zero. Amount: {amount}.");
            }

            var userBalance = await _userBalanceService.GetBalanceForUser(userId);

            var calculator = new OneTimePaymentCalculator();
            (var balanceRemaining, var nextPaymentDate, var matchAmount) = calculator.MakeOneTimePayment(amount, DateTime.Now.Date, userBalance);

            return new OneTimePaymentView
            {
                BeginningBalance = userBalance,
                BalanceRemaining = balanceRemaining,
                NextPaymentDate = nextPaymentDate,
                PaymentAmount = amount,
                Adjustments = matchAmount
            };
        }
    }
}
