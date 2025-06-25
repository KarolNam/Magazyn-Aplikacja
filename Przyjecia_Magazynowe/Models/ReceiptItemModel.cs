using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przyjecia_Magazynowe.Models
{
	public class ReceiptItemModel
	{
		public int Id { get; set; }
		public string ProductName { get; set; }
		public string Unit { get; set; }
		public decimal Quantity { get; set; }
		public int ReceiptDocumentId { get; set; }
		public string ReceiptDocumentSymbol { get; set; }
	}
}
