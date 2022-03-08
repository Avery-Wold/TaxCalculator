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

		public FromLocation FromLocation { get; set; }

		public ToLocation ToLocation { get; set; }
	}
}
