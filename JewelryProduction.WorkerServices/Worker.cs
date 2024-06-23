using JewelryProduction.BusinessObject.Models;
using JewelryProduction.Service.Request.Material;
using JewelryProduction.Service.Service.MaterialImpl;
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

                    await Task.Delay(3000, stoppingToken);
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
