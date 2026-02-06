using System;
using System.Collections.Generic;

namespace MoviesApp.Core
{
    public class Pelicula
    {
        public string Nombre { get; set; }
        public int AnioEstreno { get; set; }
        public string Tipo { get; set; } // Género (Accion, Terror, etc.)
        public string Sinopsis { get; set; }
        public List<Actor> Actores { get; set; } = new List<Actor>();
        public double Calificacion { get; set; } // Escala de 0 a 10

        public override string ToString() => $"{Nombre} ({AnioEstreno}) - {Tipo} - Calificación: {Calificacion}/10";
    }
}