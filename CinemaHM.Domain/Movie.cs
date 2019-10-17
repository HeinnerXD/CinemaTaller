using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHM.Domain
{
    public class Movie
    {
        public string Nombre { get; set; }
        public string FechaEstreno { get; set; }
        public string Genero { get; set; }
        public string Recomendacion { get; set; }
        public string Imagen { get; set; }
    }
}
