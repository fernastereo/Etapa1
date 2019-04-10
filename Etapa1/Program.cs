using CorEscuela.Entidades;
using CorEscuela.Util;
using System;
using System.Collections.Generic;
using static System.Console; //Esto me va a permitir no tener que escribir la palabra Console en los writeline

namespace CorEscuela {
    class Program {
        static void Main(string[] args) {
            //Division entera (modulo-MOD): se usa % ej: if(numero % 5 == 0), y: &&, o: ||

            var engine = new EscuelaEngine();
            engine.Inicializar();

            Printer.WriteTittle("Bienvenidos a la Escuela");
            //Printer.Pitar(1000, 1500, 4);
            imprimirCursosEscuela(engine.Escuela);

            ////******** FORMAS DE USAR EL METODO REMOVEALL *******************
            ////escuela.Cursos.Remove(nuevoCurso); aqui borra a través del hash del objeto pero no es seguro ya que puede haber mas de uno con el mismo hash

            ////La otra forma es con el método RemoveAll, para lo cual necesita definirse un predicado
            //Predicate<Curso> miAlgoritmo = Predicado;
            //escuela.Cursos.RemoveAll(miAlgoritmo);

            ////Otra forma de usar el método RemoveAll, aqui se envía el predicado directamente sin definir miAlgoritmo antes
            //escuela.Cursos.RemoveAll(Predicado);
            ////NOTA: para estos dos casos recordar que Predicado es un método definido abajo y que 
            ////funciona como delegado ya que su firma está definida previamente en el framework

            ////Otra forma de usar el método RemoveAll, aqui se crea el delegado directamente al llamar el método
            ////es algo así como llamar a una funcion anónima
            //escuela.Cursos.RemoveAll(delegate (Curso cur) { return cur.Nombre == "VACACIONAL"; });

            ////Otra forma de usar el método RemoveAll, aqui usamos las expresiones Lambda, estas son tambien 
            ////como una funcion anónima. Se puede mandar sin tipo
            //escuela.Cursos.RemoveAll((Curso cur) => cur.Nombre == "VACACIONAL");
            ////***************************************************************

            /* PRUEBAS CON POLIMORFISMO
            Printer.DrawLine(28);
            Printer.DrawLine(28);
            Printer.DrawLine(28);
            Printer.WriteTittle("Pruebas con Polimorfismo");

            var alumnoTest = new Alumno { Nombre = "El Ferna Stereo" };
            
            Printer.WriteTittle("Alumno");
            WriteLine($"Alumno: {alumnoTest.UniqueId}");
            WriteLine($"Alumno: {alumnoTest.Nombre}");
            WriteLine($"Alumno: {alumnoTest.GetType()}");

            ObjetoEscuelaBase ob = alumnoTest;
            Printer.WriteTittle("Objeto Escuela Alumno");
            WriteLine($"Alumno: {ob.UniqueId}");
            WriteLine($"Alumno: {ob.Nombre}");
            WriteLine($"Alumno: {ob.GetType()}");

            var objDummy = new ObjetoEscuelaBase() { Nombre = "Leonor Gazmo"};
            Printer.WriteTittle("Objeto Escuela Base");
            WriteLine($"Alumno: {objDummy.UniqueId}");
            WriteLine($"Alumno: {objDummy.Nombre}");
            WriteLine($"Alumno: {objDummy.GetType()}");

            var evaluacion = new Evaluacion()
            {
                Nombre = "Evaluación Matemáticas",
                Nota = 4.5f
            };
            Printer.WriteTittle("Evaluación");
            WriteLine($"evaluacion: {evaluacion.UniqueId}");
            WriteLine($"evaluacion: {evaluacion.Nombre}");
            WriteLine($"evaluacion: {evaluacion.Nota}");
            WriteLine($"evaluacion: {evaluacion.GetType()}");

            ob = evaluacion;
            //Printer.WriteTittle("Objeto Escuela Evaluacion");
            //WriteLine($"Alumno: {ob.UniqueId}");
            //WriteLine($"Alumno: {ob.Nombre}");
            //WriteLine($"Alumno: {ob.GetType()}");

            if(ob is Alumno) //is: para preguntar si un objeto es de un tipo determinado
            {
                Alumno alumnoRecuperado = (Alumno)ob;
            }

            Alumno alumnoRecuperado2 = ob as Alumno;
            FIN PRUEBAS CON POLIMORFISMO  */

            var listaObjetos = engine.getObjetosEscuela();

            ReadLine();
        }

        private static bool Predicado(Curso cursoObj) {
            return cursoObj.Nombre == "VACACIONAL";
        }

        private static void imprimirCursosEscuela(Escuela escuela) {
            if (escuela?.Cursos != null) { //el signo ? quiere decir que verifica si es null primero la clase y luego la propiedad
                Printer.WriteTittle("Escuela Cursos");
                foreach (var curso in escuela.Cursos) {
                    WriteLine(curso.Nombre + " - " + curso.UniqueId);
                }
            }
        }

        private static void imprimirCursos(Curso[] arregloCursos) {
            WriteLine("======Arreglo Cursos=======");
            foreach (var curso in arregloCursos) {
                WriteLine(curso.Nombre + " - " + curso.UniqueId);
            }

        }
    }
}
