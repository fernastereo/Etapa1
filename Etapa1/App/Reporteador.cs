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

        public IEnumerable<Escuela> getListaEvaluaciones() {

            IEnumerable<Escuela> rta;

            if (_diccionario.TryGetValue(LlaveDiccionario.Escuela, out IEnumerable<ObjetoEscuelaBase> lista))
            {
                //TryGetValue devuelve true si trae el diccionario
                rta = lista.Cast<Escuela>();
            } else
            {
                rta = null;
            }

            return rta;
        }
    }
}
