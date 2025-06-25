using WarehouseAPI.Database.Entities;

namespace WarehouseAPI.Requests
{
	public class ContractorCreateUpdateRequest
	{
		public required string Symbol { get; set; }
		public required string Name { get; set; }
	}
}
