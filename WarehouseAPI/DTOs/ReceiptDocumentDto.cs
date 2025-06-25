namespace WarehouseAPI.DTOs
{
	public class ReceiptDocumentDto
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public required string Symbol { get; set; }
		public int ContractorId { get; set; }
		public required string ContractorName { get; set;}
	}
}
