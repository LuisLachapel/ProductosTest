using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                throw new Exception("No existe el producto");
            }
            return Ok(producto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                throw new Exception("No existe el producto");
            }
            _context.Remove(producto);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Productos modelo, int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                throw new Exception("No existe el producto");
            }
            producto.Nombre = modelo.Nombre;
            producto.Precio = modelo.Precio;

            _context.Update(producto);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}
