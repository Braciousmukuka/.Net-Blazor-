using Lima.Businuess;
using Lima.UseCases.Interfaces;
using Lima.UseCases.PluginInterfaces;

namespace Lima.UseCases.Inventories
{
    public class ViewInventory : IViewInventory
    {
        private readonly IInventoryRepository inventoryRepository;

        public ViewInventory(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }
        public async Task<IEnumerable<Inventory>> ExecuteAsync(string name = "")
        {
            return await inventoryRepository.GetInventories(name);

        }

    }
}