using System;
using CensusGeocoder.Models;

namespace CensusGeocoder.Services
{
	interface JsonServiceInterface<TGeoCodingResultInterface> where TGeoCodingResultInterface : GeoCodingResultInterface
    {
        Task<List<string>> ReadJsonFileAsync(string filePath);
        Task<bool> WriteJsonFileAsync(string filePath, List<TGeoCodingResultInterface> results);
    }
}

