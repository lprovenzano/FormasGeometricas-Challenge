using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Rectangulo : FormaGeometrica, IForma
    {
        private decimal ladoMayor;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="lado">lado menor</param>
        /// <param name="ladoMayor">lado mayor</param>
        public Rectangulo(decimal lado, decimal ladoMayor)
        {
            this.lado = lado;
            this.ladoMayor = ladoMayor;
        }

        /// <summary>
        /// Devuelve el área del rectángulo
        /// </summary>
        public decimal ObtenerArea
        {
            get
            {
                return CalcularArea();
            }
        }

        /// <summary>
        /// Devuelve el perímetro del rectángulo
        /// </summary>
        public decimal ObtenerPerimetro
        {
            get
            {
                return CalcularPerimetro();
            }
        }

        /// <summary>
        /// Calcula el área del rectángulo
        /// </summary>
        /// <returns></returns>
        protected override decimal CalcularArea()
        {
            return this.lado * this.ladoMayor;
        }

        /// <summary>
        /// Calcula el perímetro del rectángulo
        /// </summary>
        /// <returns></returns>
        protected override decimal CalcularPerimetro()
        {
            return 2 * (this.lado + this.ladoMayor);
        }
    }
}
