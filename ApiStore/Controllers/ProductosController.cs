using ApiStore.Data;
using ApiStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ApiStore.Controllers;

[Route("api/[controller]")]
[ApiController]

public class ProductosController : ControllerBase
{
    private readonly FerreteriaContext _context;

    public ProductosController(FerreteriaContext context)
    {
        _context = context;
    }

    [HttpGet(Name = "ObtenerTodosProductos")]
    public async Task<IActionResult> ObtenerTodos()
    {
        try
        {
            var lista = await _context.Producto.ToListAsync();
            return Ok(lista);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("ObtenerPorId/{producto_id:int}")]
    public async Task<IActionResult> ObtenerPorId([FromRoute(Name = "producto_id")] int id)
    {
        try
        {
            var item = await _context.Producto.FindAsync(id);
            return Ok(item);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

//    [HttpPost]
//    public async Task<IActionResult> Crear([FromBody] Producto producto)
//    {
//        try
//        {
//            await _context.Productos.AddAsync(producto);
//            var result = await _context.SaveChangesAsync();

//            return Ok();
//        }
//        catch (Exception ex)
//        {
//            return BadRequest(ex.Message);
//        }
//    }

//    [HttpDelete("{productoId:int}")]
//    public async Task<IActionResult> Borrar([FromRoute] int productoId)
//    {
//        try
//        {
//            var productoExistente = await _context.Productos.FindAsync(productoId);

//            if(productoExistente != null)
//            {
//                _context.Productos.Remove(productoExistente);
//                await _context.SaveChangesAsync();
//            }


//            return NoContent();
//        }
//        catch (Exception ex)
//        {
//            return BadRequest(ex.Message);
//        }
//    }

//    [HttpPut("{productoId:int}")]
//    public async Task<IActionResult> Modificar([FromBody] Producto producto, [FromRoute] int productoId)
//    {
//        try
//        {
//            var productoExistente = await _context.Productos.FindAsync(productoId);

//            if (productoExistente != null)
//            {
//                if(!producto.Descripcion.IsNullOrEmpty()) productoExistente.Descripcion = producto.Descripcion;
//                if(!producto.Nombre.IsNullOrEmpty()) productoExistente.Nombre = producto.Nombre;
//                if(!producto.Imagen.IsNullOrEmpty()) productoExistente.Imagen = producto.Imagen;
//                if(producto.Precio!=null) productoExistente.Precio = producto.Precio;
//                if(producto.Stock != null) productoExistente.Stock = producto.Stock;

//                _context.Productos.Update(productoExistente);
//                await _context.SaveChangesAsync();
//            }

//            return NoContent();
//        }
//        catch (Exception ex)
//        {
//            return BadRequest(ex.Message);
//        }
//    }

//}
