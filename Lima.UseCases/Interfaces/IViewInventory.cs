using Lima.Businuess;

namespace Lima.UseCases.Interfaces
{
    public interface IViewInventory
    {
        Task<IEnumerable<Inventory>> ExecuteAsync(string name = "");
    }
}