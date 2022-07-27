using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentsLogic.Views
{
    public class OneTimePaymentView
    {
        public decimal BeginningBalance { get; set; }
        public decimal PaymentAmount { get; set; }
        public decimal Adjustments { get; set; }
        public decimal BalanceRemaining { get; set; }
        public DateTime NextPaymentDate { get; set; }

    }
}
