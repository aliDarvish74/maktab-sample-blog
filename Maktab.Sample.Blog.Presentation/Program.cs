using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Domain.Roles;
using Maktab.Sample.Blog.Domain.Users;
using Maktab.Sample.Blog.Persistence;
using Maktab.Sample.Blog.Persistence.Posts;
using Maktab.Sample.Blog.Presentation.MapsterConfiguration;
using Maktab.Sample.Blog.Service.Configurations;
using Maktab.Sample.Blog.Service.Posts;
using Maktab.Sample.Blog.Service.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string blogDbConnectionString = builder.Configuration.GetConnectionString("BlogDbConnectionString");

var grants = builder.Configuration.GetSection("InternalGrants");
builder.Services.Configure<InternalGrantsSettings>(grants);
builder.Services.AddSingleton(grants.Get<InternalGrantsSettings>()?? new InternalGrantsSettings());
builder.Services.AddDbContext<BlogDbContext>(
    optionsBuilder =>
    {
        optionsBuilder.UseMySql(blogDbConnectionString, ServerVersion.AutoDetect(blogDbConnectionString));
    });

MapsterConfig.RegisterMapping();

builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPostService, PostService>();

builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.LoginPath = "/Accounting/Login";
    opt.AccessDeniedPath = "/Accounting/Login";
});
builder.Services.AddIdentity<User, Role>(opt =>
    {
        opt.Password.RequireDigit = true;
        opt.Password.RequireNonAlphanumeric = false; // $#%&^*
        opt.Password.RequiredLength = 8;
        opt.Password.RequireUppercase = false;
        opt.Password.RequireLowercase = false;
    })
    .AddEntityFrameworkStores<BlogDbContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BlogDbContext>();
    if(db.Database.GetMigrations().Any())
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