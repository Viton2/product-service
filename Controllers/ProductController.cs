using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using product_service_api.DTO;
using product_service_api.Model;
using product_service_api.Service;

namespace product_service_api.Controllers;

[ApiController]
[Route("products")]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;

    public ProductController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.FindAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var product = await _service.FindByIdAsync(id);

        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create(CreateProduct product)
    {
        var created = await _service.CreateAsync(product);

        return Created($"/products/{created.Id}", created);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Update(Guid id, Product product)
    {
        var updated = await _service.UpdateAsync(id, product);
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);

        return NoContent();
    }
}