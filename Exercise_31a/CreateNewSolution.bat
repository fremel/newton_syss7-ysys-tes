dotnet new sln
md MyApp
md MyApp.Benchmark
cd MyApp
dotnet new classlib
cd ..
dotnet sln add MyApp
cd MyApp.Benchmark
dotnet new console
dotnet add reference ../MyApp
cd ..
dotnet sln add MyApp.Benchmark