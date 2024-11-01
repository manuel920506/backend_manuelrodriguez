## Installations
ControllerLayer:
	Microsoft.EntityFrameworkCore.Design
	AutoMapper
	Microsoft.AspNetCore.Identity.EntityFrameworkCore
	Microsoft.AspNetCore.Authentication.JwtBearer
DataAccessLayer:
	Microsoft.EntityFrameworkCore.Tools
	Pomelo.EntityFrameworkCore.MySql

## Installations
dotnet add package Microsoft.AspNetCore.Cors

## Production
dotnet publish -c Release -o ./publish

