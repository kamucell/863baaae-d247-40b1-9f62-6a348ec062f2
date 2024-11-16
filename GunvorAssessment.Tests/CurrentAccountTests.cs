using System.Threading.Tasks;
using GunvorAssessment;
using GunvorAssessment.Account;
using GunvorAssessment.Exceptions;
using NUnit.Framework;

namespace GunvorAssessmentTests
{
	/// <summary>
	/// This class contains all the Unit Tests related to Current Account
	/// </summary>
	/// <remarks>
	/// YOU SHOULD NOT CHANGE THIS CLASS
	/// </remarks>
	[TestFixture]
	public class CurrentAccountTests
	{
		private IAccount _account;

		/// <summary>
		/// This Test verifies that it is possible to withdraw money as long as the account does not go over the overdraft limit
		/// </summary>
		[Test]
		public async Task Withdraw_LessThanAgreedOverdraft_ShouldBePossible()
		{
			await _account.DepositAsync(2000);
			await _account.WithdrawAsync(1000);
			Assert.AreEqual(1000, _account.Balance, "Balance should be 1000");

			await _account.WithdrawAsync(1000);
			Assert.AreEqual(0, _account.Balance, "Balance should be 0");

			await _account.WithdrawAsync(500);
			Assert.AreEqual(-500, _account.Balance, "Balance should be -500");
		}

		/// <summary>
		/// This Test verifies that it is not possible to withdraw more money than the agreed overdraft
		/// </summary>
		[Test]
		public void Withdraw_MoreThanAgreedOverdraft_ShouldThrowAnException()
		{
			Assert.CatchAsync<UnauthorizedAccountOperationException>(() => _account.WithdrawAsync(2500));
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
		/// This Test verifies that deposited or withdrawn amount must always be positive numbers
		/// </summary>
		[Test]
		public void Deposit_NegativeAmount_ShouldThrowAnException()
		{
			Assert.CatchAsync<UnauthorizedAccountOperationException>(() => _account.DepositAsync(-50));
		}

		[SetUp]
		public void SetUp()
		{
			Container.Initialize();
			_account = Container.Factory.GetAccount(AccountType.Current, 1111);
			_account.OverdraftLimit = -2000;
		}
	}
}
