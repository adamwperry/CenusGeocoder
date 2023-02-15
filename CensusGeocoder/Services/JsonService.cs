using System;
using CensusGeocoder.Models;
using Newtonsoft.Json;

namespace CensusGeocoder.Services
{

    public class JsonService<TGeoCodingResultInterface>
        : JsonServiceInterface<TGeoCodingResultInterface> where TGeoCodingResultInterface : GeoCodingResultInterface
    {
        /// <summary>
        /// Used to read a json file into a list of addresses. 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public async Task<List<string>> ReadJsonFileAsync(string filePath)
        {
            var addresses = new List<string>();

            using (StreamReader r = new StreamReader(filePath))
            {
                string json = await r.ReadToEndAsync();
                if (string.IsNullOrEmpty(json))
                    return addresses;

                dynamic jsonObj = JsonConvert.DeserializeObject<dynamic>(json) ?? new { };
                foreach (var address in jsonObj.addresses)
                {
                    addresses.Add(address.address.ToString());
                }
            }

            return addresses;
        }

        /// <summary>
        /// Used to write a GeoCodingResultInterface to a json file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="results"></param>
        /// <returns></returns>
        public async Task<bool> WriteJsonFileAsync(string filePath, List<TGeoCodingResultInterface> results)
        {
            try
            {
                var json = JsonConvert.SerializeObject(results, Formatting.Indented);
                await File.WriteAllTextAsync(filePath, json);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
