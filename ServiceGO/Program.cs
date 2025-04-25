using BLL.AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using DAL.ApplicationDbContext;
using DAL.BaseRepository;
using DAL.IRepositories;
using DAL.IRepository;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<JwtSettingsDTO>(builder.Configuration.GetSection("JwtSettings"));

builder.Services.AddAutoMapper(typeof(MappingProfile));



builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);



builder.Services.AddScoped<IDriversService, DriversService>();
builder.Services.AddScoped<IDriversRepository, DriversRepository>();

builder.Services.AddScoped<ICompaniesService, CompaniesService>();
builder.Services.AddScoped<ICompaniesRepository, CompaniesRepository>();


builder.Services.AddScoped<IAuthService, AuthService>();
// Add services to the container.
builder.Services.AddControllersWithViews();

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
