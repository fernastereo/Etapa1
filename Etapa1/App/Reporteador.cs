using CorEscuela.Entidades;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CorEscuela {
    class Reporteador {

        Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;

        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dicObsEsc) {
            if (dicObsEsc == null)
            {
                throw new ArgumentException(nameof(dicObsEsc));
            }
            _diccionario = dicObsEsc;
        }

        public IEnumerable<Evaluacion> getListaEvaluaciones() {

            if (_diccionario.TryGetValue(LlaveDiccionario.Evaluacion, out IEnumerable<ObjetoEscuelaBase> lista))
            {
                //TryGetValue devuelve true si trae el diccionario
                return lista.Cast<Evaluacion>();
            } else
            {
                return new List<Evaluacion>();
            }

        }

        public IEnumerable<string> getListaAsignaturas() {
            return getListaAsignaturas(out var dummy);
        }

        public IEnumerable<string> getListaAsignaturas(out IEnumerable<Evaluacion> listaEvaluaciones) {
            //establecemos el origen de datos:
            listaEvaluaciones = getListaEvaluaciones();

            //Esto devolverá una lista de asignaturas cuya evaluacion es mayor a 3.0
            return (from Evaluacion ev in listaEvaluaciones
                   select ev.Asignatura.Nombre).Distinct();
        }

        public Dictionary<string, IEnumerable<Evaluacion>> getDicEvalxAsig() {
            //Declaramos el diccionario que se va a devolver como respuesta:
            var dicRta = new Dictionary<string, IEnumerable<Evaluacion>>();

            //Declaramos una variable que va a tener la lista de asignaturas unica
            //y tambien un parametro de salida con la lista de las evaluaciones:
            var listaAsig = getListaAsignaturas(out var listaEval);

            //recorremos cada una de las asignaturas devueltas:
            foreach (var asig in listaAsig)
            {
                //consultamos todas las evaluaciones por cada una de las asignaturas del bucle
                var evalxAsig = from eval in listaEval
                                where eval.Asignatura.Nombre == asig
                                select eval;
                //agregamos cada asignatura con su lista de evaluaciones al diccionario
                dicRta.Add(asig, evalxAsig);
            }

            //dovolvemos el diccionario
            return dicRta;
        }

        public Dictionary<string, IEnumerable<object>> getPromAlumnoxAsignatura() {
            var rta = new Dictionary<string, IEnumerable<object>>();
            var dicEvalxAsign = getDicEvalxAsig();

            foreach (var asigConEval in dicEvalxAsign)
            {
                var promsAlumno = from eval in asigConEval.Value
                            group eval by new
                            {
                                eval.Alumno.UniqueId,
                                eval.Alumno.Nombre
                            }
                            into grupoEvalsAlumno
                            select new AlumnoPromedio
                            {
                                alumnoId = grupoEvalsAlumno.Key.UniqueId,
                                alumnoNombre = grupoEvalsAlumno.Key.Nombre,
                                promedio = grupoEvalsAlumno.Average(cualquierCosa => cualquierCosa.Nota)
                            };
                rta.Add(asigConEval.Key, promsAlumno);
            }

            return rta;
        }
    }
}
