using BusinessLayer.Container;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using TraversalCoreProject.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
    {
        options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
    }
);
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

// Add services to the container.
builder.Services.AddDbContext<Context>();
// Add logging services
builder.Services.AddLogging(x => { 
    x.ClearProviders();
    // Start from Debug
    x.SetMinimumLevel(LogLevel.Debug);
    x.AddDebug();
});
// Add identity to application.
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>()
    .AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<Context>();

builder.Services.AddDependencyResolvers();

// Add AutoMapper to the application
builder.Services.AddAutoMapper(typeof(Program));

// Add Validator to the application
builder.Services.CustomValidator();


// Authorization in the application
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
		.RequireAuthenticatedUser()
		.Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});
builder.Services.AddMvc();

var app = builder.Build();

// Configuring the LoggingFactory
var lf = app.Services.GetRequiredService<ILoggerFactory>();
var path = Directory.GetCurrentDirectory();
lf.AddFile($"{path}/Logs/log.txt");



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/Error/Error404", "?code={0}");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();

app.UseRouting();
app.UseAuthorization();

// Burada /{id?} olmas� routing yaparken DestinationDetails/1 gibi bir url girildi�inde 1'i id olarak al�r. Aksi halinde sadece DestinationDetails?=1 �al���r.
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Login}/{action=SignIn}/{id?}");
});

app.Run();
