using GunvorAssessment.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunvorAssessment.Account
{
    public abstract class BaseAccount : IAccount
    {
        protected int _accountNumber { get; }
        public int AccountNumber => _accountNumber;
        protected decimal _balance;
        public decimal Balance => _balance;
        
        public decimal OverdraftLimit { get; set; }

        public BaseAccount(int accountNumber )    {
            if (accountNumber <= 0)
                throw new GunvorAssessmentException("Account number is invalid");

            _accountNumber=accountNumber;
        }



        public   async Task<bool> IsRequestedAmountHighrThanZero(decimal requestedAmount) =>  (requestedAmount > 0);


        public async   Task DepositAsync(decimal amount)
        {
            if(!   await IsRequestedAmountHighrThanZero(amount)) throw new GunvorAssessment.Exceptions.UnauthorizedAccountOperationException("Amount Can Not Less Than Zero");
           
            _balance += amount;

        }

        public async virtual Task WithdrawAsync(decimal amount)
        {
            if (!await IsRequestedAmountHighrThanZero(amount)) throw new GunvorAssessment.Exceptions.UnauthorizedAccountOperationException();

            _balance -= amount;
        }
    }
}
