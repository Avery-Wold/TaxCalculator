using System;
using Newtonsoft.Json;

namespace TaxCalculatorApp.Models
{
    public class NexusAddress
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        public Location NexusLocation { get; set; }
    }
}
