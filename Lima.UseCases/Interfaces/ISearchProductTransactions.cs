using Lima.Businuess;

namespace Lima.UseCases.Interfaces
{
    public interface ISearchProductTransactions
    {
        Task<IEnumerable<ProductTransaction>> ExecuteAsync(string productName, DateTime? dateFrom, DateTime? dateTo, ProductTransactionType? transactionType);
    }
}