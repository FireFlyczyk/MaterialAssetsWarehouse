﻿using MaterialAssetsWarehouse.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MaterialAssetsWarehouse.Data
{
    public class ItemDbContext : IdentityDbContext<ApplicationUser>
    {
        public ItemDbContext( DbContextOptions<ItemDbContext> options):base(options)
        {
            
            
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Item>().HasData(
              new Item { ItemID = 1043,Name="Paper A4", Group = Item.ItemGroup.Stationery, Measurement = Item.UnitOfMeasurement.Not_Applicable, Quantity = 10, PriceWithoutVAT = 40, Status = "available", StorageLocation = "Warsaw", ContactPerson = "Andrzej Zalewski" },
              new Item { ItemID = 4324, Name = "Milk", Group = Item.ItemGroup.Food, Measurement = Item.UnitOfMeasurement.Litre, Quantity = 30, PriceWithoutVAT = 60, Status = "available", StorageLocation = "Piaseczno", ContactPerson = "Andrzej Zalewski" },
              new Item { ItemID = 5321, Name = "Opel", Group = Item.ItemGroup.Vehicle, Measurement = Item.UnitOfMeasurement.Not_Applicable, Quantity = 1, PriceWithoutVAT = 65000, Status = "available", StorageLocation = "Warsaw", ContactPerson = "Marek Kozłowksi" },
              new Item { ItemID = 2841, Name = "Steel", Group = Item.ItemGroup.Production, Measurement = Item.UnitOfMeasurement.Kilogram, Quantity = 100, PriceWithoutVAT = 3259, Status = "only 300 kg left", StorageLocation = "Poznań", ContactPerson = "Jarek Sannikov" },
              new Item { ItemID = 4832, Name = "Bananas", Group = Item.ItemGroup.Food, Measurement = Item.UnitOfMeasurement.Kilogram, Quantity = 3, PriceWithoutVAT = 249, Status = "available", StorageLocation = "Radom", ContactPerson = "Maria Ziobro" });

        }

        public DbSet<Item> Items {  get; set; }
    }
}
