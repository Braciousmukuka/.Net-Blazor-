using Lima.Businuess;

namespace Lima.UseCases.Interfaces
{
    public interface IPurchaseInventory
    {
        Task ExecuteAsync(string poNumber, Inventory inventory, int quantity, string doneBy);
    }
}