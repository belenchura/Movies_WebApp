using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_API.Entities
{
    public class Movie
    {
        public int cod_pelicula { get; }
        public string txt_desc { get; set; }
        public int cant_disponibles_alquiler { get; set; }
        public int cant_disponibles_venta { get; set; }
        public decimal precio_alquiler { get; set; }
        public decimal precio_venta { get; set; }
    }
}
