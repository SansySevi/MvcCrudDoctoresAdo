var builder = WebApplication.CreateBuilder(args);

//AÑADIR LOS SERVICIOS DE VISTAS Y CONTROLLERS
//EN NUESTRA APP
builder.Services.AddControllersWithViews();


var app = builder.Build();
app.UseStaticFiles();

//AL UTILIZAR CONTROLLERS Y VIEWS, DEBEMOS INDICAR
//QUE CONTROLLER Y QUE ACTION SERAN LOS INICIALES
//DEBEMOS INDICAR EL SISTEMA DE RUTAS QUE UTILIZA MI APP
//
// https://servidor/CONTROLADOR/ACTION

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Doctores}/{action=Index}"
    );

app.Run();