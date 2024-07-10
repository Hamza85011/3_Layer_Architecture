using BLL.LogicServices;
using DAL.DataContext;
using DAL.DataServices;

var builder = WebApplication.CreateBuilder(args);

void ConfigureServices(IServiceCollection services)
{
    services.AddControllersWithViews();

    services.AddDistributedMemoryCache(); 
    services.AddSession(options =>
    {
        options.IdleTimeout = TimeSpan.FromMinutes(30); 
        options.Cookie.HttpOnly = true;
        options.Cookie.IsEssential = true; 
    });

    services.AddSingleton<IStudentLogic, StudentLogic>();
    services.AddSingleton<IStudentDataDAL, StudentDataDAL>();
    services.AddSingleton<IDapperOrmHelper, DapperOrmHelper>();
}

ConfigureServices(builder.Services);

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Sign_Up}/{id?}");

app.Run();
