using Microsoft.EntityFrameworkCore;
namespace api_productos.Models{
    class Conexion : DbContext{
        public Conexion (DbContextOptions<Conexion> options) : base(options){}
        public DbSet<Productos> Productos {get; set;} 
        public DbSet<Marcas> Marcas {get; set;} 
    }
    class Conectar{
        private const string cadenaConexion = " server=localhost;port=3306;database=db_punto_venta;userid=crudfinal;pwd=finalcrudcrud123";
        public static Conexion Create(){
            var constructor = new DbContextOptionsBuilder<Conexion>();
            constructor.UseMySQL(cadenaConexion);
            var cn = new Conexion(constructor.Options);
            return cn;
        }
    }
}