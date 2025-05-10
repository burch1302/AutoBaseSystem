using Auth0.AspNetCore.Authentication;
using AutoBase.Domain;
using AutoBaseSystem.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<AutoBaseSystemContext>(opt => opt.UseSqlServer(connectionString));
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication("UserCookie")
    .AddCookie("UserCookie", options => {
        options.LoginPath = "/Account/Login"; // ���� �� ����������� � ��������
    });

// �������������� ����� ����������� ����� Auth0 (������ ��������)
builder.Services.AddAuthentication()
    .AddAuth0WebAppAuthentication("Auth0", options => {
        options.Domain = builder.Configuration["Auth0:Domain"];
        options.ClientId = builder.Configuration["Auth0:ClientId"];
        options.ClientSecret = builder.Configuration["Auth0:ClientSecret"];
        options.Scope = "openid profile email";
        options.CallbackPath = "/callback";
    });

builder.Services.AddAuthorization();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseMiddleware<RequestLoggingMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
