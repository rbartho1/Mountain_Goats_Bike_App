using Mountain_Goats_Bike_App.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<CategoriesData>();
builder.Services.AddSingleton<BrandsData>();
builder.Services.AddSingleton<InventoryData>();
builder.Services.AddSingleton<ProductsData>();
builder.Services.AddSingleton<RatingsData>();
builder.Services.AddSingleton<CustomersData>();
builder.Services.AddSingleton<LocationsData>();
builder.Services.AddSingleton<StaffData>();
builder.Services.AddSingleton<ItemsOrderedData>();
builder.Services.AddSingleton<OrdersData>();
builder.Services.AddSingleton<CustomerOrdersData>();
builder.Services.AddSingleton<SearchProductsData>();

var app = builder.Build();

// Configure the HTTP request pipeline
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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
