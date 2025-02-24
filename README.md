# hotel_room_management

### Web API Application Setup ###
- tested on Visual Studio 2022
- Download or clone repo
- Run solution in Visual Studio (recommended version 2022)
- If NuGet packages haven't been restored automatically, restore them manually by, e.g. right-clicking on solution file in Solution Explorer and choose "restore NuGet packages" option
- Choose "HotelRoomManagement" as startup project
- Application uses ssl so at first start there might be a question about trusting certificate. You can either accept (which will be followed by need to install certificate if it's not already installed) or decline the message.

### Web API Unit tests Setup ###
- From VS menu choose View -> Test Explorer
- After attaching explorer into main VS window click "run all tests" button

### DB Setup ###
Both Web API application and tests should run without the need to attach the database. However, if you'd like to use the API's endpoint a db backup and SQL server instance would be needed. You can use e.g. express version of MS SQL Server
Communitation with db relies on EF Core and migrations are enabled in this project. Initial migration is already included as well.
To create db from scratch you can use following steps:
- run Package Manager console (Tools -> NuGet package manager -> package manager console)
- choose HotelRoomManagement.DataAccess project
- type update-database command in console and hit Enter. The command should create new db with the name specified in appsettings.json's connection string (if such sb doesn't exist). It should also apply Initial migration 
