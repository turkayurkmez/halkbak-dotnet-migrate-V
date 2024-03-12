//var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
//{
//    WebRootPath = "specialwwwroot",
//    ApplicationName = typeof(Program).Assembly.FullName,
//    ContentRootPath = Directory.GetCurrentDirectory(),
//    EnvironmentName= Environments.Production,
//    Args = args
//});

using Autofac;
using Autofac.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

string webRootPath = builder.Environment.WebRootPath;
string contentRootPath = builder.Environment.ContentRootPath;
string appName = builder.Environment.ApplicationName;
string envName = builder.Environment.EnvironmentName;



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


//builder.Configuration.AddIniFile("appsettings.ini");

builder.Logging.AddJsonConsole();
//builder.Host.ConfigureHostConfiguration(builder =>
//{
//    builder.
//});

builder.Host.ConfigureHostOptions(option =>
{
    option.ShutdownTimeout = TimeSpan.FromSeconds(45);
});

builder.WebHost.UseHttpSys(); // sadece windows ortamında (IIS için) anlamlı.


//Autofac paketini kullanmak istiyorum
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

//builder.Host.ConfigureContainer<ContainerBuilder>(builder=> builder.RegisterModule());


var app = builder.Build();

app.Logger.LogInformation($"varsayılan değerler: {webRootPath}\n{contentRootPath}\n{appName}\n{envName}");


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    /*
     * 3.1'de EF paketinde bulunan DatabaseErrorPage() isimli extension kaldırıldı. Bu fonksiyonun görevi, EF üzerinde gerçekleşen hata detaylarını sayfada göstermektir. Kaldırılan bu fonksiyon yerine  Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore paketi içinde yer alan 25. satırdaki extension metot çağrılmalı. Ardından development ortamında çalışacak aşağıdaki middleware çağrılmalı:
     */
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


//app.UseEndpoints(endpoints => endpoints.MapGet("/test", () => "Test"));

app.MapGet("/test", () => "Burası test sayfasi");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
