using DisneyApi.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyApi.AccessData
{
    public  class DisneyApiContext : DbContext
    {
        public DisneyApiContext() { }

        public DisneyApiContext(DbContextOptions<DisneyApiContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personaje>(entity =>
            {
                entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.Imagen)
                .IsRequired()
                .HasMaxLength(1000)
                .IsUnicode(false);

                entity.Property(e => e.Historia)
                .IsRequired()
                .HasMaxLength(2000)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("date");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasMaxLength(2083)
                    .IsUnicode(false);

                entity.HasOne(e => e.Genero)
                    .WithMany(p => p.Peliculas)
                    .HasForeignKey(d => d.GeneroId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.GeneroId);

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasMaxLength(2083)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PersonajePelicula>(entity =>
            {
                entity.HasKey(pp => new { pp.PeliculaId, pp.PersonajeId });

                entity.HasOne(pp => pp.Pelicula)
                      .WithMany(pelicula => pelicula.PersonajePeliculas)
                      .HasForeignKey(pp => pp.PeliculaId);

                entity.HasOne(pp => pp.Personaje)
                      .WithMany(personaje => personaje.PersonajePeliculas)
                      .HasForeignKey(pp => pp.PersonajeId);
            });

            modelBuilder.Entity<Personaje>().HasData(
                new Personaje
                {
                    PersonajeId = 1,
                    Nombre = "Mickey Mouse",
                    Imagen = "Image here!",
                    Edad = 94,
                    Peso = 10,
                    Historia = "Mickey Mouse is a cartoon character created in 1928 by Walt Disney, and is the mascot of The Walt Disney Company. An anthropomorphic mouse who typically wears red shorts, large yellow shoes, and white gloves, Mickey is one of the world's most recognizable fictional characters",
                },
                new Personaje
                {
                    PersonajeId = 2,
                    Nombre = "Minnie Mouse",
                    Imagen = "Image here!",
                    Edad = 94,
                    Peso = 20,
                    Historia = "Donald duck is an animated character created by Walt Disney as a foil to Mickey Mouse.[15] Making his screen debut in The Wise Little Hen on June 9, 1934, Donald is characterized as a pompous, showboating duck wearing a sailor suit, cap and a bow tie"
                },
                new Personaje
                {
                    PersonajeId = 3,
                    Nombre = "Anna",
                    Imagen = "Image here!",
                    Edad = 18,
                    Peso = 50,
                    Historia = "Anna of Arendelle is a fictional character who appears in Walt Disney Animation Studios' 53rd animated film Frozen (2013) and its sequel and 58th animated film Frozen II (2019). She is voiced by Kristen Bell as an adult. At the beginning of the film, Livvy Stubenrauch and Katie Lopez provide her speaking and singing voice as a young child, respectively. Agatha Lee Monn portrayed her as a nine-year-old (singing)",
                },
                new Personaje
                {
                    PersonajeId = 4,
                    Nombre= "Elsa",
                    Imagen = "Image here!",
                    Edad = 21,
                    Peso = 55,
                    Historia = "Elsa of Arendelle is a fictional character who appears in Walt Disney Animation Studios' 53rd animated film Frozen (2013) and its sequel and 58th animated film Frozen II (2019). She is voiced mainly by Broadway actress and singer Idina Menzel, with Eva Bella as a young child and by Spencer Ganus as a teenager in Frozen",
                },
                new Personaje
                {
                    PersonajeId = 5,
                    Nombre = "Goofy",
                    Imagen = "Image here!",
                    Edad = 89,
                    Peso = 70,
                    Historia = "Goofy is an animated character that first appeared in 1932's Mickey's Revue.He  is predominately known for his slapstick style of comedy, and regularly appears alongside his best friends Mickey Mouse and Donald Duck",
                });

            modelBuilder.Entity<Pelicula>().HasData
                (
                new Pelicula
                {
                    PeliculaId = 1,
                    Titulo = "Mickey, Donald, Goofy: The Three Musketeers",
                    Imagen = "Image here!",
                    FechaCreacion = new DateTime(2004, 08, 17), //"yyyy-MM-dd"
                    Calificacion = 4,
                    GeneroId = 1
                },
                new Pelicula
                {
                    PeliculaId = 2,
                    Titulo = "Frozen",
                    Imagen = "Image here!", 
                    FechaCreacion = new DateTime(2013, 06, 05), //"yyyy-MM-dd"
                    Calificacion = 5,
                    GeneroId = 2
                },
                new Pelicula
                {
                    PeliculaId = 3,
                    Titulo= "The Karnival Kid",
                    Imagen = "Image here!",
                    FechaCreacion = new DateTime(1929, 05, 23), //"yyyy-MM-dd"
                    Calificacion= 3,
                    GeneroId = 2
                });

            modelBuilder.Entity<Genero>().HasData
                (
                new Genero
                {
                    GeneroId = 1,
                    Nombre = "Fantasy",
                    Imagen = "Image here!"
                },
                new Genero
                {
                    GeneroId = 2,
                    Nombre = "animation",
                    Imagen = "Image here!"
                });

            modelBuilder.Entity<PersonajePelicula>().HasData
               (
               new PersonajePelicula
               {
                   PersonajeId = 1,
                   PeliculaId = 1
               },
               new PersonajePelicula
               {
                   PersonajeId = 2,
                   PeliculaId = 1
               },
               new PersonajePelicula
               {
                   PersonajeId = 3,
                   PeliculaId = 2
               },
               new PersonajePelicula
               {
                   PersonajeId = 4,
                   PeliculaId = 2
               },
                new PersonajePelicula
                {
                    PersonajeId = 5,
                    PeliculaId = 1
                },
               new PersonajePelicula
               {
                   PersonajeId = 1,
                   PeliculaId = 3
               });
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    RoleId = 1,
                    Name = "Admin",
                    Description = "Descripción",
                },
                new Role
                {
                    RoleId = 2,
                    Name = "User",
                    Description = "Usuario"
                }
                );
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Username = "Alkymer",
                    Email = "Alkymer@alkemy.com",
                    Password = "1234",
                    RoleId = 1
                },
                new User
                {
                    UserId = 2,
                    Username = "Test",
                    Email = "test@test.com",
                    Password = "test",
                    RoleId = 2
                },
                new User
                {
                    UserId = 3,
                    Username = "Test2",
                    Email = "test2@test.com",
                    Password = "test",
                    RoleId = 2
                });

        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Personaje> Personajes { get; set; }
        public DbSet<PersonajePelicula> PersonajePeliculas { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
