using MaterialAssetsWarehouse.Models;

namespace MaterialAssetsWarehouse.Data
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetAllItems();
        void Add(Item item);
        bool Savechanges();

    }
}
