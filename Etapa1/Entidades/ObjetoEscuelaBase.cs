using System;
using System.Collections.Generic;
using System.Text;

namespace CorEscuela.Entidades {
    public abstract class ObjetoEscuelaBase {
        /* Una clase abstracta significa que esta fue creada unicamente para ser heredada
         * no sirve para ser instanciada como una clase normal*/
        public string UniqueId { get; private set; }// = Guid.NewGuid().ToString();
        //Otra opcion es hacer la asignacion a la variable en el contructor
        public string Nombre { get; set; }

        public ObjetoEscuelaBase() {
            UniqueId = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            //aqui vamos a sobreescribir el método ToString para esta clase
            return $"{Nombre}, {UniqueId}";
        }
    }
}
