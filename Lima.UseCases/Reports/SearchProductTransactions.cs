using Lima.Businuess;
using Lima.UseCases.Interfaces;
using Lima.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lima.UseCases.Reports
{
    public class SearchProductTransactions : ISearchProductTransactions
    {
        private readonly IProductTransactionRepository productTransactionRepository;

        public SearchProductTransactions(IProductTransactionRepository productTransactionRepository)
        {
            this.productTransactionRepository = productTransactionRepository;
        }

        public async Task<IEnumerable<ProductTransaction>> ExecuteAsync(
            string productName,
            DateTime? dateFrom,
            DateTime? dateTo,
            ProductTransactionType? transactionType)
        {
            return await this.productTransactionRepository.GetProductTransactionsAsync(
                productName,
                dateFrom,
                dateTo,
                transactionType);
        }


    }
}
