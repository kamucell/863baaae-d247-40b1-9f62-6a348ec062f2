using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunvorAssessment.Audit
{
    public class TransactionAudit : ITransactionAudit
    {
        private Dictionary<int, List<Transaction>> _transactions;
        public TransactionAudit()
        {
            _transactions = new Dictionary<int, List<Transaction>>();
        }
        public async Task<IEnumerable<Transaction>> GetAccountTransactionsAsync(int accountNumber) =>
                                                                            (_transactions.ContainsKey(accountNumber)) ? 
                                                                                                await Task.FromResult(_transactions[accountNumber]):
                                                                                                Enumerable.Empty<Transaction>();
            


        public Task WriteTransactionAsync(Transaction transaction)
        {
            if (!_transactions.ContainsKey(transaction.AccountId))
                _transactions.Add(transaction.AccountId, new List<Transaction>() { 
                        transaction
                });
            else
                _transactions[transaction.AccountId].Add(transaction);
            return Task.CompletedTask;

            
        }
    }
}
