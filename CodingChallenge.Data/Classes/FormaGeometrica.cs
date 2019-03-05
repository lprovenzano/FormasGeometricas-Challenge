/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.
 *
 * TODO: Implementar Trapecio/Rectangulo, agregar otro idioma a reporting.
 * */

using CodingChallenge.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenge.Data.Classes
{
    public abstract class FormaGeometrica
    {
        #region Atributos
        protected decimal lado;
        #endregion

        #region Metodos
        /// <summary>
        /// Calcula el área
        /// </summary>
        /// <returns></returns>
        protected abstract decimal CalcularArea();

        /// <summary>
        /// Calcula el perímetro
        /// </summary>
        /// <returns></returns>
        protected abstract decimal CalcularPerimetro();

        /// <summary>
        /// Genera un reporte de formas en el idioma especificado
        /// </summary>
        /// <param name="formas">Lista de formas</param>
        /// <param name="idioma">Idioma</param>
        /// <returns></returns>
        public static string Imprimir(List<FormaGeometrica> formas, Idioma idioma)
        {
            StringBuilder sb = new StringBuilder();
            string codigoIdioma = ObtenerCodigoIdioma(idioma);

            List<FormaModel> datosDeFormasEnLista = new List<FormaModel>();
            Dictionary<string, int> cantidadDeFormas = new Dictionary<string, int>();

            try
            {
                //No hay formas
                if (!formas.Any())
                {
                    return string.Format("<h1>{0}</h1>", Traductor.Traducir("Lista vacía de formas!", codigoIdioma));
                }

                //Hay al menos una forma
                sb.Append(string.Format("<h1>{0}</h1>", Traductor.Traducir("Reporte de Formas", codigoIdioma)));

                foreach (IForma forma in formas)
                {
                    //Obtengo el dato de una forma y lo guardo en un modelo
                    FormaModel unaForma = new FormaModel();
                    unaForma.TipoForma = forma.GetType().Name; //Nombre
                    unaForma.Perimetro = forma.ObtenerPerimetro; //Perímetro
                    unaForma.Area = forma.ObtenerArea; //Área

                    //Busco el índice de la forma en la lista por tipo
                    int index = datosDeFormasEnLista.FindIndex(a => a.TipoForma == unaForma.TipoForma);

                    //Si existe, sumo su perimetro y area para obtener el total de ese tipo de forma
                    if (index > -1)
                    {
                        datosDeFormasEnLista[index].Perimetro += unaForma.Perimetro;
                        datosDeFormasEnLista[index].Area += unaForma.Area;
                    }
                    //Sino, la agrego a la lista
                    else
                    {
                        datosDeFormasEnLista.Add(unaForma);
                    }
                    //Verifico si la key con el tipo de forma no exista y la agrego.
                    if (!cantidadDeFormas.ContainsKey(unaForma.TipoForma))
                    {
                        cantidadDeFormas.Add(unaForma.TipoForma, 1);
                    }
                    //Si existe, sumo uno en esa key (+1 forma)
                    else
                    {
                        cantidadDeFormas[unaForma.TipoForma] += 1;
                    }

                }

                //Armo el detalle del reporte
                foreach (FormaModel forma in datosDeFormasEnLista)
                {
                    sb.Append(
                        string.Format("{0} {1} | {2}: {3} | {4}: {5} |<br/>",
                                     cantidadDeFormas[forma.TipoForma],
                                     cantidadDeFormas[forma.TipoForma] > 1 ? Traductor.Traducir(forma.TipoForma + "s", codigoIdioma) : Traductor.Traducir(forma.TipoForma, codigoIdioma),
                                     Traductor.Traducir("Perímetro", codigoIdioma),
                                     forma.Perimetro.ToString("#.##"),
                                     Traductor.Traducir("Área", codigoIdioma),
                                     forma.Area.ToString("#.##")
                        )
                    );
                }


                // FOOTER
                sb.Append(string.Format("{0} :<br/>", Traductor.Traducir("total", codigoIdioma).ToUpper()));
                sb.Append(
                    string.Format("{0} {1}",
                                 cantidadDeFormas.Sum(x => x.Value),
                                 cantidadDeFormas.Sum(x => x.Value) > 1 ? Traductor.Traducir("Formas", codigoIdioma) : Traductor.Traducir("Forma", codigoIdioma)
                                 )
                );
                sb.Append(Traductor.Traducir(" Perímetro", codigoIdioma) + ": " + formas.Where(x => x is IForma).Sum(x => ((IForma)x).ObtenerPerimetro).ToString("#.##"));
                sb.Append(Traductor.Traducir(" Área", codigoIdioma) + ": " + formas.Where(x => x is IForma).Sum(x => ((IForma)x).ObtenerArea).ToString("#.##"));

                return sb.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Devuelve el código de país/idioma para enviar a la API de traductor
        /// </summary>
        /// <param name="idioma">Enumerado idioma</param>
        /// <returns></returns>
        public static string ObtenerCodigoIdioma(Idioma idioma)
        {
            string codigo = string.Empty;

            switch (idioma)
            {
                case Idioma.Ingles:
                    codigo = "en";
                    break;
                case Idioma.Frances:
                    codigo = "fr";
                    break;
                case Idioma.Portugues:
                    codigo = "pt";
                    break;
                case Idioma.Italiano:
                    codigo = "it";
                    break;
                case Idioma.SinTraducir:
                    codigo = "es";
                    break;
            }

            return codigo;
        }

        #endregion

    }
}
