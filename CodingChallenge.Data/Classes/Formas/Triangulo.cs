using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    /// <summary>
    /// Triángulo equilátero
    /// </summary>
    public class Triangulo : FormaGeometrica, IForma
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="lado">lado</param>
        public Triangulo(decimal lado)
        {
            this.lado = lado;
        }

        /// <summary>
        /// Devuelve el área del triángulo
        /// </summary>
        public decimal ObtenerArea
        {
            get
            {
                return CalcularArea();
            }
        }

        /// <summary>
        /// Devuelve el perímetro del triángulo
        /// </summary>
        public decimal ObtenerPerimetro
        {
            get
            {
                return CalcularPerimetro();
            }
        }

        /// <summary>
        /// Calcula el área del triángulo
        /// </summary>
        /// <returns></returns>
        protected override decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * this.lado * this.lado;
        }

        /// <summary>
        /// Calcula el perímetro del triángulo
        /// </summary>
        /// <returns></returns>
        protected override decimal CalcularPerimetro()
        {
            return this.lado * 3;
        }
    }
}
