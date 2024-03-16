using System.ComponentModel.DataAnnotations;

namespace MaterialAssetsWarehouse.Models
{
    public class OrderFormViewModel
    {
        public string? ItemName { get; set; }

        [Required (ErrorMessage ="Please enter a unit of measurment")]
        public string UnitOfMeasurement { get; set; }

        [Required(ErrorMessage = "Please enter a quantity")]
        [Range(0.5, 10000, ErrorMessage = "If the quantity is more than 10000, please, contact your Team Leader")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Please enter a price")]
        [Range(0.5, 30000, ErrorMessage = "If the price is more than 30000, please, contact your Team Leader")]
        public decimal PriceWithoutVAT { get; set; }
        public string? Comment { get; set; }
    }
}
