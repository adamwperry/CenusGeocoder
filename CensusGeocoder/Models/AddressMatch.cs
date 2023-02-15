namespace CensusGeocoder.Models
{
    public class AddressMatch
    {
        public TigerLine? TigerLine { get; set; }
        public Coordinates? Coordinates { get; set; }
        public AddressComponents? AddressComponents { get; set; }
        public string? MatchedAddress { get; set; }
    }
}


