namespace JewelryProduction.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // Tạo một instance của HttpClient
                using (var client = new HttpClient())
                {
                    // Gọi API
                    try
                    {
                        var response = await client.GetAsync("http://api.btmc.vn/api/BTMCAPI/getpricebtmc?key=3kd8ub1llcg9t45hnoh8hmn7t5kc2v");

                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            Console.WriteLine(content);
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
}
