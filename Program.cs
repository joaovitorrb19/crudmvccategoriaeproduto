using ControleEstoque.Data;
using ControleEstoque.Models;
using ControleEstoque.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer("server=localhost,1433;database=controleestoque;user id=sa; password=@Aa9988554400;TrustServerCertificate=true"));
builder.Services.AddScoped<DataContext>();

builder.Services.AddScoped<IRepository<Produto>,Repository<Produto>>();
builder.Services.AddScoped<IRepository<Categoria>,Repository<Categoria>>();
builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
builder.Services.AddScoped<UnitOfWork>();


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

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
