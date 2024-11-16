using System.Threading.Tasks;

namespace GunvorAssessment.Account
{
	/// <summary>
	/// This interface is used to expose account functionality
	/// </summary>
	/// <remarks>
	///	You CANNOT modify this file
	/// </remarks>
	public interface IAccount
	{
		int AccountNumber { get; }
		/// <summary>
		/// This should be a negative number when different from zero
		/// </summary>
		decimal OverdraftLimit { get; set; }
		decimal Balance { get; }
		Task DepositAsync(decimal amount);
		Task WithdrawAsync(decimal amount);
	}
}