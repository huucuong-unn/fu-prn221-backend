using JewelryProduction.BusinessObject.Models;
using JewelryProduction.Service.Request.Material;
using JewelryProduction.Service.Request.Product;
using JewelryProduction.Service.Service.MaterialImpl;
using JewelryProduction.Service.Service.ProductsImpl;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static System.Formats.Asn1.AsnWriter;

namespace JewelryProduction.WorkerServices
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        private readonly IServiceScopeFactory _serviceScopeFactory;

        public Worker(ILogger<Worker> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var materialService = scope.ServiceProvider.GetRequiredService<IMaterialService>();
                    var productService = scope.ServiceProvider.GetRequiredService<IProductService>();

                    using (var client = new HttpClient())
                    {
                        try
                        {
                            var response = await client.GetAsync("http://api.btmc.vn/api/BTMCAPI/getpricebtmc?key=3kd8ub1llcg9t45hnoh8hmn7t5kc2v");

                            if (response.IsSuccessStatusCode)
                            {
                                var content = await response.Content.ReadAsStringAsync();

                                dynamic data = JsonConvert.DeserializeObject(content);

                                Console.WriteLine(data);

                                int count = 1;

                                foreach (var item in data.DataList.Data)
                                {
                                    string valuePb = item["@pb_" + count.ToString()];
                                    string valuePs = item["@ps_" + count.ToString()];
                                    string valueN = item["@n_" + count.ToString()];
                                    string valueRow = item["@row"];

                                    if (valueRow.Equals("3") || valueRow.Equals("7") || valueRow.Equals("13"))
                                    {
                                        if (valueN.Contains("BTMC"))
                                        {
                                            Material material = new Material
                                            {
                                                BuyingPrice = ParseDecimal(valuePb),
                                                SalePrice = ParseDecimal(valuePs),
                                                CreateDate = DateTime.Now,
                                                UpdateDate = DateTime.Now
                                            };

                                            BaseMaterialRequest request = new BaseMaterialRequest();
                                            request.name = "BTMC";
                                            request.salePrice = (decimal)material.SalePrice;
                                            request.buyingPrice = (decimal)material.BuyingPrice;
                                            request.CreateDate = (DateTime)material.CreateDate;
                                            request.UpdateDate = (DateTime)material.UpdateDate;
                                            materialService.UpdateByName(request);

                                            JewelryProductionContext context = new JewelryProductionContext();
                                            var materialByname = context.Materials.FirstOrDefault(m => m.Name.Equals("BTMC"));
                                            List<BusinessObject.Models.Product> productsByMaterialId = context.Products.Include(p => p.ProductStones)
                                                                                                                        .ThenInclude(ps => ps.Stone)
                                                                                                                        .Where(p => p.MaterialId == materialByname.Id)
                                                                                                                        .ToList();

                                            foreach (var product in productsByMaterialId)
                                            {
                                                var productType = context.ProductTypes.FirstOrDefault(pt => pt.Id == product.ProductTypeId);
                                                /*var stonePrices = context.ProductStones.Where(ps => ps.ProductId == product.Id).ToList().Sum(ps => ps.Stone.Price);*/
                                                var stonePrices = context.ProductStones.Where(ps => ps.ProductId.Equals(product.Id))
                                                                                        .Include(ps => ps.Stone)
                                                                                        .ToList()
                                                                                        .Sum(ps => ps.Stone != null ? ps.Stone.Price : 0);


                                                product.Price = (material.BuyingPrice * (product.Weight / 1000)) + productType.Wages + stonePrices;
                                                product.UpdateDate = DateTime.Now;

                                                GetProductRequest productRequest = new GetProductRequest();
                                                productRequest.Name = product.Name;
                                                productRequest.Description = product.Description;
                                                productRequest.Weight = product.Weight;
                                                productRequest.Price = product.Price;
                                                productRequest.CreateDate = product.CreateDate;
                                                productRequest.UpdateDate = DateTime.Now;

                                                productService.UpdateProduct(product.Id, productRequest);
                                            }

                                        }

                                        if (valueN.Contains("HTBT"))
                                        {
                                            Material material = new Material
                                            {
                                                BuyingPrice = ParseDecimal(valuePb),
                                                SalePrice = ParseDecimal(valuePs),
                                                CreateDate = DateTime.Now,
                                                UpdateDate = DateTime.Now
                                            };

                                            BaseMaterialRequest request = new BaseMaterialRequest();
                                            request.name = "HTBT";
                                            request.salePrice = (decimal)material.SalePrice;
                                            request.buyingPrice = (decimal)material.BuyingPrice;
                                            request.CreateDate = (DateTime)material.CreateDate;
                                            request.UpdateDate = (DateTime)material.UpdateDate;
                                            materialService.UpdateByName(request);

                                            JewelryProductionContext context = new JewelryProductionContext();
                                            var materialByname = context.Materials.FirstOrDefault(m => m.Name.Equals("HTBT"));
                                            List<BusinessObject.Models.Product> productsByMaterialId = context.Products
                                                                            .Where(p => p.MaterialId == materialByname.Id)
                                                                            .ToList();

                                            foreach (var product in productsByMaterialId)
                                            {
                                                var productType = context.ProductTypes.FirstOrDefault(pt => pt.Id == product.ProductTypeId);
                                                var stonePrices = context.ProductStones.Where(ps => ps.ProductId == product.Id)
                                                                                        .Include(ps => ps.Stone)
                                                                                        .ToList()
                                                                                        .Sum(ps => ps.Stone.Price);

                                                product.Price = (material.BuyingPrice * (product.Weight / 1000)) + productType.Wages + stonePrices;
                                                product.UpdateDate = DateTime.Now;

                                                GetProductRequest productRequest = new GetProductRequest();
                                                productRequest.Name = product.Name;
                                                productRequest.Description = product.Description;
                                                productRequest.Weight = product.Weight;
                                                productRequest.Price = product.Price;
                                                productRequest.CreateDate = product.CreateDate;
                                                productRequest.UpdateDate = DateTime.Now;

                                                productService.UpdateProduct(product.Id, productRequest);
                                            }
                                        }

                                        if (valueN.Contains("SJC"))
                                        {
                                            Material material = new Material
                                            {
                                                BuyingPrice = ParseDecimal(valuePb),
                                                SalePrice = ParseDecimal(valuePs),
                                                CreateDate = DateTime.Now,
                                                UpdateDate = DateTime.Now
                                            };

                                            BaseMaterialRequest request = new BaseMaterialRequest();
                                            request.name = "SJC";
                                            request.salePrice = (decimal)material.SalePrice;
                                            request.buyingPrice = (decimal)material.BuyingPrice;
                                            request.CreateDate = (DateTime)material.CreateDate;
                                            request.UpdateDate = (DateTime)material.UpdateDate;
                                            materialService.UpdateByName(request);

                                            JewelryProductionContext context = new JewelryProductionContext();
                                            var materialByname = context.Materials.FirstOrDefault(m => m.Name.Equals("SJC"));
                                            List<BusinessObject.Models.Product> productsByMaterialId = context.Products
                                                                            .Where(p => p.MaterialId == materialByname.Id)
                                                                            .ToList();

                                            foreach (var product in productsByMaterialId)
                                            {
                                                var productType = context.ProductTypes.FirstOrDefault(pt => pt.Id == product.ProductTypeId);
                                                var stonePrices = context.ProductStones.Where(ps => ps.ProductId == product.Id).Include(ps => ps.Stone).ToList().Sum(ps => ps.Stone.Price);

                                                product.Price = (material.BuyingPrice * (product.Weight / 1000)) + productType.Wages + stonePrices;
                                                product.UpdateDate = DateTime.Now;

                                                GetProductRequest productRequest = new GetProductRequest();
                                                productRequest.Name = product.Name;
                                                productRequest.Description = product.Description;
                                                productRequest.Weight = product.Weight;
                                                productRequest.Price = product.Price;
                                                productRequest.CreateDate = product.CreateDate;
                                                productRequest.UpdateDate = DateTime.Now;

                                                productService.UpdateProduct(product.Id, productRequest);
                                            }
                                        }

                                    }

                                    count++;
                                    Console.WriteLine(item);
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Lỗi: {response.StatusCode}");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Lỗi khi gọi API: {ex.Message}");
                        }
                    }

                    await Task.Delay(86400000, stoppingToken); //1ngay: 86400000
                }
            }
        }

        private decimal ParseDecimal(string value)
        {
            if (decimal.TryParse(value, out decimal result))
            {
                return result;
            }
            else
            {
                Console.WriteLine($"Không thể parse giá trị '{value}' sang decimal.");
                return 0;
            }
        }
    }
}
