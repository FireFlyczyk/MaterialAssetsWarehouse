using MaterialAssetsWarehouse.Data;
using Microsoft.AspNetCore.Mvc;

namespace MaterialAssetsWarehouse.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemRepository _itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }


        public IActionResult Items()
        {
            var items = _itemRepository.GetAllItems();
            return View(items);
        }
    }
}
