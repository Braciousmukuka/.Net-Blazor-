using Lima.Businuess;
using Lima.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Lima.Plugins.EFCore
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly LimaContext db;

        public InventoryRepository(LimaContext db)
        {
            this.db = db;
        }
        //Implementation of interface methods
        public async Task<IEnumerable<Inventory>> GetInventories(string name)
        {
            return await this.db.Inventories.Where(x => x.InventoryName.ToLower().IndexOf(name.ToLower()) >= 0).ToListAsync();

            //return await this.db.Inventories.Where(x => x.InventoryName.Contains (name, StringComparison.OrdinalIgnoreCase) ||
            //                                         string.IsNullOrWhiteSpace(name)).ToListAsync();  
        }

        public async Task AddInventoryAsync(Inventory inventory)
        {
            //Prevents inventories from having the same name 
            if (db.Inventories.Any(x => x.InventoryName.ToLower() == inventory.InventoryName.ToLower())) return;
            this.db.Inventories.Add(inventory);
            await this.db.SaveChangesAsync();   
        }

        public async Task UpdateInventoryAsync(Inventory inventory)
        {
            //Prevents inventories from having the same name 
            // if (db.Inventories.Any(x => x.InventoryId != inventory.InventoryId &&
            //x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase))) return;

            if (db.Inventories.Any(x => x.InventoryId != inventory.InventoryId &&
                 x.InventoryName.ToLower() == inventory.InventoryName.ToLower())) return;    

            var inv = await this.db.Inventories.FindAsync(inventory.InventoryId);
            if(inv != null)
            {
                inv.InventoryName = inventory.InventoryName;   
                inv.InventoryType = inventory.InventoryType;
                inv.InventoryDescription = inventory.InventoryDescription;
                inv.Quantity = inventory.Quantity;
                inv.Price = inventory.Price;

               await db.SaveChangesAsync();
            }
        }

        public async Task<Inventory?> GetInventoryAsync(int inventoryId)
        {
            return await this.db.Inventories.FindAsync(inventoryId);
        }
    }
}