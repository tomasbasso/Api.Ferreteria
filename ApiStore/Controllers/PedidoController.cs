using ApiStore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiStore.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PedidoController : ControllerBase
    {
        private readonly FerreteriaContext _context;

        public PedidoController(FerreteriaContext context)
        {
            _context = context;
        }
        ////////BUSCAR TODOS//////////////////////////
        [HttpGet(Name = "ObtenerTodosPedidos")]
        public async Task<IActionResult> ObtenerTodos()
        {
            try
            {
                var lista = await _context.Pedido.ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        ////////BUSCAR POR ID//////////////////////////
        [HttpGet("ObtenerPorId/{pedido_id:int}")]
        public async Task<IActionResult> ObtenerPorId([FromRoute(Name = "pedido_id")] int id)
        {
            try
            {
                var item = await _context.Pedido.FindAsync(id);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}