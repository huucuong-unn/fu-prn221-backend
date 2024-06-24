using JewelryProduction.Service.Service.MaterialImpl;
using JewelryProduction.Service.Service.ProductsImpl;
using JewelryProduction.WorkerServices;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
