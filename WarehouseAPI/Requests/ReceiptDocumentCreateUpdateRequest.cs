namespace WarehouseAPI.Requests
{
	public class ReceiptDocumentCreateUpdateRequest
	{
		public DateTime Date { get; set; }
		public required string Symbol { get; set; }
		public int ContractorId { get; set; }
	}
}
