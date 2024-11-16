using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GunvorAssessment;
using GunvorAssessment.Audit;
using NUnit.Framework;

namespace GunvorAssessmentTests
{
	/// <summary>
	/// This class contains all the Unit Tests related to Transactions audit
	/// </summary>
	/// <remarks>
	/// YOU SHOULD NOT CHANGE THIS CLASS
	/// </remarks>
	[TestFixture]
	public class TransactionAuditTests
	{
		private ITransactionAudit _audit;

		/// <summary>
		/// This test verifies that each transaction is uniquely recorded and can be retrieved via the transaction audit
		/// </summary>
		[Test]
		public async Task GetTransactions_ForAccount_ShouldGetMatchingTransactions()
		{
			var account = Container.Factory.GetAccount(AccountType.Current, 3333);
			await account.DepositAsync(2000);
			await account.WithdrawAsync(500);
			await account.WithdrawAsync(200);
			await account.WithdrawAsync(100);
			var transactions = (await _audit.GetAccountTransactionsAsync(account.AccountNumber)).ToList();
			Assert.AreEqual(4, transactions.Count, "There should be 4 transactions");
			Assert.AreEqual(4, transactions.Select(x => x.Id).Distinct().Count(), "There should be 4 unique transactions");
		}

		/// <summary>
		/// This test verifies that each transaction has a valid type assigned to it
		/// </summary>
		[Test]
		public async Task GetTransactions_ForAccount_ShouldRecordCorrectType()
		{
			var account = Container.Factory.GetAccount(AccountType.Current, 3333);
			await account.DepositAsync(2000);
			await account.WithdrawAsync(500);
			await account.WithdrawAsync(200);
			await account.WithdrawAsync(100);
			var transactions = (await _audit.GetAccountTransactionsAsync(account.AccountNumber)).ToList();
			Assert.AreEqual(2, transactions.Select(x => x.TransactionType).Distinct().Count(), "There should be only 2 types of transactions that occured on this account");
		}

		[Test]
		public async Task WhenTransactionCreated_ItUseDateService()
		{
			var account = Container.Factory.GetAccount(AccountType.Current, 3333);
			await account.DepositAsync(2000);
			await Task.Delay(1);
			await account.WithdrawAsync(500);
			await Task.Delay(1);
			await account.WithdrawAsync(500);

			var dates = (await _audit.GetAccountTransactionsAsync(account.AccountNumber)).Select(t => t.TransactionDate.Ticks).GroupBy(d => d);
			Assert.AreEqual(3, dates.Take(3).Count());
		}

		[Test]
		public void Subject_IsSingleton()
		{
			Assert.AreEqual(Container.Factory.GetAudit(), _audit);
		}

		[SetUp]
		public void SetUp()
		{
			Container.Initialize();
			_audit = Container.Factory.GetAudit();
		}
	}
}
