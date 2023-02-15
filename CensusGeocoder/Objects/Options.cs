using CommandLine;

namespace CensusGeocoder.Objects
{
    /// <summary>
    /// Options class used with the CommandLine Library
    /// </summary>
    public class Options
    {
        [Option('f', "file", Required = true, HelpText = "input json file.")]
        public string? File { get; set; }

        [Option('o', "output", Required = true, HelpText = "output json file.")]
        public string? Output { get; set; }

        [Option('b', "benchmark", Required = false, HelpText = "benchmark - census year. The default is 2020.")]
        public string? Benchmark { get; set; }

    }
}


