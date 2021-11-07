using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using api_productos.Models;
namespace api_productos.Controllers{
    [Route("api/[controller]")]
    public class ProductosController : Controller{
        private Conexion dbConexion;
        public ProductosController(){
            dbConexion = Conectar.Create();
        }
        [HttpGet]
        public ActionResult Get(){
            var result = (
                from n in dbConexion.Marcas
                join c in dbConexion.Productos on n.idMarca equals c.idMarca
                select 
                new{
                    c.idProducto,
                    c.Producto,
                    n.Marca,
                    c.Descripcion,
                    c.Imagen,
                    c.Precio_costo,
                    c.Precio_venta,
                    c.Existencia,
                    c.Fecha_ingreso
                }
            ).ToList();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id){
            var productos = await dbConexion.Productos.FindAsync(id);
            if(productos != null){
                return Ok(productos);
            }else{
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Productos productos){
            if(ModelState.IsValid){
                dbConexion.Productos.Add(productos);
                await dbConexion.SaveChangesAsync();
                return Ok(productos);
            }else{
                return NotFound();
            }
        }
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Productos productos){
            var v_productos = dbConexion.Productos.SingleOrDefault(a => a.idProducto == productos.idProducto);
            if(v_productos != null && ModelState.IsValid){
                dbConexion.Entry(v_productos).CurrentValues.SetValues(productos);
                await dbConexion.SaveChangesAsync();
                return Ok();
            }
            else{
                return NotFound();
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id){
            var productos = dbConexion.Productos.SingleOrDefault(a => a.idProducto == id);
            if(productos != null){
                dbConexion.Productos.Remove(productos);
                await dbConexion.SaveChangesAsync();
                return Ok();
            }else{
                return NotFound();
            }
        }
    }
}