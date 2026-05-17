using Microsoft.AspNetCore.Mvc;
using PJATK_APBD_Cw7_s27023.DTOs;
using PJATK_APBD_Cw7_s27023.Services;

namespace PJATK_APBD_Cw7_s27023.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PcsController(IPcService pcService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken token)
    {
        var pcs = await pcService.GetAll(token);
        return Ok(pcs);
    }
    
    [HttpGet("{id:int}/components")]
    public async Task<IActionResult> GetComponentsById([FromRoute] int id, CancellationToken token)
    {
        var pc = await pcService.GetAllComponents(id, token);
        return pc is null ? NotFound() : Ok(pc);
    }
    
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreatePcRequest request, CancellationToken token)
    {
        var pc = await pcService.Create(request, token);
        return CreatedAtAction(nameof(GetComponentsById), new { id = pc.Id }, pc);
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePcRequest request, CancellationToken token)
    {
        var updated = await pcService.Update(id, request, token);
        return updated ? NoContent() : NotFound();
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
    {
        var deleted = await pcService.Delete(id, token);
        return deleted ? NoContent() : NotFound();
    }
}