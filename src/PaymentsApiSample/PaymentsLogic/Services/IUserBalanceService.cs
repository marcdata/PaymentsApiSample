using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsLogic.Services
{
    public interface IUserBalanceService
    {
        public Task<decimal> GetBalanceForUser(int userId);
    }
}
