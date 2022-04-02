using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyApi.Domain.DTOs
{
    public class PeliculaDtoForCreationOrUpdate
    {
        public string Imagen { get; set; }
        public string Titulo { get; set; }
        public string FechaCreacion { get; set; }
        public int Calificacion { get; set; }
        public int GeneroId { get; set; }
    }
}
