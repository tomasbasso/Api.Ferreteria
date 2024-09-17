using ApiStore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiStore.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsuariosController : ControllerBase
    {
        private readonly FerreteriaContext _context;

        public UsuariosController(FerreteriaContext context)
        {
            _context=context;
        }
        ////////BUSCAR TODOS//////////////////////////
        [HttpGet(Name = "ObtenerTodos")]
            public async Task<IActionResult> ObtenerTodos()
        {
            try
            {
                var lista = await _context.Usuario.ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        ////////BUSCAR POR ID//////////////////////////
        [HttpGet("ObtenerPorId/{usuario_id:int}")]
        public async Task<IActionResult> ObtenerPorId([FromRoute(Name = "usuario_id")] int id)
        {
            try
            {
                var item = await _context.Usuario.FindAsync(id);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        ///////AGREGAR//////////////////////////NO ANDA
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Usuario usuario)
        {
            try
            {
                await _context.Usuario.AddAsync(usuario);
                var result = await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
