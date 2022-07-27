using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsLogic.Services
{
    public class StubUserBalanceService : IUserBalanceService
    {
        /// <summary>
        /// Stub implementation. Just give back some formulatic balances for userid. Based on userId. Support demo, test.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<decimal> GetBalanceForUser(int userId)
        {
            return Task.FromResult<decimal>(100 * userId);
        }
    }
}
