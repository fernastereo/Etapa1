using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace CorEscuela.Util {
    public static class Printer {
        //Clase static: es una clase que se puede usar como objeto, 
        //no necesita (permite) instanciarse (es como si fuera un modulo)

        public static void DrawLine(int tam = 10) {
            var linea = "".PadLeft(tam, '=');
            WriteLine(linea);
        }

        public static void WriteTittle(string titulo) {
            var tam = titulo.Length + 4;
            DrawLine(tam);
            WriteLine($"| {titulo} |");
            DrawLine(tam);
        }

        public static void Pitar (int hz = 2000, int tiempo = 1000, int cantidad = 1) {
            while (cantidad-- > 0) {
                Beep(hz, tiempo);
            }
        }
    }
}
