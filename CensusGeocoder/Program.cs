using CensusGeocoder.Models;
using CensusGeocoder.Objects;
using CensusGeocoder.Services;
using Figgle;
using Microsoft.Extensions.DependencyInjection;


namespace CensusGeocoder
{
    partial class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();


            Console.WriteLine(FiggleFonts.Standard.Render("GeoDecoder"));
            Arguments arguments = new Arguments(args);

            //exit app if no input file is provided
            if (string.IsNullOrEmpty(arguments.Inputfile) || string.IsNullOrEmpty(arguments.Outputfile))
            {
                Console.WriteLine("No input or output file provided. Exiting application.");
                Environment.Exit(0);
                return;
            }

            //if input file does not exist, exit app
            if (!File.Exists(arguments.Inputfile))
            {
                Console.WriteLine("Input file does not exist. Exiting application.");
                Environment.Exit(0);
                return;
            }

            var jsonService = serviceProvider.GetService<JsonServiceInterface<GeoCodingResult>>();
            var geoCodingService = serviceProvider.GetService<GeoCodingInterface<GeoCodingResult>>();

            //if either service is null, exit app
            if (jsonService == null || geoCodingService == null)
            {
                Console.WriteLine("Service is null. Exiting application.");
                Environment.Exit(0);
                return;
            }

            var Addresses = await jsonService.ReadJsonFileAsync(arguments.Inputfile);
            var results = await geoCodingService.GetGeocodingResults(Addresses, arguments.Benchmark);

            if (await jsonService.WriteJsonFileAsync(arguments.Outputfile, results))
            {
                Console.WriteLine("File written successfully.");
            }
            else
            {
                Console.WriteLine("File write failed.");
            }

            Environment.Exit(0);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<JsonServiceInterface<GeoCodingResult>, JsonService<GeoCodingResult>>();
            services.AddScoped<GeoCodingInterface<GeoCodingResult>, GeoCodingService<GeoCodingResult>>();
        }
    }
}