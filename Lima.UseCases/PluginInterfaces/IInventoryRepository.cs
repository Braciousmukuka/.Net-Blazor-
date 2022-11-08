using Lima.Businuess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lima.UseCases.PluginInterfaces
{
    //This is the interface for the Innventory class
    public interface IInventoryRepository
    {
        Task<Inventory?> GetInventoryAsync(int inventoryId);
        Task AddInventoryAsync(Inventory inventory);

        // This method selects an inventory item by name
        Task<IEnumerable<Inventory>> GetInventories(string name);

        Task UpdateInventoryAsync(Inventory inventory);
    }
}
