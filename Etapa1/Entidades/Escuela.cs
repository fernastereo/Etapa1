using CorEscuela.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorEscuela.Entidades {
    public class Escuela : ObjetoEscuelaBase, ILugar {
        
        public int AñoDeCreacion { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public TiposEscuela TipoEscuela { get; set; }
        //public Curso[] Cursos { get; set; }
        public List<Curso> Cursos { get; set; }

        //public Escuela(string nombre, int año) {
        //    Nombre = nombre;
        //    AñoDeCreacion = año;
        //}
        //Este constructor hace lo mismo que el de arriba (Igualación por Tuplas)
        public Escuela(string nombre, int año) => (Nombre, AñoDeCreacion) = (nombre, año);

        public Escuela(string nombre, int año, 
            TiposEscuela tipo, 
            string pais="", 
            string ciudad="") {
            (Nombre, AñoDeCreacion) = (nombre, año);
            TipoEscuela = tipo;
            Ciudad = ciudad;
            Pais = pais;

            //var eb = new ObjetoEscuelaBase();
        }

        public override string ToString() {
            return $"Nombre: {Nombre}, Tipo: {TipoEscuela}, \nPaís: {Pais}, Ciudad: {Ciudad}";
        }

        public void limpiarLugar() {
            Printer.DrawLine();
            Console.WriteLine("LIMPIANDO LA ESCUELA....!!");

            foreach (var curso in Cursos)
            {
                curso.limpiarLugar();
            }

            Printer.WriteTittle($"ESCUELA {Nombre} LIMPIA");
        }

    }
}
