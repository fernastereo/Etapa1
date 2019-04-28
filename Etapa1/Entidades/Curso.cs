using CorEscuela.Util;
using System;
using System.Collections.Generic;

namespace CorEscuela.Entidades
{
    public class Curso: ObjetoEscuelaBase, ILugar
    {
        public TiposJornadas Jornada { get; set; }
        public List<Asignatura> Asignaturas{ get; set; }
        public List<Alumno> Alumnos{ get; set; }
        public string Direccion { get; set; }

        public void limpiarLugar() {
            Printer.DrawLine();
            Console.WriteLine("LIMPIANDO EL LUGAR....!!");
            Console.WriteLine($"CURSO {Nombre} LIMPIO");
        }
    }
}