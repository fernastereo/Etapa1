using System;

namespace CorEscuela.Entidades
{
    public class Evaluacion : ObjetoEscuelaBase
    {
        public Alumno Alumno { get; set; }
        public Asignatura Asignatura  { get; set; }

        public float Nota { get; set; }

        public override string ToString()
        {
            //aqui vamos a sobreescribir el método ToString para esta clase
            return $"{Nota}, {Alumno.Nombre}, {Asignatura.Nombre}";
        }
    }
}