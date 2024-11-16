using GunvorAssessment.Exceptions;
using GunvorAssessment.LockDown;
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
        public async Task<bool> IsAmountMoreThanBalance(decimal requestedAmount) => (requestedAmount > (base._balance*(decimal).10));
        public override async Task WithdrawAsync(decimal amount)
        {
            if (await IsBalanceLessThanZero(amount))
                throw new ExceedOverDraftLimit();

            if (await IsAmountMoreThanBalance(amount))
                throw new GunvorAssessment.Exceptions.AmountmoreThanBalance();

            await base.WithdrawAsync(amount);
        }







    }
}

