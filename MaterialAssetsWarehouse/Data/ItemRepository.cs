using MaterialAssetsWarehouse.Models;

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
    }
}
