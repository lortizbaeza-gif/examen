using System;
using System.Collections.Generic;
using MoviesApp.Application;
using MoviesApp.Core;

namespace MoviesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PeliculaService servicio = new PeliculaService();

            Console.WriteLine("=== SISTEMA DE GESTIÓN DE PELÍCULAS ===");
            Console.WriteLine("Cargando datos del sistema...");
            
            // 1. Consultar todas las películas
            var todas = servicio.ObtenerTodas();
            Console.WriteLine($"\n1. Total de películas en el sistema: {todas.Count}");
            // No imprimimos las 25 para no saturar la consola, pero confirmamos la cantidad.

            // 2. Consultar las películas de acción
            Console.WriteLine("\n2. Películas de Acción:");
            var accion = servicio.ObtenerPeliculasDeAccion();
            ImprimirPeliculas(accion);

            // 3. Consultar los actores que han trabajado en películas de terror
            Console.WriteLine("\n3. Actores en películas de Terror:");
            var actoresTerror = servicio.ObtenerActoresDeTerror();
            ImprimirActores(actoresTerror);

            // 4. Consultar todos los actores australianos
            Console.WriteLine("\n4. Actores Australianos:");
            var australianos = servicio.ObtenerActoresAustralianos();
            ImprimirActores(australianos);

            // 5. Consultar todas las películas con calificación perfecta
            Console.WriteLine("\n5. Películas con Calificación Perfecta (10/10):");
            var perfectas = servicio.ObtenerPeliculasPerfectas();
            ImprimirPeliculas(perfectas);

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }

        static void ImprimirPeliculas(List<Pelicula> peliculas)
        {
            if (peliculas.Count == 0)
            {
                Console.WriteLine("   - No se encontraron resultados.");
                return;
            }

            foreach (var p in peliculas)
            {
                Console.WriteLine($"   - {p}");
            }
        }

        static void ImprimirActores(List<Actor> actores)
        {
            if (actores.Count == 0)
            {
                Console.WriteLine("   - No se encontraron resultados.");
                return;
            }

            foreach (var a in actores)
            {
                Console.WriteLine($"   - {a}");
            }
        }
    }
}