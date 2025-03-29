public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<TodoDbContext>();
        services.AddTransient<RequestLoggingMiddleware>();
        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseMiddleware<RequestLoggingMiddleware>();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}