using MaterialAssetsWarehouse.Data;
using MaterialAssetsWarehouse.Models;
using Microsoft.AspNetCore.Mvc;

namespace MaterialAssetsWarehouse.Controllers
{
    public class OrderController : Controller
    {
        private readonly IItemRepository _itemRepository;

        public OrderController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public IActionResult OrderForm()
        {
            var model = new OrderFormViewModel();
            return View();
        }

        [HttpPost]
        
        public IActionResult SubmitOrder(OrderFormViewModel orderForm)
        {

            if (ModelState.IsValid)
            {

                TempData["Message"] = "Order submitted successfully";
                return RedirectToAction("Items", "Item"); 
            }
            else
            {
                return View("OrderForm", orderForm);
            }
        }

    }
}
