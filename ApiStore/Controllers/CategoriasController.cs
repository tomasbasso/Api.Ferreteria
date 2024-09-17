using ApiStore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiStore.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoriasController : ControllerBase
    {
        private readonly FerreteriaContext _context;

        public CategoriasController(FerreteriaContext context)
        {
            _context = context;
        }
        ////////BUSCAR TODOS//////////////////////////
        [HttpGet(Name = "ObtenerTodosCat")]
        public async Task<IActionResult> ObtenerTodos()
        {
            try
            {
                var lista = await _context.Categoria.ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        ////////BUSCAR POR ID//////////////////////////
        [HttpGet("ObtenerPorId/{categoria_id:int}")]
        public async Task<IActionResult> ObtenerPorId([FromRoute(Name = "categoria_id")] int id)
        {
            try
            {
                var item = await _context.Categoria.FindAsync(id);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}