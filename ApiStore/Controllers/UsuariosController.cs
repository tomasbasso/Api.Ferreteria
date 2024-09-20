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

    public class UsuariosController : ControllerBase
    {
        private readonly FerreteriaContext _context;

        public UsuariosController(FerreteriaContext context)
        {
            _context = context;
        }
        ////////BUSCAR TODOS//////////////////////////AUTOMAPER
        [HttpGet(Name = "ObtenerTodos")]
        public async Task<IActionResult> ObtenerTodos()
        {
            try
            {
                var lista = await _context.Usuario.Select(u => new UsuarioListaDTO
                {
                    usuario_id = u.usuario_id,
                    nombre = u.nombre,
                    email = u.email,
                    direccion = u.direccion,
                    rol = u.rol
                })
                    .ToListAsync();
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
        public async Task<IActionResult> Crear(Usuario usuario)
        {
            try
            {
                await _context.Usuario.AddAsync(usuario);
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
        [HttpDelete("{usuario_id:int}")]
        public async Task<IActionResult> Borrar([FromRoute] int usuario_id)
        {
            try
            {
                var usuarioExistente = await _context.Usuario.FindAsync(usuario_id);

                if (usuarioExistente != null)
                {
                    _context.Usuario.Remove(usuarioExistente);
                    await _context.SaveChangesAsync();
                }


                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{usuarioId:int}")]
        public async Task<IActionResult> Modificar([FromBody] Usuario usuario, [FromRoute] int usuarioId)
        {
            try
            {
                var usuarioExistente = await _context.Usuario.FindAsync(usuarioId);

                if (usuarioExistente != null)
                {
                    if (!usuario.nombre.IsNullOrEmpty()) usuarioExistente.nombre = usuario.nombre;
                    if (!usuario.email.IsNullOrEmpty()) usuarioExistente.email = usuario.email;
                    if (!usuario.direccion.IsNullOrEmpty()) usuarioExistente.direccion = usuario.direccion;
                    if (!usuario.rol.IsNullOrEmpty()) usuarioExistente.rol = usuario.rol;
                    if (!usuario.contraseña.IsNullOrEmpty()) usuarioExistente.contraseña = usuario.contraseña;


                    _context.Usuario.Update(usuarioExistente);
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
