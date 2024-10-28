using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CrudProductos;
using Microsoft.EntityFrameworkCore;

namespace CrudProductos
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ContextManager _context;

        public ProductoController(ContextManager context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Productos model)
        {
            Productos producto = new Productos
            {
                Nombre = model.Nombre,
                Precio = model.Precio,
                FechaCreacion = DateTime.Now
            };
            _context.Productos.Add(producto);

            await _context.SaveChangesAsync();
            return Ok(producto);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var productos = await _context.Productos.ToListAsync();
            return Ok(productos);
        }
    }
}
