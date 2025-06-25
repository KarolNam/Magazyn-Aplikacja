namespace WarehouseAPI.Database.Entities
{
	public class ReceiptItem : BaseEntity
	{
		public required string ProductName { get; set; }
		public required string Unit { get; set; }
		public decimal Quantity { get; set; }

		public int ReceiptDocumentId { get; set; }
		public required ReceiptDocument ReceiptDocument { get; set; }
	}
}
