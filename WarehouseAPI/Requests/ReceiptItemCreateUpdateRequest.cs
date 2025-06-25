namespace WarehouseAPI.Requests
{
	public class ReceiptItemCreateUpdateRequest
	{
		public required string ProductName { get; set; }
		public required string Unit { get; set; }
		public decimal Quantity { get; set; }
		public int ReceiptDocumentId { get; set; }
	}
}
