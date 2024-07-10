using BLL.LogicServices;
using DAL.DataContext;
using DAL.DataServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IStudentLogic, StudentLogic>();

builder.Services.AddSingleton<IStudentDataDAL, StudentDataDAL>();

builder.Services.AddSingleton<IDapperOrmHelper, DapperOrmHelper>();

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
    name: "default",
    pattern: "{controller=Student}/{action=Sign_Up}/{id?}");

app.Run();
