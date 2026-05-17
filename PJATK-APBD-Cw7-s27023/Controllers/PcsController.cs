using Microsoft.AspNetCore.Mvc;
using PJATK_APBD_Cw7_s27023.DTOs;

namespace PJATK_APBD_Cw7_s27023.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PcsController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok();
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetComponentsById([FromRoute] int id)
    {
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreatePcRequest request)
    {
        return Ok();
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id)
    {
        return Ok();
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return Ok();
    }
}