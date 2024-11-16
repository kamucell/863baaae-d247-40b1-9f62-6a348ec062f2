using System;
using System.Collections.Generic;
using System.Security.Principal;
using GunvorAssessment.Account;
using GunvorAssessment.Audit;
using GunvorAssessment.DateService;
using GunvorAssessment.Exceptions;
using GunvorAssessment.LockDown;

namespace GunvorAssessment
{
	public enum AccountType
	{
		Current = 0,
		Saving = 1
	}
    
    /// <summary>
    /// This class creates instance of other class. The instance is guaranteed to stay the same for the duration of the test
    /// </summary>
    /// <remarks>
    /// You MUST modify this class as you see fit
    /// </remarks>
    public class GlobalFactory : IGlobalFactory
	{
		private ILockDownManager _lockDownManager;
        private ITransactionAudit _transactionAudit;
        public GlobalFactory()
        {
            
        }
        public IAccount GetAccount(AccountType type, int accountNumber)
		{
			IAccount account = null;
				

            if (type == AccountType.Current)
				account = new GunvorAssessment.Account.CurrentAccount(accountNumber);
			else if (type == AccountType.Saving)
                account = new GunvorAssessment.Account.SavingAccount(accountNumber);
			else
			   throw new GunvorAssessmentException("Invalid Account  Type");

			account.SetAudit(GetAudit());
            account.SetLock(GetLockDownManager());
			return account;
        }

		public ITransactionAudit GetAudit()
		{
            if (_transactionAudit == null) _transactionAudit = new TransactionAudit();
            return _transactionAudit;
            
		}

		public ILockDownManager GetLockDownManager()
		{
			if (_lockDownManager == null) 	_lockDownManager = new LockDownManager();
			return _lockDownManager;
		}
		public IDateService GetDateService()
		{
            throw new NotImplementedException();
        }
	}
}