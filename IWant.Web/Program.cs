using IWant.Web.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using IWant.DataAccess;
using Microsoft.AspNetCore.Hosting;
using IWant.Web.Hubs;
using IWant.BusinessObject.Enitities;

var builder = WebApplication.CreateBuilder(args);

var environment = builder.Environment.EnvironmentName;

if (environment == Environments.Development) 
{
    var config = new ConfigurationBuilder()
        .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../IWant.DataAccess"))
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .Build();

    builder.Configuration.AddConfiguration(config);
}

var connString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connString));
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddScoped<SignInManager<User>>();
builder.Services.AddScoped<UserManager<User>>();
builder.Services.AddScoped<ILeaderboardService, LeaderboardService>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireDigit = true;
    options.Password.RequireNonAlphanumeric = false;

    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);

    options.SignIn.RequireConfirmedEmail = true;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Signin";
    options.AccessDeniedPath = "/Identity/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromHours(10);
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(15);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.Configure<SmtpOptions>(builder.Configuration.GetSection("Smtp"));

builder.Services.AddSingleton<IEmailSender, SmtpEmailSender>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

builder.Services.AddHttpClient<IWordService, WordService>();


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

IMvcBuilder build = builder.Services.AddRazorPages();
#if DEBUG
if (environment == Environments.Development)
{
    build.AddRazorRuntimeCompilation();
}
#endif

builder.Services.AddSignalR();

builder.Services.AddHttpClient();

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

app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "chatRoute",
    pattern: "Chat/Messages/{roomName}",
    defaults: new { controller = "Chat", action = "Messages" });

app.MapHub<ChatHub>("/ChatHub");

app.Run();
