namespace WarehouseAPI.Database.Entities
{
	public class Contractor : BaseEntity
	{
		public required string Symbol { get; set; }
		public required string Name { get; set; }

		public ICollection<ReceiptDocument> Documents { get; set; } = new List<ReceiptDocument>();
	}
}
