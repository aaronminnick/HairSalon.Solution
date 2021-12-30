## Eau Claire's Salon
#### _by Aaron Minnick_

### Technologies Used:
* C#
* ASP .NET Core
* Razor / HTML / CSS
* Entity Framework / LINQ
* MySql Workbench

This is the week 3 independent project for the C# curriculum at [Epicodus](https://www.epicodus.com). The objective was to create an simple database application to track and modify the stylists and clients of a fictional hair salon.

## Setup Instructions:
_(Please note, the below instructions are using gitbash on a Windows computer. Commands may vary if you are using a different OS or terminal program.)_
* You will need [.NET 5](https://dotnet.microsoft.com/en-us/download/dotnet/5.0).

* You will need to download and install MySQL Community Server and MySQL Workbench from [here.](https://dev.mysql.com/downloads/)

* Clone this repository to your local repository (the link may be easily got using the green "Code" button on the github page):
```
$ git clone https://github.com/aaronminnick/HairSalon.Solution.git
```
* **Or** you may use the same button to download the files to your computer.

* Import the SQL database and configure appsettings.json as described below.

* Use console commands to navigate to the main project folder and run console commands to build and run the project:
```
$ cd HairSalon
$ dotnet restore
$ dotnet build
$ dotnet run
```
* Using a web browser, navigate to:
```
localhost:5000/
```

### Import SQL Database
To import the SQL database, open MySQL Workbench and follow these steps:

* In the Navigator > Administration window, select Data Import/Restore.
* In Import Options select Import from Self-Contained File.
* Navigate to aaron_minnick.sql in the top level of the repository.
* Under Default Schema to be Imported To, select the New button.
* Name the database "aaron_minnick".
* Click Ok.
* Navigate to the tab called Import Progress and click Start Import at the bottom right corner of the window.

After you are finished with the above steps, reopen the Navigator > Schemas tab. Right click and select Refresh All. The aaron_minnick database should appear.

### appsettings.json
In order to configure the project, you will need to create a file appsettings.json in the HairSalon project directory, with the following contents:

```
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=aaron_minnick;uid=root;pwd=[YOUR PASSWORD HERE];"
  }
}
```
Be sure to replace the password value with your actual password.

### Known Bugs/Issues:
* None

_Thanks for reading! Please feel free to contact me with feedback!_
***
#### [License: MIT](https://opensource.org/licenses/MIT)
#### Copyright (c) 2021 Aaron Minnick
