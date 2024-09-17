using ApiStore.Data;
using ApiStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ApiStore.Controllers;

[Route("api/[controller]")]
[ApiController]

public class DetallePedidoController : ControllerBase
{
    private readonly FerreteriaContext _context;

    public DetallePedidoController(FerreteriaContext context)
    {
        _context = context;
    }

    [HttpGet(Name = "ObtenerTodosDetalle")]
    public async Task<IActionResult> ObtenerTodos()
    {
        try
        {
            var lista = await _context.detalle_pedido.ToListAsync();
            return Ok(lista);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("ObtenerPorId/{detalle_id:int}")]
    public async Task<IActionResult> ObtenerPorId([FromRoute(Name = "detalle_id")] int id)
    {
        try
        {
            var item = await _context.detalle_pedido.FindAsync(id);
            return Ok(item);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}