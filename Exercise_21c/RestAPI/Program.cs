var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IPaymentService, PaymentService>();

var app = builder.Build();

app.MapGet("/", () => "Wonderful webshop - you may close the browser window!");
app.MapControllers();

app.Run();
