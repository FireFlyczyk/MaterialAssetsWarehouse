using MaterialAssetsWarehouse.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ItemDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("ItemDbContextConnection")));
builder.Services.AddScoped<IItemRepository, ItemRepository>();  

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "ItemList",
    pattern: "",
    defaults: new { controller = "Item", action = "Items" });

app.MapControllerRoute(
    name: "Order",
    pattern: "Order/{action=SubmitOrder}",
    defaults: new { controller = "Order" });

app.MapControllerRoute(
    name: "Item",
    pattern: "Item/{action=AddItem}",
    defaults: new { controller = "Item" });


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
