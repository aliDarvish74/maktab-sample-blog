using EF_SQLServer_Persitance;
using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Domain.Roles;
using Maktab.Sample.Blog.Domain.Users;
using Maktab.Sample.Blog.Persistence;
using Maktab.Sample.Blog.Persistence.Posts;
using Maktab.Sample.Blog.Presentation.MapsterConfiguration;
using Maktab.Sample.Blog.Service.Configurations;
using Maktab.Sample.Blog.Service.Posts;
using Maktab.Sample.Blog.Service.Users;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string blogDbConnectionString = builder.Configuration.GetConnectionString("BlogDbConnectionString");

var grants = builder.Configuration.GetSection("InternalGrants");
builder.Services.Configure<InternalGrantsSettings>(grants);
builder.Services.AddSingleton(grants.Get<InternalGrantsSettings>()?? new InternalGrantsSettings());

builder.Services.AddMySQLPersistance(blogDbConnectionString
                                     ?? throw new ArgumentNullException("ConnectionString",
                                         "Can not find connection string."));
// builder.Services.AddSQLServerPersistance(builder.Configuration.GetConnectionString("SQLServer"));

MapsterConfig.RegisterMapping();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPostService, PostService>();

builder.Services.AddIdentity<User, Role>(options =>
    {
        options.Password.RequireDigit = true;
        options.Password.RequireNonAlphanumeric = false; // $#%&^*
        options.Password.RequiredLength = 8;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
    }).AddEntityFrameworkStores<BlogDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddRazorPages();

builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.LoginPath = "/Accounting/Login";
    opt.LogoutPath = "/Accounting/Logout";
    opt.AccessDeniedPath = "/Accounting/Login";
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BlogDbContext>();
    // var db = scope.ServiceProvider.GetRequiredService<SqlServerDbContext>();
    if (db.Database.GetMigrations().Any())
        await db.Database.MigrateAsync();
}

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
app.MapRazorPages();

app.Run();