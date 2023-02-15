using CensusGeocoder.Models;
using Newtonsoft.Json;

namespace CensusGeocoder.Services
{
    public class GeoCodingService<TGeoCodingResultInterface> : GeoCodingInterface<TGeoCodingResultInterface> where TGeoCodingResultInterface : GeoCodingResultInterface
    {
        private const string _url = "https://geocoding.geo.census.gov/geocoder/locations/onelineaddress?address=";

        /// <summary>
        /// Used to hit the goecoding api to get address information. 
        /// </summary>
        /// <param name="addresses"></param>
        /// <param name="benchmark"></param>
        /// <returns></returns>
        public async Task<List<TGeoCodingResultInterface>> GetGeocodingResults(List<string> addresses, string benchmark)
        {
            var results = new List<TGeoCodingResultInterface>();

            foreach (var address in addresses)
            {
                var url = $"{_url}{address}&benchmark={benchmark}&format=json";
                var client = new HttpClient();
                var response = await client.GetAsync(url);

                Console.WriteLine($"Retrieving data from {url}..." + Environment.NewLine + Environment.NewLine);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<TGeoCodingResultInterface>(content);
                    if (result != null)
                        results.Add(result);
                }
                else
                {
                    Console.WriteLine("Failed to retrieve data from the endpoint.");
                }
            }

            return results;
        }
    }
}