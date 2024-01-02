using ContactsManager.Core.ServiceContracts;
using Services;
using Microsoft.EntityFrameworkCore;
using ContactsManager.Core.Domain.Entities;
using ContractManager.Infrastructure.DBContext;
using ContactsManager.Core.RepoContracts;
using ContractManager.Infrastructure.Repos;
using ContactsManager.Core.Domain.RepoContracts;
using ContactManager.Infrastructure.Repos;
using ContactsManager.Core.Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DBDemoDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
}


);

/*
 *Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=People_List;IntegratedSecurity=True;
 *ConnectTimeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
 *
 */



builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IPersonRepo, PersonRepo>();
builder.Services.AddScoped<ICountryRepo,CountryRepo>();
builder.Services.AddScoped<ICountryService,CountryService>();
builder.Services.AddScoped<IPersonAddService, AddPersonService>();
builder.Services.AddScoped<IPersonDeleteService, DeletePersonService>();
builder.Services.AddScoped<IPersonGetAllService, GetAllPersonService>();
builder.Services.AddScoped<IPersonGetByIdService, GetByIdPersonService>();
builder.Services.AddScoped<IPersonSearchService, SearchPersonService>();
builder.Services.AddScoped<IPersonSortedService, SortedPersonService>();
builder.Services.AddScoped<IPersonUpdateService, UpdatedPersonService>();
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.Password.RequiredUniqueChars = 1;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
})
    .AddEntityFrameworkStores<DBDemoDbContext>()
    .AddDefaultTokenProviders()
    .AddUserStore<UserStore<ApplicationUser, ApplicationRole, DBDemoDbContext, Guid>>()
    .AddRoleStore<RoleStore<ApplicationRole,DBDemoDbContext,Guid>>();
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
});
builder.Services.AddScoped<ValidationHelper, ValidationHelper>();
var app = builder.Build();
if (app.Environment.IsDevelopment()){
    app.UseDeveloperExceptionPage();
    Console.WriteLine("Exception page activated");
}
app.Logger.LogDebug("log---Debugging");
app.Logger.LogInformation("log---Information");
app.Logger.LogWarning("log---Warning");
app.Logger.LogError("log---Error");
app.Logger.LogCritical("log---Critical");
app.UseStaticFiles();


app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseEndpoints(endpoint =>
{
    endpoint.MapControllerRoute(
        name: "Default",
        pattern: "{controller}/{action}"

        );
});
app.Run();
