using JewelryProduction.BusinessObject.Models;
using JewelryProduction.Service.CustomerImpl;
using JewelryProduction.Service.Service.Account;
using JewelryProduction.Service.Service.Counter;
using JewelryProduction.Service.Service.ProductsImpl;
using JewelryProduction.Service.Service.ProductTypeImpl;
using JewelryProduction.Service.Service.PromotionImpl;
using JewelryProduction.Service.Service.Stone;
using JewelryProduction.Service.Service.UserCounter;
using JewelryProduction.Service.Service.WarrantyImpl;
using Microsoft.EntityFrameworkCore;
using JewelryProduction.Service.Service.ProductStoneImpl;
using JewelryProduction.Service.Service.Authentication;
using JewelryProduction.WorkerServices;
using JewelryProduction.Service.Service.MaterialImpl;

var builder = WebApplication.CreateBuilder(args);
/*#region Authentication
var tokenValidationParams = new TokenValidationParameters
{
    ValidateIssuer = false,
    ValidateAudience = false,
    ValidateLifetime = true,
    RequireExpirationTime = false,
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secretkey"]))
};

builder.Services.AddSingleton(tokenValidationParams);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.SaveToken = true;
        opt.TokenValidationParameters = tokenValidationParams;
    });
builder.Services.AddMvc(opt =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    opt.Filters.Add(new AuthorizeFilter(policy));
});
builder.Services.AddHttpContextAccessor();
#endregion*/

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICounterService, CounterService>();
builder.Services.AddScoped<IUserCounterService, UserCounterService>();
builder.Services.AddScoped<IWarrantyService, WarrantyService>();
builder.Services.AddScoped<IPromotionService, PromotionService>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IStoneService, StoneService>();
builder.Services.AddScoped<IProductTypeService, ProductTypeService>();
builder.Services.AddScoped<IProductStoneService, ProductStoneService>();

// Add the dependent service( them service o day nha may anh iu)
builder.Services.AddScoped<JwtService>();

/*
// Add services to the container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});*/


// Sua database iu dau
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IMaterialService, MaterialService>();

builder.Services.AddHostedService<Worker>();

builder.Services.AddDbContext<JewelryProductionContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionStringDB")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options => options
.WithOrigins(new[] {"https://jewellry.vercel.app", "http://localhost:3001"})
.AllowCredentials()
.AllowAnyHeader()
.AllowAnyMethod()
);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
