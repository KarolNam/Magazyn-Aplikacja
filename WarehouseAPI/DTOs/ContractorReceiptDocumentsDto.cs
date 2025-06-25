using System.Text.Json.Serialization;

namespace WarehouseAPI.DTOs
{
	public class ContractorReceiptDocumentsDto
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public required string Symbol { get; set; }
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public List<ReceiptItemDto>? Items { get; set; } = null;
		public int ItemsCount { get; set; }
	}
}
