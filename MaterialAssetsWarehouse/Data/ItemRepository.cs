using MaterialAssetsWarehouse.Models;
using Microsoft.EntityFrameworkCore;

namespace MaterialAssetsWarehouse.Data
{
    public class ItemRepository:IItemRepository
    {
        private readonly ItemDbContext _context;

        public ItemRepository(ItemDbContext context)
        {
            _context = context;
        }

        public void Add(Item item)
        {
            if (item !=null)
            {
                _context.Add(item);
            }
        }

        public IEnumerable<Item> GetAllItems()
        {
            IEnumerable<Item> items = _context.Items.ToList();
            return items;
        }

        public Item GetItemById(int id)
        {
            Item item = _context.Items.FirstOrDefault(i => i.ItemID == id);
            if (item != null)
            {
                return item;
            }
            throw new Exception("Failed to get an Item");

        }

        public void Remove(Item item)
        {
            if (item != null)
            {
                _context.Remove(item);
            }
        }

        public bool Savechanges()
        {
            return _context.SaveChanges()>0 ;
        }

        public void Update(Item item)
        {
            var existingItem = _context.Items.FirstOrDefault(i => i.ItemID == item.ItemID);
            if (existingItem != null)
            {
               
                existingItem.Name = item.Name;
                existingItem.Group = item.Group;
                existingItem.Measurement = item.Measurement;
                existingItem.Quantity = item.Quantity;
                existingItem.PriceWithoutVAT = item.PriceWithoutVAT;
                existingItem.Status = item.Status;
                existingItem.StorageLocation = item.StorageLocation;
                existingItem.ContactPerson = item.ContactPerson;

                
                _context.Entry(existingItem).State = EntityState.Modified;
            }
        }
    }
}
