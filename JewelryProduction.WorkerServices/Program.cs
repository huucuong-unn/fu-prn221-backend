using JewelryProduction.Service.Service.MaterialImpl;
using JewelryProduction.WorkerServices;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
