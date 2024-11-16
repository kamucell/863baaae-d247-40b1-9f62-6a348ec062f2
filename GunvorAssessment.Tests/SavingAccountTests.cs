using System.Threading.Tasks;
using GunvorAssessment;
using GunvorAssessment.Account;
using GunvorAssessment.Exceptions;
using NUnit.Framework;

namespace GunvorAssessmentTests
{
	/// <summary>
	/// This class contains all the Unit Tests related to SAVING Account
	/// </summary>
	/// <remarks>
	/// YOU SHOULD NOT CHANGE THIS CLASS
	/// </remarks>
	[TestFixture]
	public class SavingAccountTests
	{
		private IAccount _account;

		/// <summary>
		/// This Test verifies that it is possible to withdraw money as long as the balance is positive
		/// </summary>
		[Test]
		public async Task Withdraw_LessThan10PercentOfBalance_ShouldBePossible()
		{
			await _account.DepositAsync(2000);
			await _account.WithdrawAsync(150);
			Assert.AreEqual(1850, _account.Balance, "Balance should be 1850");

			await _account.WithdrawAsync(100);
			Assert.AreEqual(1750, _account.Balance, "Balance should be 1750");
		}

		/// <summary>
		/// This Test verifies that deposited or withdrawn amount must always be positive numbers
		/// </summary>
		[Test]
		public void Withdraw_NegativeAmount_ShouldThrowAnException()
		{
			Assert.CatchAsync<UnauthorizedAccountOperationException>(() => _account.WithdrawAsync(-50));
		}

		/// <summary>
		/// This Test verifies that it is not possible to withdraw more money than the available balance
		/// </summary>
		[Test]
		public void Withdraw_MoreThan10PercentOfBalance_ShouldThrowAnException()
		{
			_account.DepositAsync(2000);
			Assert.CatchAsync<UnauthorizedAccountOperationException>(() => _account.WithdrawAsync(_account.Balance * 0.2M));
		}

		[SetUp]
		public void SetUp()
		{
			Container.Initialize();
			_account = Container.Factory.GetAccount(AccountType.Saving, 2222);
		}
	}
}