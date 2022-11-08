using Lima.Plugins.EFCore;
using Lima.UseCases.Interfaces;
using Lima.UseCases.Inventories;
using Lima.UseCases.PluginInterfaces;
using Lima.UseCases.Products;
using Lima.UseCases.Reports;
using Lima.UseCases.Transactions;
using Lima.UseCases.Validations;
using LIMA.Areas.Identity;
using LIMA.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddDbContext<LimaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("InventoryMgt"));
});
//Repository Inventory
builder.Services.AddTransient<IInventoryRepository, InventoryRepository>();

//Repository Products
builder.Services.AddTransient<IProductRepository, ProductRepository>();

//Repository Transactions
builder.Services.AddTransient<IInventoryTransactionRepository, InventoryTransactionRepository>();   

//Use Cases Inventory
builder.Services.AddTransient<IViewInventory, ViewInventory>();
builder.Services.AddTransient<IAddInventory, AddInventory>();
builder.Services.AddTransient<IEditInventory, EditInventory>();
builder.Services.AddTransient<IViewInvById, ViewInvById>();

//Use Cases Products
builder.Services.AddTransient<IViewProducts, ViewProducts>();
builder.Services.AddTransient<IAddProduct, AddProduct>();
builder.Services.AddTransient<IViewProductsbyId, ViewProductsbyId>();
builder.Services.AddTransient<IEditProduct, EditProduct>(); 
builder.Services.AddTransient<IDeleteProduct, DeleteProduct>();

//Use Case Transactions
builder.Services.AddTransient<IPurchaseInventory, PurchaseInventory>();
builder.Services.AddTransient<IProduceProduct, ProduceProduct>();   
builder.Services.AddTransient<IProductTransactionRepository, ProductTransactionRepository>();   
builder.Services.AddTransient<IValidateEnoughInventories4Production, ValidateEnoughInventories4Production>();
builder.Services.AddTransient<ISellProduct, SellProduct>();
builder.Services.AddTransient<ISearchInventoryTransactions, SearchInventoryTransactions>();
builder.Services.AddTransient<ISearchProductTransactions, SearchProductTransactions>(); 

var app = builder.Build();

var scope = app.Services.CreateScope();
var limaContext = scope.ServiceProvider.GetRequiredService<LimaContext>();
//limaContext.Database.EnsureDeleted();
//limaContext.Database.EnsureCreated();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
