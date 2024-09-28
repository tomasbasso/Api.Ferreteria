using ApiStore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
        [HttpPost]
        public async Task<IActionResult> Crear(Categoria categoria)
        {
            try
            {
                await _context.Categoria.AddAsync(categoria);
                var result = await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    error = ex.Message,
                    innerException = ex.InnerException?.Message
                });
            }
        }
        //////////BORRAR//////////
        [HttpDelete("{categoria_id:int}")]
        public async Task<IActionResult> Borrar([FromRoute] int categoria_id)
        {
            try
            {
                var categoriaExistente = await _context.Categoria.FindAsync(categoria_id);

                if (categoriaExistente != null)
                {
                    _context.Categoria.Remove(categoriaExistente);
                    await _context.SaveChangesAsync();
                }


                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{categoria_id:int}")]
        public async Task<IActionResult> Modificar([FromBody] Categoria categoria, [FromRoute] int categoria_id)
        {
            try
            {
                var categoriaExistente = await _context.Producto.FindAsync(categoria_id);

                if (categoriaExistente != null)
                {
                    if (!categoria.nombre.IsNullOrEmpty()) categoriaExistente.nombre = categoria.nombre;
                   



                    _context.Producto.Update(categoriaExistente);
                    await _context.SaveChangesAsync();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}