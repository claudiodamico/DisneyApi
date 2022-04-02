using AutoMapper;
using DisneyApi.Domain.Commands;
using DisneyApi.Domain.DTOs;
using DisneyApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyApi.AccessData.Commands
{
    public class PeliculasRepository : IPeliculasRepository
    {
        private readonly DisneyApiContext _context;
        private readonly IMapper _mapper;

        public PeliculasRepository(DisneyApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Add(Pelicula pelicula)
        {
            _context.Peliculas.Add(pelicula);
            _context.SaveChanges();
        }

        public void Delete(Pelicula pelicula)
        {
            _context.Peliculas.Remove(pelicula);
            _context.SaveChanges();
        }

        public List<Pelicula> GetAllPeliculas()
        {
            return _context.Peliculas.OrderBy(Pelicula => Pelicula.FechaCreacion).ToList();
        }

        public List<Pelicula> GetPeliculasByCharacterId(int id)
        {

            var peliculasPorPersonaje = _context.PersonajePeliculas.Where(PeliculaPersonaje => PeliculaPersonaje.PersonajeId == id).ToList();

            List<Pelicula> peliculas = new List<Pelicula>();

            foreach (var item in peliculasPorPersonaje)
            {
                var pelicula = _context.Peliculas.Find(item.PeliculaId);
                peliculas.Add(pelicula);
            }

            return peliculas;
        }

        public Pelicula GetPeliculaById(int id)
        {
            return _context.Peliculas.Find(id);
        }

        public Pelicula GetPeliculaByTitle(string title)
        {
            return _context.Peliculas.SingleOrDefault(Pelicula => Pelicula.Titulo == title);
        }

        public void Update(Pelicula pelicula)
        {
            _context.Update(pelicula);
            _context.SaveChanges();
        }

        public List<Pelicula> GetPeliculasByGenreId(int genre)
        {
            return _context.Peliculas.Where(Pelicula => Pelicula.GeneroId == genre).ToList();
        }

        public List<Pelicula> GetAllPeliculasSortedByDesc()
        {
            return GetAllPeliculas().OrderByDescending(Pelicula => Pelicula.FechaCreacion).ToList();
        }



        public PeliculaDtoForDetails GetMovieWithDetails(int id)
        {
            var pelicula = GetPeliculaById(id);
            var peliculaConDetalles = _mapper.Map<PeliculaDtoForDetails>(pelicula);
            var personajesMapeados = _mapper.Map<List<PersonajeDto>>(GetCharacterByMovieId(pelicula.PeliculaId));
            peliculaConDetalles.personajes = personajesMapeados;

            return peliculaConDetalles;
        }

        public List<Personaje> GetCharacterByMovieId(int movieId)
        {
            var personajePeliculas = _context.PersonajePeliculas.Where(PersonajePeliculas => PersonajePeliculas.PeliculaId == movieId);
            List<Personaje> personajes = new List<Personaje>();

            foreach (var pelicula in personajePeliculas)
            {
                var personaje = _context.Personajes.Find(pelicula.PersonajeId);
                personajes.Add(personaje);
            }

            return personajes;
        }

    }
}
