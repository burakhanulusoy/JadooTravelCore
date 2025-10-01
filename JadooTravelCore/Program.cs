using JadooTravelCore.Services.CategoryServices;
using JadooTravelCore.Services.DestinationsServices;
using JadooTravelCore.Services.FeatureServices;
using JadooTravelCore.Services.ReceiverMessageServices;
using JadooTravelCore.Services.ServiceServices;
using JadooTravelCore.Services.SupporterServices;
using JadooTravelCore.Services.TestimonialServices;
using JadooTravelCore.Services.UserServices;
using JadooTravelCore.Settings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IDestinationService,DestinationService>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IReceiverMessageService,ReceiverMessageService>();
builder.Services.AddScoped<ITesimonialService,TestimonailService>();
builder.Services.AddScoped<IFeatureService,FeatureService>();
builder.Services.AddScoped<IServiceService,ServiceService>();
builder.Services.AddScoped<ISupporterService,SupporterService>();


builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettingsKey"));


builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});


builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(opt =>
{
    opt.IdleTimeout = TimeSpan.FromSeconds(30);
    opt.Cookie.HttpOnly = true;
    opt.Cookie.IsEssential=true;


});


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt=>
    {
        opt.Cookie.Name = "JadooTravel";
        opt.LoginPath = "/Auth/Login";
        opt.LogoutPath = "/Auth/Logout";
        opt.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        opt.SlidingExpiration=true; 
    });

//tüm controllerlara authorize gitti ama login ve ana sayfa olmayacak
builder.Services.AddControllersWithViews(opt=>
{
    opt.Filters.Add(new AuthorizeFilter());
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

app.UseAuthentication();

app.UseAuthorization();//yetkilendirme
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
