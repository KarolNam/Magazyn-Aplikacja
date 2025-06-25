namespace WarehouseAPI.Database.Entities
{
	public class ReceiptDocument : BaseEntity
	{
		public DateTime Date { get; set; }
		public required string Symbol { get; set; }

		public int ContractorId { get; set; }
		public required Contractor Contractor { get; set; }

		public ICollection<ReceiptItem> Items { get; set; } = new List<ReceiptItem>();
	}
}
