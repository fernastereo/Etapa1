using System;
using System.Collections.Generic;
using System.Text;

namespace CorEscuela.Entidades {
    //Una interfaz es una definicion de la estructura que debe tener un objeto
    interface ILugar {
        string Direccion { get; set; }

        void limpiarLugar();
    }
}
