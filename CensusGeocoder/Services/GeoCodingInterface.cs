using System;
using CensusGeocoder.Models;

namespace CensusGeocoder.Services
{
    public interface GeoCodingInterface<TGeoCodingResultInterface> where TGeoCodingResultInterface : GeoCodingResultInterface
    {
        Task<List<TGeoCodingResultInterface>> GetGeocodingResults(List<string> addresses, string benchmark);
    }

}

