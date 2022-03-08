using System;
using Newtonsoft.Json;

namespace TaxCalculatorApp.Models
{
    public class FromLocation
    {
		[JsonProperty("from_country")]
		public string FromCountry { get; set; }

		[JsonProperty("from_state")]
		public string FromState { get; set; }

		[JsonProperty("from_city")]
		public string FromCity { get; set; }

		[JsonProperty("from_street")]
		public string FromStreet { get; set; }

		[JsonProperty("from_zip")]
		public string FromZip { get; set; }
	}
}
