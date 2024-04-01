using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CervezaMin_API.Models
{
    public class Cerveza
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCerveza { get; set; }
        [Required]
        public int IdMarca { get; set; }
        public string? Nombre { get; set; }
        public string? NombreImagen { get; set; }
        public string? UrlImagen { get; set; }  
        public double  Precio { get; set; }
        public int Stock { get; set; }
        public bool EsActivo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        [ForeignKey("IdMarca")]
        public virtual Marca? MarcaNavegacion { get; set; }

    }
}
