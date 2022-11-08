using Lima.Businuess;

namespace Lima.UseCases.Interfaces
{
    public interface IEditInventory
    {
        Task ExecuteAsync(Inventory inventory);
    }
}