using GunvorAssessment.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunvorAssessment.Account
{
    public class SavingAccount : BaseAccount
    {
        public SavingAccount(int accountNumber) : base(accountNumber)
        {

        }



        public async Task<bool> IsBalanceLessThanZero(decimal requestedAmount) => (_balance- requestedAmount <= 0);

        public async Task<bool> IsAmountMoreThan(decimal requestedAmount) => (requestedAmount > (base._balance*(decimal).10));
        public override async Task WithdrawAsync(decimal amount)
        {
            if (await IsBalanceLessThanZero(amount))
                throw new GunvorAssessment.Exceptions.UnauthorizedAccountOperationException("The limit has been exceeded.");

            if (await IsAmountMoreThan(amount))
                throw new GunvorAssessment.Exceptions.UnauthorizedAccountOperationException("Ca nnot withdraw than you blaance");

            await base.WithdrawAsync(amount);
        }







    }
}

