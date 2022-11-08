using Lima.Businuess;

namespace Lima.UseCases.Interfaces
{
    public interface ISearchInventoryTransactions
    {
        Task<IEnumerable<InventoryTransaction>> ExecuteAsync(string inventoryName, DateTime? dateFrom, DateTime? dateTo, InventoryTransactionType? transactionType);
    }
}