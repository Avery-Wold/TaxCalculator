using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TaxCalculatorApp.Models
{
    public class TaxOrder
    {
		[JsonProperty("amount")]
		public decimal Amount { get; set; }

		[JsonProperty("shipping")]
		public decimal Shipping { get; set; }

		[JsonProperty("nexus_addresses")]
		public List<NexusAddress> NexusAddresses { get; set; }

		[JsonProperty("line_items")]
		public List<LineItem> LineItems { get; set; }

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
