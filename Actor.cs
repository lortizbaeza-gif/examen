using System;

namespace MoviesApp.Core
{
    public class Actor
    {
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public string Genero { get; set; }
        public int Edad { get; set; }

        // Sobrescribimos ToString para facilitar la impresión en consola
        public override string ToString() => $"{Nombre} ({Pais}, {Edad} años)";
    }
}