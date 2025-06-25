using Microsoft.EntityFrameworkCore;
using WarehouseAPI.Database;
using WarehouseAPI.Database.Entities;
using WarehouseAPI.DTOs;
using WarehouseAPI.Requests;

namespace WarehouseAPI.Services
{
	public class ReceiptDocumentService
	{
		private readonly AppDbContext _dbContext;

		public ReceiptDocumentService(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<List<ReceiptDocumentDto>> GetAllReceiptDocumentsAsync()
		{
			return await _dbContext.ReceiptDocuments.Select(rd => new ReceiptDocumentDto
			{
				Id = rd.Id,
				Date = rd.Date,
				Symbol = rd.Symbol,
				ContractorId = rd.ContractorId,
				ContractorName = rd.Contractor.Name
			}).ToListAsync();
		}
		public async Task<ReceiptDocumentDto?> GetReceiptDocumentByIdAsync(int id)
		{
			return await _dbContext.ReceiptDocuments.Where(rd => rd.Id == id).Select(rd => new ReceiptDocumentDto
			{
				Id = rd.Id,
				Date = rd.Date,
				Symbol = rd.Symbol,
				ContractorId = rd.ContractorId,
				ContractorName = rd.Contractor.Name
			}).FirstOrDefaultAsync();
		}
		public async Task<List<ContractorReceiptDocumentsDto>> GetReceiptDocumentsByContractorIdAsync(int contractorId)
		{
			return await _dbContext.ReceiptDocuments.Include(rd => rd.Items).Where(rd => rd.ContractorId == contractorId).Select(rd => new ContractorReceiptDocumentsDto
			{
				Id = rd.Id,
				Date = rd.Date,
				Symbol = rd.Symbol,
				ItemsCount = rd.Items.Count()
			}).ToListAsync();
		}
		public async Task<ReceiptDocumentDto?> CreateReceiptDocumentAsync(ReceiptDocumentCreateUpdateRequest request)
		{
			var contractor = await _dbContext.Contractors.FindAsync(request.ContractorId);
			if (contractor == null) 
				return null;

			var receiptDocument = new ReceiptDocument
			{
				Date = request.Date,
				Symbol = request.Symbol,
				ContractorId = contractor.Id,
				Contractor = contractor,
			};

			_dbContext.ReceiptDocuments.Add(receiptDocument);
			await _dbContext.SaveChangesAsync();

			return new ReceiptDocumentDto
			{
				Id = receiptDocument.Id,
				Date = receiptDocument.Date,
				Symbol = receiptDocument.Symbol,
				ContractorName = receiptDocument.Contractor.Name
			};
		}
		public async Task<ReceiptDocumentDto?> UpdateReceiptDocumentAsync(int id, ReceiptDocumentCreateUpdateRequest request)
		{
			var receiptDocument = await _dbContext.ReceiptDocuments.FindAsync(id);
			if (receiptDocument == null)
				return null;

			var contractor = await _dbContext.Contractors.FindAsync(request.ContractorId);
			if (contractor == null)
				return null;

			receiptDocument.Date = request.Date;
			receiptDocument.Symbol = request.Symbol;
			receiptDocument.ContractorId = request.ContractorId;
			receiptDocument.Contractor = contractor;

			await _dbContext.SaveChangesAsync();

			return new ReceiptDocumentDto
			{
				Date = receiptDocument.Date,
				Symbol = receiptDocument.Symbol,
				ContractorName = receiptDocument.Contractor.Name
			};
		}
	}
}
