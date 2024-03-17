using System.ComponentModel.DataAnnotations;

namespace MaterialAssetsWarehouse.Models
{
    public class OrderFormViewModel
    {
        public string? ItemName { get; set; }

        [Required (ErrorMessage ="Please enter a unit of measurment")]
        public string UnitOfMeasurement { get; set; }

        [Required(ErrorMessage = "Please enter a quantity")]
        [Range(0.5, 10000, ErrorMessage = "Please, enter the value between 0,5 and 10000")]
        public int? Quantity { get; set; }

        [Required(ErrorMessage = "Please enter a price")]
        [Range(0.5, 30000, ErrorMessage = "Please, enter the value between 0,5 and 30000")]
        public decimal? PriceWithoutVAT { get; set; }
        public string? Comment { get; set; }
    } 
}
