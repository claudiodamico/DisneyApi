using DisneyApi.Domain.DTOs;
using DisneyApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyApi.Domain.Commands
{
    public interface IPeliculasRepository
    {
        List<Pelicula> GetAllPeliculas();
        List<Pelicula> GetAllPeliculasSortedByDesc();
        Pelicula GetPeliculaById(int id);
        PeliculaDtoForDetails GetMovieWithDetails(int id);
        Pelicula GetPeliculaByTitle(string title);
        void Update(Pelicula pelicula);
        void Delete(Pelicula pelicula);
        void Add(Pelicula pelicula);
        List<Pelicula> GetPeliculasByCharacterId(int id);
        List<Pelicula> GetPeliculasByGenreId(int genre);
    }
}
