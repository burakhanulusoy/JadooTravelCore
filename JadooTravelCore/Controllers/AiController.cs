using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace JadooTravelCore.Controllers
{
    [AllowAnonymous]
    public class AiController : Controller
    {
        private readonly string myapikey = "YOUR APIKEY";
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                ViewBag.Error = "Lütfen bir şehir giriniz!";
                return View();
            }

            ViewBag.City = city; // Şehir adını ViewBag'e ekle

            string prompt = $"Sen bir seyahat rehberisin. '{city}' şehrinde gezilecek en önemli 10 yeri listele. Her yer için başlık ve kısa açıklama ekle. Format: 'Başlık - Açıklama'";

            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {myapikey}");
                    client.Timeout = TimeSpan.FromSeconds(30);

                    var requestBody = new
                    {
                        model = "gpt-4o-mini",
                        messages = new[]
                        {
                    new { role = "user", content = prompt }
                },
                        max_tokens = 1000
                    };

                    string jsonBody = JsonSerializer.Serialize(requestBody);
                    var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);

                    if (!response.IsSuccessStatusCode)
                    {
                        ViewBag.Error = "AI servisine ulaşılamıyor. Lütfen daha sonra tekrar deneyin.";
                        return View();
                    }

                    string responseString = await response.Content.ReadAsStringAsync();

                    using (JsonDocument doc = JsonDocument.Parse(responseString))
                    {
                        var root = doc.RootElement;

                        if (root.TryGetProperty("choices", out JsonElement choices) &&
                            choices.GetArrayLength() > 0)
                        {
                            var message = choices[0].GetProperty("message").GetProperty("content").GetString();

                            // AI cevabını satırlara ayır, boş satırları temizle
                            var lines = message.Split('\n', StringSplitOptions.RemoveEmptyEntries)
                                               .Select(x => x.Trim())
                                               .Where(x => !string.IsNullOrWhiteSpace(x))
                                               .Take(10) // Maksimum 10 satır
                                               .ToList();

                            ViewBag.ResultList = lines;
                        }
                        else
                        {
                            ViewBag.Error = "AI'den beklenen yanıt alınamadı.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Bir hata oluştu: {ex.Message}";
            }

            return View();

        }
    }
}