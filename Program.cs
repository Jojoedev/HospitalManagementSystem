using HospitalManagementSystem.AppDbContext;
using HospitalManagementSystem.Interface;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;
using HospitalManagementSystem.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

//.UseLazyLoadingProxies()

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddTransient<IHospitalnterface, HospitalService>();
builder.Services.AddTransient<IPatientType, IPatientTypeService>();

builder.Services.AddTransient<IGenericInterface<Patient>, GenericService<Patient>>();
builder.Services.AddTransient<IGenericInterface<Gender>, GenericService<Gender>>();
builder.Services.AddTransient<IGenericInterface<PatientType>, GenericService<PatientType>>();
builder.Services.AddRazorPages(options => options.Conventions.AuthorizeFolder("/"));


builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapRazorPages();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Patient}/{action=Index}/{id?}");

app.Run();
