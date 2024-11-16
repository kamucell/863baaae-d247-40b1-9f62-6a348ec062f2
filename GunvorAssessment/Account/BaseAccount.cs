using GunvorAssessment.Audit;
using GunvorAssessment.Exceptions;
using GunvorAssessment.LockDown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunvorAssessment.Account
{
    public abstract class BaseAccount : IAccount
    {
        private bool _isLocked = false;
        protected int _accountNumber { get; }
        public int AccountNumber => _accountNumber;
        protected decimal _balance;
        private ITransactionAudit _transactionAudit;
        private   ILockDownManager _lockDownManager;

        public decimal Balance => _balance;
        
        public decimal OverdraftLimit { get; set; }

        public BaseAccount(int accountNumber )    {
            if (accountNumber <= 0)
                throw new GunvorAssessmentException("Account number is invalid");

            _accountNumber=accountNumber;
            
     
        }

        public void SetAudit(ITransactionAudit transactionAudit) =>            _transactionAudit = transactionAudit;
        public void SetLock(ILockDownManager lockDownManager) {
            _lockDownManager = lockDownManager;
            _lockDownManager.LockDownStarted += (s,e)=>_isLocked=true;
            _lockDownManager.LockDownEnded += (s, e) => _isLocked = false;
        }

        private void _lockDownManager_LockDownStarted(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public   async Task<bool> IsRequestedAmountHighrThanZero(decimal requestedAmount) =>  (requestedAmount > 0);
 

        public async   Task DepositAsync(decimal amount)
        {
            if (_isLocked)
                throw new GunvorAssessment.Exceptions.UnauthorizedAccountOperationException("Account has been locked");
                 
            if(!   await IsRequestedAmountHighrThanZero(amount)) 
                    throw new GunvorAssessment.Exceptions.AmountLessThanZero();
              
            _balance += amount;
            await _transactionAudit.WriteTransactionAsync(new Transaction()
            {
                AccountId = _accountNumber,
                Id= Guid.NewGuid(),
                TransactionDate = DateTime.UtcNow,
                TransactionType = TransactionType.Deposit,
            });

        }

        public async virtual Task WithdrawAsync(decimal amount)
        {
            if (_isLocked)
                throw new GunvorAssessment.Exceptions.UnauthorizedAccountOperationException("Account has been locked");

            if (!await IsRequestedAmountHighrThanZero(amount))
                throw new GunvorAssessment.Exceptions.AmountLessThanZero();

            _balance -= amount;
            await _transactionAudit?.WriteTransactionAsync(new Transaction()
            {
                AccountId = _accountNumber,
                Id = Guid.NewGuid(),
                TransactionDate = DateTime.UtcNow,
                TransactionType = TransactionType.Withdraw,
            });
        }

       
    }
}
