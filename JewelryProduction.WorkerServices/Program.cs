using JewelryProduction.Service.Service.MaterialImpl;
using JewelryProduction.Service.Service.ProductsImpl;
using JewelryProduction.Service.Service.ProductStoneImpl;
using JewelryProduction.Service.Service.ProductTypeImpl;
using JewelryProduction.WorkerServices;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductTypeService, ProductTypeService>();
builder.Services.AddScoped<IProductStoneService, ProductStoneService>();

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
