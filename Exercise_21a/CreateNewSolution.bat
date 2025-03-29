dotnet new sln
md Weather
md Weather.Tests
cd Weather
dotnet new classlib
cd ..
dotnet sln add Weather
cd Weather.Tests
dotnet new mstest
dotnet add reference ../Weather
cd ..
dotnet sln add Weather.Tests