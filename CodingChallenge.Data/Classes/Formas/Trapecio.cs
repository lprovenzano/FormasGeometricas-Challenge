using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    /// <summary>
    /// Trapecio Isósceles
    /// </summary>
    public class Trapecio : FormaGeometrica, IForma
    {
        private decimal baseMayor;
        private decimal baseMenor;
        private decimal altura;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="baseMenor">base menor</param>
        /// <param name="baseMayor">base mayor</param>
        /// <param name="altura">altura</param>
        /// <param name="lado">lados laterales</param>
        public Trapecio(decimal baseMenor, decimal baseMayor, decimal altura, decimal lado)
        {

            this.lado = lado;
            this.baseMayor = baseMayor;
            this.baseMenor = baseMenor;
            this.altura = altura;

            if (this.baseMenor > this.baseMayor)
                throw new ArgumentException("La base mayor debe ser superior a la base menor");

        }

        /// <summary>
        /// Devuelve el área del trapecio
        /// </summary>
        public decimal ObtenerArea
        {
            get
            {
                return CalcularArea();
            }
        }

        /// <summary>
        /// Devuelve el perímetro del trapecio
        /// </summary>
        public decimal ObtenerPerimetro
        {
            get
            {
                return CalcularPerimetro();
            }
        }

        /// <summary>
        /// Calcula el área del trapecio
        /// </summary>
        /// <returns></returns>
        protected override decimal CalcularArea()
        {
            return (this.baseMayor * this.baseMenor) / 2 * altura;
        }

        /// <summary>
        /// Calcula el perímetro del trapecio
        /// </summary>
        /// <returns></returns>
        protected override decimal CalcularPerimetro()
        {
            return (this.baseMenor + this.baseMayor + (2 * this.lado));
        }
    }
}
