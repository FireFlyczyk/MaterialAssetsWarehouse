using System.ComponentModel.DataAnnotations;

namespace MaterialAssetsWarehouse.Models
{
    public class Item
    {
        [Required]
        public int ItemID { get; set; }
        [Required] 
        public string Name { get; set; }
        [Required]
        public ItemGroup Group { get; set; }
        [Required]
        public UnitOfMeasurement Measurement { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal PriceWithoutVAT { get; set; }
        [Required]
        public string Status { get; set; }

        public string StorageLocation { get; set; }

        public string ContactPerson { get; set; }

        public enum ItemGroup
        {
            Stationery,
            Food,
            Production,
            Vehicle,

        }

        public enum UnitOfMeasurement
        {
            Gram,
            Kilogram,
            Litre,
            Meter,
            Not_Applicable
        }
    }
}
