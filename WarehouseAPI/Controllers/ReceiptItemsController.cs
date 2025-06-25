using Microsoft.AspNetCore.Mvc;
using WarehouseAPI.Database.Entities;
using WarehouseAPI.DTOs;
using WarehouseAPI.Requests;
using WarehouseAPI.Services;

namespace WarehouseAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ReceiptItemsController : ControllerBase
	{
		private readonly ReceiptItemService _receiptItemService;

		public ReceiptItemsController(ReceiptItemService receiptItemService)
		{
			_receiptItemService = receiptItemService;
		}
		[HttpGet]
		public async Task<ActionResult<List<ReceiptItemDto>>> GetAllReceiptDocuments()
		{
			var receiptItems = await _receiptItemService.GetAllReceiptItemsAsync();
			return Ok(receiptItems);
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<ReceiptItemDto>> GetReceiptItemById(int id)
		{
			var receiptItem = await _receiptItemService.GetReceiptItemByIdAsync(id);
			if (receiptItem == null)
				return NotFound();

			return Ok(receiptItem);
		}
		[HttpGet("ReceiptDocument{receiptDocumentId}")]
		public async Task<ActionResult<ReceiptItemDto>> GetReceiptItemsByReceiptDocumentId(int receiptDocumentId)
		{
			var receiptItems = await _receiptItemService.GetReceiptItemsByReceiptDocumentIdAsync(receiptDocumentId);
			if (receiptItems == null)
				return NotFound();

			return Ok(receiptItems);
		}
		[HttpPost]
		public async Task<ActionResult<ReceiptItemDto>> CreateReceiptItem([FromBody] ReceiptItemCreateUpdateRequest request)
		{
			var receiptItem = await _receiptItemService.CreateReceiptItemAsync(request);
			if (receiptItem == null)
				return BadRequest();

			return CreatedAtAction(nameof(GetReceiptItemById), new { id = receiptItem.Id }, receiptItem);
		}
		[HttpPut("{id}")]
		public async Task<ActionResult<ReceiptItemDto>> UpdateReceiptItem(int id, [FromBody] ReceiptItemCreateUpdateRequest request)
		{
			if (request == null)
				return BadRequest();

			var receiptItem = await _receiptItemService.UpdateReceiptItemAsync(id, request);
			if (receiptItem == null)
				return NotFound();

			return Ok(receiptItem);
		}
	}
}
