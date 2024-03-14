using System.ComponentModel.DataAnnotations;

namespace MaterialAssetsWarehouse.Models
{
    public class Item
    {
        public int ItemID { get; set; }

        public ItemGroup Group { get; set; }

        public UnitOfMeasurement Measurement { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public string Status { get; set; }

        public string StorageLocation { get; set; }

        public string ContactPerson { get; set; }

        public string Photo { get; set; }

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
