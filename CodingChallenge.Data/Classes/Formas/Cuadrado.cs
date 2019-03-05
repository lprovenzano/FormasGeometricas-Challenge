using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Cuadrado : FormaGeometrica, IForma
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="lado">lado</param>
        public Cuadrado(decimal lado)
        {
            this.lado = lado;
        }

        /// <summary>
        /// Devuelve el área del cuadrado
        /// </summary>
        public decimal ObtenerArea
        {
            get
            {
                return CalcularArea();
            }
        }

        /// <summary>
        /// Devuelve el perímetro del cuadrado
        /// </summary>
        public decimal ObtenerPerimetro
        {
            get
            {
                return CalcularPerimetro();
            }
        }

        /// <summary>
        /// Calcula el área del cuadrado
        /// </summary>
        /// <returns></returns>
        protected override decimal CalcularArea()
        {
            return this.lado * this.lado;
        }

        /// <summary>
        /// Calcula el perímetro del cuadrado
        /// </summary>
        /// <returns></returns>
        protected override decimal CalcularPerimetro()
        {
            return this.lado*4;
        }
    }
}
