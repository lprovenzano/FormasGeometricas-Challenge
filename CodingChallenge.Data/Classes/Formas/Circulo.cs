using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Circulo : FormaGeometrica, IForma
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="radio">radio</param>
        public Circulo(decimal radio)
        {
            this.lado = radio;
        }

        /// <summary>
        /// Devuelve el área del círculo
        /// </summary>
        public decimal ObtenerArea
        {
            get
            {
                return CalcularArea();
            }
        }
        /// <summary>
        /// Devuelve el perímetro del círculo
        /// </summary>
        public decimal ObtenerPerimetro
        {
            get
            {
                return CalcularPerimetro();
            }
        }

        /// <summary>
        /// Calcula el área del círculo
        /// </summary>
        /// <returns></returns>
        protected override decimal CalcularArea()
        {
            return (decimal)Math.PI * (decimal)Math.Pow((double)this.lado, 2);
        }

        /// <summary>
        /// Calcula el perímetro del círculo
        /// </summary>
        /// <returns></returns>
        protected override decimal CalcularPerimetro()
        {
            return 2*(decimal)Math.PI * this.lado;
        }
    }
}
