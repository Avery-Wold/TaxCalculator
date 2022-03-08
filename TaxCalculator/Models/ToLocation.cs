using System;
using Newtonsoft.Json;

namespace TaxCalculatorApp.Models
{
    public class ToLocation
    {
		[JsonProperty("to_country")]
		public string ToCountry { get; set; }

		[JsonProperty("to_state")]
		public string ToState { get; set; }

		[JsonProperty("to_city")]
		public string ToCity { get; set; }

		[JsonProperty("to_street")]
		public string ToStreet { get; set; }

		[JsonProperty("to_zip")]
		public string ToZip { get; set; }
	}
}
