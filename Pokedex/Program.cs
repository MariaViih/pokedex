using Pokedex.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IPokeService, PokeService>();

var app = builder.Build();

// configure the HTTP request pineline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // the defaul HSTS value is 30 days. You may want to change this for production....
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.MapControllerRoute(
    name: "defaul",
    pattern: "{controller=Home}/{action=Index}/{id}");

    app.Run();
