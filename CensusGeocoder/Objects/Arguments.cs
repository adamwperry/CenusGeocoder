using System;
using CommandLine; 


namespace CensusGeocoder.Objects
{

    /// <summary>
    /// This Class parses the options / arguments into a poco
    /// </summary>
	public class Arguments
	{
        public string? Inputfile { get; set; } = null;
        public string? Outputfile { get; set; } = null;
        /// <summary>
        /// The default is 2020 - the last year of the census occurred when this was created. 
        /// </summary>
        public string Benchmark { get; set; } = "2020";

        public Arguments(string[] args)
		{
            //print argument information here and map them the properties 
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(o =>
                {
                    Console.WriteLine($"File input file set. Current Arguments: -f {o.File}");
                    Console.WriteLine($"File output file set. Current Arguments: -o {o.Output}");

                    Inputfile = o.File;
                    Outputfile = o.Output;

                    if (!string.IsNullOrEmpty(o.Benchmark))
                    {
                        Console.WriteLine($"Benchmark set. Current Arguments: -b {o.Benchmark}");
                        Benchmark = o.Benchmark;
                    }

                });
		}
	}
}

