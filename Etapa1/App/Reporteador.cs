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
            //establecemos el origen de datos:
            var listaEvaluaciones = getListaEvaluaciones();

            //Esto devolverá una lista de asignaturas cuya evaluacion es mayor a 3.0
            return (from Evaluacion ev in listaEvaluaciones
                   select ev.Asignatura.Nombre).Distinct();
        }
    }
}
