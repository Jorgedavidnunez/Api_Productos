using System.ComponentModel.DataAnnotations;

namespace api_productos.Models{
    public class Productos{
        [Key]
        public int idProducto {get; set;}
        public string Producto {get; set;}
        public int idMarca {get; set;}
        public string Descripcion {get; set;}
        public string Imagen {get; set;}
        public double Precio_costo {get; set;}
        public double Precio_venta {get; set;}
        public int Existencia {get; set;}
        public string Fecha_ingreso {get; set;}

    }
}