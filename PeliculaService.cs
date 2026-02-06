using System;
using System.Collections.Generic;
using System.Linq;
using MoviesApp.Core;

namespace MoviesApp.Application
{
    public class PeliculaService
    {
        private List<Pelicula> _peliculas;

        public PeliculaService()
        {
            _peliculas = InicializarDatos();
        }

        // Caso de Uso 1: Consultar todas las películas (25 objetos)
        public List<Pelicula> ObtenerTodas()
        {
            return _peliculas;
        }

        // Caso de Uso 2: Consultar las películas de acción
        public List<Pelicula> ObtenerPeliculasDeAccion()
        {
            return _peliculas
                .Where(p => p.Tipo.Equals("Accion", StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // Caso de Uso 3: Consultar los actores que han trabajado en películas de terror
        public List<Actor> ObtenerActoresDeTerror()
        {
            return _peliculas
                .Where(p => p.Tipo.Equals("Terror", StringComparison.OrdinalIgnoreCase))
                .SelectMany(p => p.Actores)
                .GroupBy(a => a.Nombre) // Agrupar por nombre para eliminar duplicados
                .Select(g => g.First())
                .ToList();
        }

        // Caso de Uso 4: Consultar todos los actores australianos
        // Buscamos en todas las películas, aplanamos la lista de actores y filtramos por país.
        public List<Actor> ObtenerActoresAustralianos()
        {
            return _peliculas
                .SelectMany(p => p.Actores)
                .Where(a => a.Pais.Equals("Australia", StringComparison.OrdinalIgnoreCase))
                .GroupBy(a => a.Nombre) // Evitar duplicados si el actor sale en varias pelis
                .Select(g => g.First())
                .ToList();
        }

        // Caso de Uso 5: Consultar todas las películas con calificación perfecta (10)
        public List<Pelicula> ObtenerPeliculasPerfectas()
        {
            return _peliculas
                .Where(p => p.Calificacion == 10.0)
                .ToList();
        }

        private List<Pelicula> InicializarDatos()
        {
            // Creación de actores comunes para reutilizar
            var chrisHemsworth = new Actor { Nombre = "Chris Hemsworth", Pais = "Australia", Genero = "M", Edad = 39 };
            var hughJackman = new Actor { Nombre = "Hugh Jackman", Pais = "Australia", Genero = "M", Edad = 54 };
            var margotRobbie = new Actor { Nombre = "Margot Robbie", Pais = "Australia", Genero = "F", Edad = 33 };
            var tomCruise = new Actor { Nombre = "Tom Cruise", Pais = "USA", Genero = "M", Edad = 60 };
            var bradPitt = new Actor { Nombre = "Brad Pitt", Pais = "USA", Genero = "M", Edad = 59 };
            var anyaTaylor = new Actor { Nombre = "Anya Taylor-Joy", Pais = "USA", Genero = "F", Edad = 27 };
            var veraFarmiga = new Actor { Nombre = "Vera Farmiga", Pais = "USA", Genero = "F", Edad = 50 };

            var lista = new List<Pelicula>();

            // Generamos 25 películas variadas
            // 1-5: Acción
            lista.Add(new Pelicula { Nombre = "Misión Imposible 1", AnioEstreno = 1996, Tipo = "Accion", Sinopsis = "Espías y acción.", Calificacion = 8.5, Actores = new List<Actor> { tomCruise } });
            lista.Add(new Pelicula { Nombre = "Mad Max: Fury Road", AnioEstreno = 2015, Tipo = "Accion", Sinopsis = "Desierto y coches.", Calificacion = 10.0, Actores = new List<Actor> { tomCruise, margotRobbie } }); // Margot agregada para prueba
            lista.Add(new Pelicula { Nombre = "Extraction", AnioEstreno = 2020, Tipo = "Accion", Sinopsis = "Rescate mercenario.", Calificacion = 7.0, Actores = new List<Actor> { chrisHemsworth } });
            lista.Add(new Pelicula { Nombre = "Top Gun: Maverick", AnioEstreno = 2022, Tipo = "Accion", Sinopsis = "Aviones.", Calificacion = 10.0, Actores = new List<Actor> { tomCruise } });
            lista.Add(new Pelicula { Nombre = "Bullet Train", AnioEstreno = 2022, Tipo = "Accion", Sinopsis = "Tren bala.", Calificacion = 7.5, Actores = new List<Actor> { bradPitt } });

            // 6-10: Terror
            lista.Add(new Pelicula { Nombre = "El Conjuro", AnioEstreno = 2013, Tipo = "Terror", Sinopsis = "Fantasmas en casa.", Calificacion = 9.0, Actores = new List<Actor> { veraFarmiga } });
            lista.Add(new Pelicula { Nombre = "La Monja", AnioEstreno = 2018, Tipo = "Terror", Sinopsis = "Monja malvada.", Calificacion = 6.0, Actores = new List<Actor> { new Actor { Nombre = "Taissa Farmiga", Pais = "USA", Genero = "F", Edad = 28 } } });
            lista.Add(new Pelicula { Nombre = "Scream", AnioEstreno = 1996, Tipo = "Terror", Sinopsis = "Asesino enmascarado.", Calificacion = 8.0, Actores = new List<Actor> { new Actor { Nombre = "Neve Campbell", Pais = "Canada", Genero = "F", Edad = 49 } } });
            lista.Add(new Pelicula { Nombre = "It", AnioEstreno = 2017, Tipo = "Terror", Sinopsis = "Payaso malvado.", Calificacion = 8.5, Actores = new List<Actor> { new Actor { Nombre = "Bill Skarsgard", Pais = "Suecia", Genero = "M", Edad = 32 } } });
            lista.Add(new Pelicula { Nombre = "Hereditary", AnioEstreno = 2018, Tipo = "Terror", Sinopsis = "Herencia maldita.", Calificacion = 9.5, Actores = new List<Actor> { new Actor { Nombre = "Toni Collette", Pais = "Australia", Genero = "F", Edad = 50 } } }); // Toni es Australiana en peli de terror

            // 11-15: Drama
            lista.Add(new Pelicula { Nombre = "El Padrino", AnioEstreno = 1972, Tipo = "Drama", Sinopsis = "Mafia.", Calificacion = 10.0, Actores = new List<Actor> { new Actor { Nombre = "Al Pacino", Pais = "USA", Genero = "M", Edad = 83 } } });
            lista.Add(new Pelicula { Nombre = "Forrest Gump", AnioEstreno = 1994, Tipo = "Drama", Sinopsis = "Correr.", Calificacion = 9.8, Actores = new List<Actor> { new Actor { Nombre = "Tom Hanks", Pais = "USA", Genero = "M", Edad = 67 } } });
            lista.Add(new Pelicula { Nombre = "Elvis", AnioEstreno = 2022, Tipo = "Drama", Sinopsis = "Vida de Elvis.", Calificacion = 8.0, Actores = new List<Actor> { new Actor { Nombre = "Austin Butler", Pais = "USA", Genero = "M", Edad = 31 }, tomCruise } });
            lista.Add(new Pelicula { Nombre = "Babylon", AnioEstreno = 2022, Tipo = "Drama", Sinopsis = "Cine mudo.", Calificacion = 7.5, Actores = new List<Actor> { bradPitt, margotRobbie } });
            lista.Add(new Pelicula { Nombre = "The Whale", AnioEstreno = 2022, Tipo = "Drama", Sinopsis = "Redención.", Calificacion = 9.0, Actores = new List<Actor> { new Actor { Nombre = "Brendan Fraser", Pais = "USA", Genero = "M", Edad = 54 } } });

            // 16-20: Comedia
            lista.Add(new Pelicula { Nombre = "Barbie", AnioEstreno = 2023, Tipo = "Comedia", Sinopsis = "Muñeca en mundo real.", Calificacion = 8.0, Actores = new List<Actor> { margotRobbie } });
            lista.Add(new Pelicula { Nombre = "Superbad", AnioEstreno = 2007, Tipo = "Comedia", Sinopsis = "Adolescentes.", Calificacion = 8.5, Actores = new List<Actor> { new Actor { Nombre = "Jonah Hill", Pais = "USA", Genero = "M", Edad = 39 } } });
            lista.Add(new Pelicula { Nombre = "La Máscara", AnioEstreno = 1994, Tipo = "Comedia", Sinopsis = "Poderes verdes.", Calificacion = 7.0, Actores = new List<Actor> { new Actor { Nombre = "Jim Carrey", Pais = "Canada", Genero = "M", Edad = 61 } } });
            lista.Add(new Pelicula { Nombre = "Zoolander", AnioEstreno = 2001, Tipo = "Comedia", Sinopsis = "Modelos.", Calificacion = 6.5, Actores = new List<Actor> { new Actor { Nombre = "Ben Stiller", Pais = "USA", Genero = "M", Edad = 57 } } });
            lista.Add(new Pelicula { Nombre = "Tropic Thunder", AnioEstreno = 2008, Tipo = "Comedia", Sinopsis = "Guerra falsa.", Calificacion = 8.0, Actores = new List<Actor> { bradPitt, tomCruise } });

            // 21-25: Sci-Fi y Varios
            lista.Add(new Pelicula { Nombre = "Interstellar", AnioEstreno = 2014, Tipo = "Sci-Fi", Sinopsis = "Espacio y tiempo.", Calificacion = 10.0, Actores = new List<Actor> { new Actor { Nombre = "Matthew McConaughey", Pais = "USA", Genero = "M", Edad = 53 } } });
            lista.Add(new Pelicula { Nombre = "Dune", AnioEstreno = 2021, Tipo = "Sci-Fi", Sinopsis = "Arena y gusanos.", Calificacion = 9.0, Actores = new List<Actor> { new Actor { Nombre = "Timothée Chalamet", Pais = "USA", Genero = "M", Edad = 27 } } });
            lista.Add(new Pelicula { Nombre = "The Prestige", AnioEstreno = 2006, Tipo = "Sci-Fi", Sinopsis = "Magos.", Calificacion = 9.5, Actores = new List<Actor> { hughJackman, new Actor { Nombre = "Christian Bale", Pais = "UK", Genero = "M", Edad = 49 } } });
            lista.Add(new Pelicula { Nombre = "X-Men", AnioEstreno = 2000, Tipo = "Sci-Fi", Sinopsis = "Mutantes.", Calificacion = 7.5, Actores = new List<Actor> { hughJackman } });
            lista.Add(new Pelicula { Nombre = "Avengers", AnioEstreno = 2012, Tipo = "Sci-Fi", Sinopsis = "Superhéroes.", Calificacion = 9.0, Actores = new List<Actor> { chrisHemsworth } });

            return lista;
        }
    }
}