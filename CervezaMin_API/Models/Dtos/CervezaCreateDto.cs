﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CervezaMin_API.Models.Dtos
{
    public class CervezaCreateDto
    {
        public string? Nombre { get; set; }
        public int IdMarca { get; set; }
        public string? NombreImagen { get; set; }
        public string? UrlImagen { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
    }
}
