using Microsoft.AspNetCore.Mvc;
using WarehouseAPI.DTOs;
using WarehouseAPI.Requests;
using WarehouseAPI.Services;

namespace WarehouseAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ContractorsController : ControllerBase
	{
		private readonly ContractorService _contractorService;

		public ContractorsController(ContractorService contractorService)
		{
			_contractorService = contractorService;
		}
		[HttpGet]
		public async Task<ActionResult<List<ContractorDto>>> GetAllContractors()
		{
			var contractors = await _contractorService.GetAllContractorsAsync();
			return Ok(contractors);
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<ContractorDto>> GetContractorById(int id)
		{
			var contractor = await _contractorService.GetContractorByIdAsync(id);
			if (contractor == null)
				return NotFound();

			return Ok(contractor);
		}
		[HttpPost]
		public async Task<ActionResult<ContractorDto>> CreateContractor([FromBody] ContractorCreateUpdateRequest request)
		{
			var contractor = await _contractorService.CreateContractorAsync(request);
			if (contractor == null)
				return BadRequest();

			return CreatedAtAction(nameof(GetContractorById), new { id = contractor.Id }, contractor);
		}
		[HttpPut("{id}")]
		public async Task<ActionResult<ContractorDto>> UpdateContractor(int id, [FromBody] ContractorCreateUpdateRequest request)
		{
			if (request == null)
				return BadRequest();

			var contractor = await _contractorService.UpdateContractorAsync(id, request);
			if (contractor == null)
				return NotFound();

			return Ok(contractor);
		}
	}
}
