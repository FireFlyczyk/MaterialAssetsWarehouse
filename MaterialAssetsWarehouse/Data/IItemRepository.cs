using MaterialAssetsWarehouse.Models;

namespace MaterialAssetsWarehouse.Data
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetAllItems();
    }
}
