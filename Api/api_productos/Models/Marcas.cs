using System.ComponentModel.DataAnnotations;

namespace api_productos.Models{
    public class Marcas{
        [Key]
        public int idMarca {get; set;}
        public string Marca {get; set;}

    }
}