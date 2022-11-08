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
    public class ViewInvById : IViewInvById
    {
        private readonly IInventoryRepository inventoryRepository;

        public ViewInvById(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }
        public async Task<Inventory?> ExecuteAsync(int inventoryId)
        {
            return await inventoryRepository.GetInventoryAsync(inventoryId);
        }

    }
}
