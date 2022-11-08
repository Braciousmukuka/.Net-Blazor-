using Lima.Businuess;

namespace Lima.UseCases.Interfaces
{
    public interface IViewInvById
    {
        Task<Inventory?> ExecuteAsync(int inventoryId);
    }
}