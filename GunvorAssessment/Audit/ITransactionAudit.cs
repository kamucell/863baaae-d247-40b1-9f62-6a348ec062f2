using System.Collections.Generic;
using System.Threading.Tasks;

namespace GunvorAssessment.Audit
{
	/// <summary>
	/// This interface is used to write account transactions and retrieve transactions
	/// </summary>
	/// <remarks>
	///	You CANNOT modify this file
	/// </remarks>

	public interface ITransactionAudit
	{
		/// <summary>
		/// Gets a list of transactions for the specified account
		/// </summary>
		Task<IEnumerable<Transaction>> GetAccountTransactionsAsync(int accountNumber);

		/// <summary>
		/// Writes a transaction
		/// </summary>
		Task WriteTransactionAsync(Transaction transaction);
	}
}
