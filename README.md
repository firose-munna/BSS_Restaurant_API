
# Restaurant Management App (Web API)
This project aims to develop a comprehensive restaurant management system that streamlines various aspects of restaurant operations, including employee management, table assignment, food ordering, and order tracking.
## Challenges
The main challenge is to design the database schema, conneting the database and migration. For the order item table I have missing the foreign key and thats why a cyclick situation is occured. 

## Key Features
1. User Authentication: In this web api, the authentication and authorization is implemented by dot net entity role. JWT is used for generate the bearer token. 
2. CRUD Operation: For employee, table, food, employeeTable, order entites - CRUD operation is implemented following respository and unit of work pattern.
3. Endpoint: API endpoints for all controller is implemented following respository and unit of work pattern.

## Architecture and Pattern
1. Respository Pattern with Unit of Work
2. N-Tier Architecture

## Folder Structure

![Screenshot 2024-03-26 152038](https://github.com/firose-munna/BSS_Restaurant_API/assets/105736440/7dbc5412-9963-4c22-9d1c-2c59959d3e02)

## Used Technologies
1. ASP.NET Core (8.0.3)
2. SQLServer Database
3. SSMS- SQL Server Management Studio-19

## Used Packages
1. Microsoft.AspNetCore.Authentication.JwtBearer, Version="8.0.3"
2. Microsoft.AspNetCore.Identity.EntityFrameworkCore, Version="8.0.3"
3. Microsoft.AspNetCore.OpenApi, Version="8.0.3"
4. Microsoft.EntityFrameworkCore, Version="8.0.3"
5. Microsoft.EntityFrameworkCore.SqlServer, Version="8.0.3"
6. Microsoft.EntityFrameworkCore.Tools, Version="8.0.3"
7. Microsoft.IdentityModel.Tokens, Version="7.4.1"
8. Swashbuckle.AspNetCore, Version="6.4.0"
9. Swashbuckle.AspNetCore.Filters, Version="8.0.1"
10. System.IdentityModel.Tokens.Jwt, Version="7.4.1"

## 🔗 Live Site Link
[![Live](https://img.shields.io/badge/Click_Here_For_Restaurant_API-000?style=for-the-badge&logo=ko-fi&logoColor=white)](#)



## Admin Login Credential

Username: admin@mail.com \
Password: Admin@123

## Project Setup

Change the Server Name and Localhost Port at appssettings.json

```bash
"ConnectionStrings": {
  "DefaultConnection": "Server = Your_Server_Name_Here; Database = RestaurantsDB;
       Trusted_Connection = True; MultipleActiveResultSets=true; TrustServerCertificate = True"
},
"Jwt": {
  "Key": "Your_GUID_Key",
  "Issuer": "https://localhost:Your_Port_Number/",
  "Audience": "https://localhost:Your_Port_Number/"
}
```

Change the port number at program.cs file

```bash
builder.Services.AddCors(options => options.AddPolicy(name: "Custom_Name",
      policy => { policy.WithOrigins("http://localhost:Your_Port_Number/")
      .AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin(); }));

```

Open Package Manager Console and Type (Change Default Project : Data)

```bash
  add-migration YourMigrationName
  update-database
```
    
## Output on Swagger

After install and setup the project when run the project then the output will be shown like as the output. 

![screencapture-localhost-7038-swagger-index-html-2024-03-26-13_14_37](https://github.com/firose-munna/BSS_Restaurant_API/assets/105736440/184c82af-7d2d-4a6d-887c-832862988c75)



