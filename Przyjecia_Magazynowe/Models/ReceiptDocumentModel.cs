using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przyjecia_Magazynowe.Models
{
	public class ReceiptDocumentModel
	{
		public int Id { get; set; }
		public DateTime Date {  get; set; }
		public string Symbol { get; set; }
		public int ContractorId { get; set; }
		public string ContractorName { get; set; }
	}
}
