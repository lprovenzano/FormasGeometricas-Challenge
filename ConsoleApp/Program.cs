using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodingChallenge.Data.Classes;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Formas geometricas";

            try
            {
                //Delegado
                ThreadStart delegado = new ThreadStart(CorrerProceso);
                //Hilo
                Thread hilo = new Thread(delegado);
                //Lanzo el hilo
                hilo.Start();

                //Animación en pantalla mientras realiza el hilo por detrás...
                ConsoleSpinner spinner = new ConsoleSpinner();
                ConsoleSpinner.Write(spinner, hilo);
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Read();

        }
        /// <summary>
        /// Handler proceso de formas geométricas
        /// </summary>
        public static void CorrerProceso()
        {
            ////Creo nuevas formas
            Cuadrado cuadrado = new Cuadrado(2);
            Circulo circulo = new Circulo(2);
            Rectangulo rectangulo = new Rectangulo(2, 2);
            Triangulo triangulo = new Triangulo(2);
            Trapecio trapecio = new Trapecio(2, 4, 5, 2);

            List<FormaGeometrica> listaDeFormas = new List<FormaGeometrica>();
            listaDeFormas.Add(cuadrado);
            listaDeFormas.Add(circulo);
            listaDeFormas.Add(rectangulo);
            listaDeFormas.Add(triangulo);
            listaDeFormas.Add(trapecio);

            //Reporte en pantalla
            Console.WriteLine(FormaGeometrica.Imprimir(listaDeFormas, Idioma.Ingles));
        }
    }

    /// <summary>
    /// Esta clase se utiliza solo en este proyecto y es únicamente para representar gráficamente los resultados.
    /// </summary>
    internal class ConsoleSpinner
    {
        private int counter;
        /// <summary>
        /// Constructor
        /// </summary>
        public ConsoleSpinner()
        {
            counter = 0;
        }

        /// <summary>
        /// Animacion mientras se ejecuta el hilo
        /// </summary>
        public void Turn()
        {
            counter++;
            switch (counter % 4)
            {
                case 0: Console.Write("/"); break;
                case 1: Console.Write("-"); break;
                case 2: Console.Write("\\"); break;
                case 3: Console.Write("|"); break;
            }
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }

        /// <summary>
        /// Print en pantalla de turn(). Cuando finaliza el hilo, deja de animar
        /// </summary>
        /// <param name="spinner">Object Spinner</param>
        /// <param name="hilo">Un hilo</param>
        public static void Write(ConsoleSpinner spinner, Thread hilo)
        {
            Console.WriteLine("Traduciendo... ");
            Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("Generando reporte... ");
            while (true)
            {
                spinner.Turn();

                //Si termina de correr el proceso (hilo inactivo), salgo
                if (!hilo.IsAlive)
                {
                    break;
                }
            }
        }
    }


}
