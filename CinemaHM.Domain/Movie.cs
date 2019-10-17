using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaHM.Domain;

namespace CinemaHM.Domain
{
    public class Movie
    {
        public string Nombre { get; set; }
        public DateTime FechaEstreno { get; set; }
        public string Genero { get; set; }
        public string Recomendacion { get; set; }
        public int Duracion { get; set; }
        public string Imagen { get; set; }
        public List<Funcion> Funciones { get; set; }
        public DateTime FechaActual
        {
            get
            {
                return DateTime.Now;
            }
        }

    }
}
