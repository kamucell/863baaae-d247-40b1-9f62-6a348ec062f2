using GunvorAssessment.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunvorAssessment.Account
{
    public class CurrentAccount : BaseAccount
    {

        public CurrentAccount(int accountNumber) : base(accountNumber)
        {

        }
        public async Task<bool> IsDoNotExceededOverDraftLimit(decimal requestedAmount) => (_balance - requestedAmount < OverdraftLimit);

        public override async Task WithdrawAsync(decimal amount)
        {
            if (await IsDoNotExceededOverDraftLimit(amount))                 throw new UnauthorizedAccountOperationException("The limit has been exceeded.");

            await base.WithdrawAsync(amount);
        }





    }
}
