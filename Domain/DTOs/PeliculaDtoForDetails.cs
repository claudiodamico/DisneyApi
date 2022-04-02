using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyApi.Domain.DTOs
{
    public class PeliculaDtoForDetails
    {
        public string Imagen { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int Calificacion { get; set; }
        public int GeneroId { get; set; }
        public List<PersonajeDto> personajes { get; set; }
    }
}
