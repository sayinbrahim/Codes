using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using MapboxExample.Models;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace MapboxExample.Services
{
    public interface IAstrologyService
    {
        Task<PlanetData> GetPlanetData(string name, DateTime birthDate, double longitude, double latitude);
    }

    public class AstrologyService : IAstrologyService
    {
        private readonly HttpClient _httpClient;

        public AstrologyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PlanetData> GetPlanetData(string name, DateTime birthDate, double longitude, double latitude)
        {
            // Astroloji API isteği ve işlemleri buraya gelecek
            // Önceki örnek kodu buraya kopyalayabilirsiniz
            // Astroloji API endpoint ve parametreleri
            string apiUrl = "https://json.astrologyapi.com/v1/western_horoscope";
            string username = "624137"; // API anahtarınızı buraya ekleyin
            string password = "027b25ebb8e5ca85fc28997ce3763d81";
            string apiKey = "API_KEY";


            // Astroloji API'ye gönderilecek veri
            var requestData = new
            {
                name = name,
                dob = birthDate.ToString("yyyy-MM-dd"),
                lon = longitude,
                lat = latitude,
                tzone = "Asia/Istanbul" // Zaman dilimini uygun şekilde ayarlayın
            };

            try
            {
                // Astroloji API'ye isteği gönder
                var response = await _httpClient.PostAsJsonAsync($"{apiUrl}?accesskey={apiKey}", requestData);

                // İsteğin başarılı olup olmadığını kontrol et
                response.EnsureSuccessStatusCode();

                // Yanıtı JSON olarak çözümle
                var responseContent = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<PlanetData>(responseContent);

                // Gerekli gezegen verilerini döndür
                return responseData;
            }
            catch (Exception ex)
            {
                // İstek sırasında bir hata oluştuysa burada işleyebilirsiniz
                Console.WriteLine("Hata: " + ex.Message);
                return null;
            }
        }
    }
}
