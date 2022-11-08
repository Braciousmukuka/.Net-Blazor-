using Lima.Businuess;
using Lima.UseCases.Interfaces;
using Lima.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lima.UseCases.Inventories
{
    public class EditInventory : IEditInventory
    {
        private readonly IInventoryRepository inventoryRepository;

        public EditInventory(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }
        public async Task ExecuteAsync(Inventory inventory)
        {
            await inventoryRepository.UpdateInventoryAsync(inventory);
        }
    }
}
