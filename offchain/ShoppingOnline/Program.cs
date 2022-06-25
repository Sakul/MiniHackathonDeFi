using ShoppingOnline.Services;

// HACK: Configuration
const string nodeEndpoint = "http://127.0.0.1:7545";
const string smartContractAddress = "0xB11F07C9A0f7626de0B1d03aAdF1858c2D95594b";
var pointService = new T3PointService(nodeEndpoint, smartContractAddress);
await pointService.Initialize();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IPointService>(pointService);

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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
