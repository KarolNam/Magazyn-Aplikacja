using Microsoft.AspNetCore.Mvc;
using WarehouseAPI.DTOs;
using WarehouseAPI.Requests;
using WarehouseAPI.Services;

namespace WarehouseAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ReceiptDocumentsController : ControllerBase
	{
		private readonly ReceiptDocumentService _receiptDocumentService;

		public ReceiptDocumentsController(ReceiptDocumentService receiptDocumentService)
		{
			_receiptDocumentService = receiptDocumentService;
		}
		[HttpGet]
		public async Task<ActionResult<List<ReceiptDocumentDto>>> GetAllReceiptDocuments()
		{
			var receiptDocuments = await _receiptDocumentService.GetAllReceiptDocumentsAsync();
			return Ok(receiptDocuments);
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<ReceiptDocumentDto>> GetReceiptDocumentById(int id)
		{
			var receiptDocument = await _receiptDocumentService.GetReceiptDocumentByIdAsync(id);
			if (receiptDocument == null)
				return NotFound();

			return Ok(receiptDocument);
		}
		[HttpGet("ContractorDocuments{contractorId}")]
		public async Task<ActionResult<ContractorReceiptDocumentsDto>> GetReceiptDocumentsByContractorId(int contractorId)
		{
			var contractorReceiptDocument = await _receiptDocumentService.GetReceiptDocumentsByContractorIdAsync(contractorId);
			if (contractorReceiptDocument == null)
				return NotFound();

			return Ok(contractorReceiptDocument);
		}
		[HttpPost]
		public async Task<ActionResult<ReceiptDocumentDto>> CreateReceiptDocument([FromBody] ReceiptDocumentCreateUpdateRequest request)
		{
			var receiptDocument = await _receiptDocumentService.CreateReceiptDocumentAsync(request);
			if (receiptDocument == null)
				return BadRequest();

			return CreatedAtAction(nameof(GetReceiptDocumentById), new { id = receiptDocument.Id }, receiptDocument);
		}
		[HttpPut("{id}")]
		public async Task<ActionResult<ReceiptDocumentDto>> UpdateReceiptDocument(int id, [FromBody] ReceiptDocumentCreateUpdateRequest request)
		{
			if (request == null)
				return BadRequest();

			var receiptDocument = await _receiptDocumentService.UpdateReceiptDocumentAsync(id, request);
			if (receiptDocument == null)
				return NotFound();

			return Ok(receiptDocument);
		}
	}
}
