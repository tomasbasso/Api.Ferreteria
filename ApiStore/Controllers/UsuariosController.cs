using ApiStore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ApiStore.ModelsDTO;

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
   
        [HttpPost]
        public async Task<IActionResult> Crear(CrearUsuarioDTO usuarioDto)
        {
            try
            {
                // Mapea el DTO a la entidad Usuario
                var usuario = new Usuario
                {
                   
                    nombre = usuarioDto.nombre,
                    email = usuarioDto.email,
                    direccion = usuarioDto.direccion,
                    rol = usuarioDto.rol,
                    contraseña = usuarioDto.contraseña 
                };

                await _context.Usuario.AddAsync(usuario);
                await _context.SaveChangesAsync();

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
        [HttpPost("ValidarCredencial")]
        public async Task<IActionResult> ValidarCredencial([FromBody] UsuarioLoginDTO usuario)
        {
            var existeLogin = await _context.Usuario
            .AnyAsync(x => x.email.Equals(usuario.email) && x.contraseña.Equals(usuario.contraseña));

            Usuario usuarioLogin = await _context.Usuario.FirstOrDefaultAsync(x => x.email.Equals(usuario.email) && x.contraseña.Equals(usuario.contraseña));

            if (existeLogin == null)
            {
                // Si no se encuentra el usuario, retornar un mensaje de error
                return NotFound("Usuario o contraseña incorrectos");
            }

            // Crear una respuesta con los datos del usuario autenticado
            LoginResponseDto usuarioResponse = new LoginResponseDto()
            {
                usuario_id = existeLogin ? usuarioLogin.usuario_id : 0,
                nombre = existeLogin ? usuarioLogin.nombre : "",
                email = existeLogin? usuarioLogin.email:""
             
            };

            // Retornar la respuesta con los datos del usuario
            return Ok(usuarioResponse);
        }
    }
}

