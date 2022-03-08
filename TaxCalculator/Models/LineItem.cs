using System;
using Newtonsoft.Json;

namespace TaxCalculatorApp.Models
{
    public class LineItem
    {
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("quantity")]
		public int Quantity { get; set; }

		[JsonProperty("product_tax_code")]
		public string ProductTaxCode { get; set; }

		[JsonProperty("unit_price")]
		public decimal UnitPrice { get; set; }

		[JsonProperty("discount")]
		public decimal Discount { get; set; }
	}
}
