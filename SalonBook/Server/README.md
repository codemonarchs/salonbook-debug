# First Time Setup
1. Download SQL Server 2019 Developer edition
	- https://www.microsoft.com/en-us/sql-server/sql-server-downloads
2. Install using the BASIC setup.
3. Install global ef core tools if you don't already have it:
	- dotnet tool install --global dotnet-ef
4. Open up Terminal or Developer Powershell within Visual Studio and change directory to the Server directory.
	- cd SalonBook\Server
5. Create the databases:
	- dotnet ef database update --context UsersDbContext
	- dotnet ef database update --context MainDbContext
6. Confirm server PORT settings are correct for usage with external auth provider dev setup:
	- Right-click SalonBook.Server
	- Click Properties
	- Click Debug->General
	- Click 'Open debug launch profiles UI'
	- Scroll down to App URL:
		- Set value to: https://localhost:7007;http://localhost:5007
7. Run SalonBook.Server
	- If local debug url configuration is not set to localhost:7007 then adjust the settings in Debug Profile.
8. Done

# Hot Reload
Inside SalonBook.Client run:
	- dotnet watch

# Database Information
- SalonBook.Users
	- Specific to identity and user logins only.
- SalonBook.Main
	- Specific to application data.

# Adding New Migrations (per context)
- SalonBook.Users
	- dotnet ef migrations add NameOfMigration --context UsersDbContext --output-dir Data/Users/Migrations
- SalonBook.Main
	- dotnet ef migrations add NameOfMigration --context MainDbContext --output-dir Data/Main/Migrations
