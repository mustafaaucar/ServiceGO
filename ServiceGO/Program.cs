using BLL.AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using DAL.ApplicationDbContext;
using DAL.BaseRepository;
using DAL.IRepositories;
using DAL.IRepository;
using DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<JwtSettingsDTO>(builder.Configuration.GetSection("JwtSettings"));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.Configure<IISServerOptions>(options =>
{
    options.MaxRequestBodySize = 104857600; 
});

builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);



builder.Services.AddScoped<IDriversService, DriversService>();
builder.Services.AddScoped<IDriversRepository, DriversRepository>();
builder.Services.AddScoped<IManagerRepository, ManagersRepository>();


builder.Services.AddScoped<ICompanyDriversRepository, CompanyDriversRepository>();

builder.Services.AddScoped<ICompaniesService, CompaniesService>();
builder.Services.AddScoped<ICompaniesRepository, CompaniesRepository>();


builder.Services.AddScoped<IAuthService, AuthService>();
// Add services to the container.
builder.Services.AddControllersWithViews();

var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettingsDTO>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var token = context.Request.Cookies["ServiceGoToken"];
            if (!string.IsNullOrEmpty(token))
            {
                context.Token = token;
            }
            return Task.CompletedTask;
        }
    };
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
    };
});


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
    name: "ManagerHome",
    pattern: "manager-anasayfa",
    defaults: new { controller = "Home", action = "Index" }
);
app.MapControllerRoute(
    name: "Login",
    pattern: "login",
    defaults: new { controller = "Home", action = "Login" }
);
app.MapControllerRoute(
    name: "Drivers",
    pattern: "drivers",
    defaults: new { controller = "Drivers", action = "Index" }
);





app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
