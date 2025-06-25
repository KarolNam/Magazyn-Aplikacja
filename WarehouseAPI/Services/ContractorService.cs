using Microsoft.EntityFrameworkCore;
using WarehouseAPI.Database;
using WarehouseAPI.Database.Entities;
using WarehouseAPI.DTOs;
using WarehouseAPI.Requests;

namespace WarehouseAPI.Services
{
	public class ContractorService
	{
		private readonly AppDbContext _dbContext;

		public ContractorService(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<List<ContractorDto>> GetAllContractorsAsync()
		{
			return await _dbContext.Contractors.Select(c => new ContractorDto
			{
				Id = c.Id,
				Symbol = c.Symbol,
				Name = c.Name
			}).ToListAsync();
		}
		public async Task<ContractorDto?> GetContractorByIdAsync(int id)
		{
			return await _dbContext.Contractors.Where(c => c.Id == id).Select(c => new ContractorDto
			{
				Id = c.Id,
				Symbol = c.Symbol,
				Name = c.Name
			}).FirstOrDefaultAsync();
		}
		public async Task<ContractorDto?> CreateContractorAsync(ContractorCreateUpdateRequest request)
		{
			var contractor = new Contractor
			{
				Symbol = request.Symbol,
				Name = request.Name
			};

			_dbContext.Contractors.Add(contractor);

			await _dbContext.SaveChangesAsync();

			return new ContractorDto
			{
				Id = contractor.Id,
				Symbol = contractor.Symbol,
				Name = contractor.Name
			};
		}
		public async Task<ContractorDto?> UpdateContractorAsync(int id, ContractorCreateUpdateRequest request)
		{
			var contractor = await _dbContext.Contractors.FindAsync(id);
			if (contractor == null)
				return null;

			contractor.Symbol = request.Symbol;
			contractor.Name = request.Name;

			await _dbContext.SaveChangesAsync();

			return new ContractorDto
			{
				Symbol = contractor.Symbol,
				Name = contractor.Name,
			};
		}
	}
}