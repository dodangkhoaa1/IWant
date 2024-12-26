using IWant.Web.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using IWant.DataAccess;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration["ConnectionStrings:Default"];

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connString));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireDigit = true;
    options.Password.RequireNonAlphanumeric = false;

    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);

    options.SignIn.RequireConfirmedEmail = false;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Signin";
    options.AccessDeniedPath = "/Identity/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromHours(10);
});

builder.Services.AddAuthentication().AddFacebook(options =>
{
    options.AppId = builder.Configuration["FacebookAppId"];
    options.AppSecret = builder.Configuration["FacebookAppSecret"];
});

builder.Services.Configure<SmtpOptions>(builder.Configuration.GetSection("Smtp"));

builder.Services.AddSingleton<IEmailSender, SmtpEmailSender>();

//Set require for claim value and role 
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("MemberDep", p =>
    {
        p.RequireClaim("Department", "test").RequireRole("Member");
    });

    options.AddPolicy("AdminDep", p =>
    {
        p.RequireClaim("Department", "test").RequireRole("Admin");
    });
});

builder.Services.AddRazorPages();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
