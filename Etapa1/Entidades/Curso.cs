using System;
using System.Collections.Generic;

namespace CorEscuela.Entidades
{
    public class Curso: ObjetoEscuelaBase
    {
        public Jornadas Jornada { get; set; }
        public List<Asignatura> Asignaturas{ get; set; }
        public List<Alumno> Alumnos{ get; set; }
    }
}