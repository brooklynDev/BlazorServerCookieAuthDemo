# Blazor Server Cookie Auth Demo

This project demonstrates how one might implement Cookie Authentication using Blazor server. 



### Running the app

#### Prerequisites: 

This sample application is build to use SQL Server. Additionally, it uses EF Core, so you'll need the ef core tools installed. You can do that by running the following in your terminal:

`dotnet tool install --global dotnet-ef`

#### Setting up:

First start by cloning this repo:

`git clone git@github.com:brooklynDev/BlazorServerCookieAuthDemo.git`

Then, navigate to `{application_root}/BlazorServerAuthDemo/BlazorServerAuthDemo.Web` and create a new file called `appsettings.local.json` and paste the following bit of json:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "{your sql server connection string goes here};"
  }
}
```

Then, navigate to `{application_root}/BlazorServerAuthDemo/BlazorServerAuthDemo.Data` and run the following:

`dotnet ef database update`

This will create the database and run the migrations using EF.

Once that's done, navigate back to `{application_root}/BlazorServerAuthDemo/BlazorServerAuthDemo.Web` and run:

`dotnet run`

This will launch the application at `https://localhost:5001`

