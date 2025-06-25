using WarehouseAPI.Database.Entities;
using WarehouseAPI.Database;
using WarehouseAPI.DTOs;
using WarehouseAPI.Requests;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace WarehouseAPI.Services
{
	public class ReceiptItemService
	{
		private readonly AppDbContext _dbContext;

		public ReceiptItemService(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<List<ReceiptItemDto>> GetAllReceiptItemsAsync()
		{
			return await _dbContext.ReceiptItems.Select(ri => new ReceiptItemDto
			{
				Id = ri.Id,
				ProductName = ri.ProductName,
				Unit = ri.Unit,
				Quantity = ri.Quantity
			}).ToListAsync();
		}
		public async Task<ReceiptItemDto?> GetReceiptItemByIdAsync(int id)
		{
			return await _dbContext.ReceiptItems.Where(ri => ri.Id == id).Select(ri => new ReceiptItemDto
			{
				Id = ri.Id,
				ProductName = ri.ProductName,
				Unit = ri.Unit,
				Quantity = ri.Quantity
			}).FirstOrDefaultAsync();
		}
		public async Task<List<ReceiptItemDto>> GetReceiptItemsByReceiptDocumentIdAsync(int receiptDocumentId)
		{
			return await _dbContext.ReceiptItems.Where(ri => ri.ReceiptDocumentId == receiptDocumentId).Select(ri => new ReceiptItemDto
			{
				Id = ri.Id,
				ProductName = ri.ProductName,
				Unit = ri.Unit,
				Quantity = ri.Quantity,
				ReceiptDocumentId = ri.ReceiptDocumentId
			}).ToListAsync();
		}
		public async Task<ReceiptItemDto?> CreateReceiptItemAsync([FromBody] ReceiptItemCreateUpdateRequest request)
		{
			var receiptDocument = await _dbContext.ReceiptDocuments.FindAsync(request.ReceiptDocumentId);
			if (receiptDocument == null)
				return null;

			var receiptItem = new ReceiptItem
			{
				ProductName = request.ProductName,
				Unit = request.Unit,
				Quantity = request.Quantity,
				ReceiptDocumentId = receiptDocument.Id,
				ReceiptDocument = receiptDocument
			};

			_dbContext.ReceiptItems.Add(receiptItem);

			await _dbContext.SaveChangesAsync();

			return new ReceiptItemDto
			{
				ProductName = receiptItem.ProductName,
				Unit = receiptItem.Unit,
				Quantity = receiptItem.Quantity
			};
		}
		public async Task<ReceiptItemDto?> UpdateReceiptItemAsync(int id, [FromBody] ReceiptItemCreateUpdateRequest request)
		{
			var receiptItem = await _dbContext.ReceiptItems.FindAsync(id);
			if (receiptItem == null) 
				return null;

			var receiptDocument = await _dbContext.ReceiptDocuments.FindAsync(request.ReceiptDocumentId);
			if (receiptDocument == null)
				return null;

			receiptItem.ProductName = request.ProductName;
			receiptItem.Unit = request.Unit;
			receiptItem.Quantity = request.Quantity;
			receiptItem.ReceiptDocumentId = receiptDocument.Id;
			receiptItem.ReceiptDocument = receiptDocument;

			await _dbContext.SaveChangesAsync();

			return new ReceiptItemDto
			{
				ProductName = receiptItem.ProductName,
				Unit = receiptItem.Unit,
				Quantity = receiptItem.Quantity
			};
		}
	}
}
