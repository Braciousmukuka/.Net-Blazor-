using Lima.Businuess;

namespace Lima.UseCases.Interfaces
{
    public interface IAddInventory
    {
        Task ExecuteAsync(Inventory inventory);
    }
}