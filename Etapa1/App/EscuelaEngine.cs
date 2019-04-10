using CorEscuela.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CorEscuela {
    public sealed class EscuelaEngine {
        //es lo contrario a abstract, en este caso sealed significa que
        //puedo instanciarla mas no heredarla

        public Escuela Escuela { get; set; }

        public EscuelaEngine() {
        }

        public void Inicializar() {

            Escuela = new Escuela("Jose Eusebio Caro", 1952, TiposEscuela.Secundaria, "Colombie", "Barranquilla");
            Escuela.Pais = "Colombia";
            Escuela.Ciudad = "Barranquilla";
            Escuela.TipoEscuela = TiposEscuela.Secundaria;
            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();
        }

        private void CargarEvaluaciones() {
            var lista = new List<Evaluacion>();

            /*
             * Aqui por cada curso en escuela, 
             * por cada asignatura del curso,
             * por cada alumno del curso,
             * creamos 5 evalauaciones por cada alumno y al final se la asignamos al alumno
             */
            foreach (var curso in Escuela.Cursos) {
                foreach (var asignatura in curso.Asignaturas) {
                    foreach (var alumno in curso.Alumnos) {
                        var rnd = new Random(System.Environment.TickCount);
                        for (int i = 0; i < 5; i++) {
                           // se instancia la clase evaluacion
                            var ev = new Evaluacion {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Ev#{i + 1}",

                                Nota = (float)(5 * rnd.NextDouble()),
                                Alumno = alumno
                            };
                            alumno.Evaluaciones.Add(ev);
                        }
                    }

                }

            }
        }

        public List<ObjetoEscuelaBase> getObjetosEscuela()
        {
            //Crea una lista polimorfica con todos los objetos de la escuela
            var listaObj = new List<ObjetoEscuelaBase>();
            listaObj.Add(Escuela);
            listaObj.AddRange(Escuela.Cursos);
            foreach (var curso in Escuela.Cursos)
            {
                listaObj.AddRange(curso.Asignaturas);
                listaObj.AddRange(curso.Alumnos);

                foreach (var alumno in curso.Alumnos)
                {
                    listaObj.AddRange(alumno.Evaluaciones);
                }
            }

            return listaObj;
        }

        private void CargarAsignaturas() {
            foreach (var curso in Escuela.Cursos) {
                List<Asignatura> listaAsignaturas = new List<Asignatura>(){
                    new Asignatura { Nombre = "Matemáticas" },
                    new Asignatura { Nombre = "Educación Física" },
                    new Asignatura { Nombre = "Castellano" },
                    new Asignatura { Nombre = "Ciencias Naturales" }
                };

                //curso.Asignaturas.AddRange(listaAsignaturas);
                //No se puede usar addRange porque apenas se van a crear las asignaturas
                curso.Asignaturas = listaAsignaturas;
            }
        }

        //uso de linq en arrays
        private List<Alumno> GenerarAlumnosAlAzar(int cantidad) {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolas" };
            string[] apellido1 = { "Ruiz", "Castro", "Martínez", "Perez", "Altamar", "Vega", "Ospino" };
            string[] nombre2 = { "Maura", "Laura", "Verónica", "Juanita", "Diogenes", "Alirio", "Andres" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };

            return listaAlumnos.OrderBy((al)=>al.UniqueId).Take(cantidad).ToList();
        }

        private void CargarCursos() {
            /*
            //Creacion de varios objetos de tipo Curso (clase)
            var curso1 = new Curso() { Nombre = "11-1", Jornada = Jornadas.Matinal };
            var curso2 = new Curso() { Nombre = "11-2", Jornada = Jornadas.Matinal };
            var curso3 = new Curso() { Nombre = "11-3", Jornada = Jornadas.Matinal };

            Console.WriteLine("Creando Los Objetos Curso Uno por Uno");
            Console.WriteLine(escuela);
            Console.WriteLine("=======================");
            Console.WriteLine(curso1.Nombre + " - " + curso1.UniqueId);
            Console.WriteLine($"{curso2.Nombre} - {curso2.UniqueId}");
            Console.WriteLine(curso3);
            */

            /*
            //Creacion de un arreglo (Longitud de arreglo es Length)
            var arregloCursos = new Curso[3] {
                new Curso() { Nombre = "11-1", Jornada = Jornadas.Matinal },
                new Curso() { Nombre = "11-2", Jornada = Jornadas.Matinal },
                new Curso() { Nombre = "11-3", Jornada = Jornadas.Matinal }
            };
            
            //Otra forma de Creacion de un arreglo
            Curso[] arregloCursos = {
                new Curso() { Nombre = "11-1", Jornada = Jornadas.Matinal },
                new Curso() { Nombre = "11-2", Jornada = Jornadas.Matinal },
                new Curso() { Nombre = "11-3", Jornada = Jornadas.Matinal }
            };
            */

            /*
            //En este caso se creó la propiedad Cursos de tipo array de Curso en la clase Escuela
            escuela.Cursos = new Curso[] {
                new Curso() { Nombre = "11-1", Jornada = Jornadas.Matinal },
                new Curso() { Nombre = "11-2", Jornada = Jornadas.Matinal },
                new Curso() { Nombre = "11-3", Jornada = Jornadas.Matinal }
            };
            */

            //Creando los cursos desde una coleccion
            Escuela.Cursos = new List<Curso>(){
                new Curso() { Nombre = "11-1", Jornada = Jornadas.Matinal },
                new Curso() { Nombre = "11-2", Jornada = Jornadas.Matinal },
                new Curso() { Nombre = "10-1", Jornada = Jornadas.Matinal }
            };

            Escuela.Cursos.Add(new Curso() { Nombre = "10-2", Jornada = Jornadas.Matinal });
            Escuela.Cursos.Add(new Curso() { Nombre = "9-1", Jornada = Jornadas.Matinal });

            //Es posible crear una lista aparte y asignarsela a una lista existente con addRange
            var otraLista = new List<Curso>(){
                new Curso() { Nombre = "9-2", Jornada = Jornadas.Matinal },
                new Curso() { Nombre = "8-1", Jornada = Jornadas.Matinal },
                new Curso() { Nombre = "8-2", Jornada = Jornadas.Matinal }
            };
            Escuela.Cursos.AddRange(otraLista);

            //Eliminar elementos de una Coleccion
            //otraLista.Clear(); //Borra toda la coleccion
            var nuevoCurso = new Curso() { Nombre = "VACACIONAL", Jornada = Jornadas.Matinal };
            Escuela.Cursos.Add(nuevoCurso);

            Random rnd = new Random();
            foreach (var curso in Escuela.Cursos) {
                int cantidadRandom = rnd.Next(5, 20);
                curso.Alumnos = GenerarAlumnosAlAzar(cantidadRandom);
            }
        }
    }
}
