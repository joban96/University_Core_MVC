1. Open the Solution in Visual Studio
2. Build the project 
3. Navigate to tools ans select Nuget Package manager -> Package Manager Console (PMC)
4. On the console execute the following command
a) Update-Database Identity -context ApplicationDbContext
b) update-database University -Context University_Core_DbContext
5. After migration is successful Run the project

