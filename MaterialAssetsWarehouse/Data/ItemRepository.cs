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

        public bool Savechanges()
        {
            return _context.SaveChanges()>0 ;
        }
    }
}
