/*
 appsetting nos sirve para configurar
 la app.
 para usar entity framework tenemos que instalrlo en depdendencias
 usamos administrador nugget y encontramos entity framework sql server
 entity framework tools
 para las migraciones 
 
 para mapear una bd existente debemos hacerlo desde la consola nugget

    Scaffold-DBContext "Server=Localhost;Database=CrudVanillaJs;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

cadena para mappear la bd, tambien podemos usar User= Password= para usar sqlAutentication}
 
 Models.CrudVanillaJsContext db= new Models.CrudVanillaJsContext()
 hace la conexion a bd


 */