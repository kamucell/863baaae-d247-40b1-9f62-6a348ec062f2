using GunvorAssessment.DateService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunvorAssessment.Audit
{
    public class TransactionAudit : ITransactionAudit
    {
        private readonly IDateService _dateService;
        private Dictionary<int, List<Transaction>> _transactions;
        public TransactionAudit(IDateService dateService)
        {
            _transactions = new Dictionary<int, List<Transaction>>();
            _dateService = dateService;
        }
        public async Task<IEnumerable<Transaction>> GetAccountTransactionsAsync(int accountNumber) =>
                                                                            (_transactions.ContainsKey(accountNumber)) ? 
                                                                                                await Task.FromResult(_transactions[accountNumber]):
                                                                                                Enumerable.Empty<Transaction>();
            


        public Task WriteTransactionAsync(Transaction transaction)
        {
            transaction.Id =Guid.NewGuid();
            transaction.TransactionDate = _dateService.GetCurrentDateTime();
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
