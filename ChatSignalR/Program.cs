//Usando el modelo ASP.NET proyecto web Modelo-Vista-Controlador
//Utilizaremos la biblioteca signalR que permite enviar notificaciones asincronas
//a tus aplicaciones, osea que desde el servidor se le envía una solicitud a tu cliente (o información)
//se utiliza en aplicaciones de tiempo real, en este caso será en un chat.

using ChatSignalR;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<ChatHub>("/chat");

app.Run();
