using System;
using System.Collections.Generic;
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
		public IAccount GetAccount(AccountType type, int accountNumber)
		{
			if (type == AccountType.Current)
				return new GunvorAssessment.Account.CurrentAccount(accountNumber);

			if (type == AccountType.Saving)
				return new GunvorAssessment.Account.SavingAccount(accountNumber);


			throw new GunvorAssessmentException(" Invalid Daata Type");
			
        }

		public ITransactionAudit GetAudit()
		{
			throw new NotImplementedException();
		}

		public ILockDownManager GetLockDownManager()
		{
			return new LockDownManager();
		}
		public IDateService GetDateService()
		{
			throw new NotImplementedException();
		}
	}
}