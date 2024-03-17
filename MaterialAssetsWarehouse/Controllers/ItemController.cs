using MaterialAssetsWarehouse.Data;
using MaterialAssetsWarehouse.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MaterialAssetsWarehouse.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemRepository _itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpGet]
        public IActionResult Items(string sortOrder, int? searchString)
        {
            ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder) ? "ItemId_desc" : "";
            ViewBag.GroupSortParm = sortOrder == "Group" ? "Group_desc" : "Group";
            ViewBag.MeasurementSortParm = sortOrder == "Measurement" ? "Measurement_desc" : "Measurement";
            ViewBag.QuantitySortParm = sortOrder == "Quantity" ? "Quantity_desc" : "Quantity";
            ViewBag.PriceWithoutVATSortParm = sortOrder == "PriceWithoutVAT" ? "PriceWithoutVAT_desc" : "PriceWithoutVAT";
            ViewBag.StatusSortParm = sortOrder == "Status" ? "Status_desc" : "Status";
            ViewBag.StorageLocationSortParm = sortOrder == "StorageLocation" ? "StorageLocation_desc" : "StorageLocation";
            ViewBag.ContactPersonSortParm = sortOrder == "ContactPerson" ? "ContactPerson_desc" : "ContactPerson";
        
            var items = _itemRepository.GetAllItems();

            items = ApplyFilter(items, searchString);   
            items = ApplySorting(items, sortOrder);
           
            return View(items.ToList());
        }
        public IActionResult AddForm()
        {
            var model = new Item();
            return View();
        }

        [HttpPost]
        public IActionResult AddItem(Item item)
        {
            if (ModelState.IsValid)
            {
                _itemRepository.Add(item);
                _itemRepository.Savechanges();
                
                return RedirectToAction("Items", "Item");
            }

            return View("AddForm", item);
          
        }

        private IEnumerable<Item> ApplyFilter(IEnumerable<Item> items, int? searchString )
        {
            if (searchString.HasValue)
            {
                items = items.Where(i => i.ItemID.ToString().Contains(searchString.Value.ToString()));
            }
            return items;
        }

        private IOrderedEnumerable<Item> ApplySorting(IEnumerable<Item> items, string sortOrder)
        {
            return sortOrder switch
            {
                "ItemId_desc" => items.OrderByDescending(i => i.ItemID),
                "Group_desc" => items.OrderByDescending(i => i.Group),
                "Measurement" => items.OrderBy(i => i.Measurement),
                "Measurement_desc" => items.OrderByDescending(i => i.Measurement),
                "Quantity" => items.OrderBy(i => i.Quantity),
                "Quantity_desc" => items.OrderByDescending(i => i.Quantity),
                "PriceWithoutVAT" => items.OrderBy(i => i.PriceWithoutVAT),
                "PriceWithoutVAT_desc" => items.OrderByDescending(i => i.PriceWithoutVAT),
                "Status" => items.OrderBy(i => i.Status),
                "Status_desc" => items.OrderByDescending(i => i.Status),
                "StorageLocation" => items.OrderBy(i => i.StorageLocation),
                "StorageLocation_desc" => items.OrderByDescending(i => i.StorageLocation),
                "ContactPerson" => items.OrderBy(i => i.ContactPerson),
                "ContactPerson_desc" => items.OrderByDescending(i => i.ContactPerson),
                _ => items.OrderBy(i => i.ItemID),
            };
        }
    }

 
        
}  
