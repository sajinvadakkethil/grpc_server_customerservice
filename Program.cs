var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<CustomerRepository>();
builder.Services.AddGrpc();

var app = builder.Build();
app.MapGrpcService<CustomerServiceImpl>();
app.MapGet("/", () => "CustomerService is running");

app.Run();
