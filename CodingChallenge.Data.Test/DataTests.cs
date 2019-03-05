using CodingChallenge.Data.Classes;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CodingChallenge.Data.Test
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVaciaIngles()
        {
            //Assert
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), Idioma.Ingles));
        }

        [TestCase]
        public void TestResumenListaVaciaEspaniol()
        {
            //Assert
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), Idioma.SinTraducir));
        }

        [TestCase]
        public void TestResumenListaVaciaFrances()
        {
            //Assert
            Assert.AreEqual("<h1>La liste vide de formes!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), Idioma.Frances));
        }

        [TestCase]
        public void TestResumenListaVaciaItaliano()
        {
            //Assert
            Assert.AreEqual("<h1>Elenco vuoto di forme!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), Idioma.Italiano));
        }

        [TestCase]
        public void TestResumenListaVaciaPortugues()
        {
            //Assert
            Assert.AreEqual("<h1>Lista vazia de formas!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), Idioma.Portugues));
        }

        [TestCase]
        public void TestCreacionDeCirculo()
        {
            //Arrange
            Circulo circulo = new Circulo(10);

            //Act
            // No hay

            //Assert
            Assert.IsNotNull(circulo);
        }

        [TestCase]
        public void TestCreacionDeCuadrado()
        {
            //Arrange
            Cuadrado cuadrado = new Cuadrado(10);

            //Act
            // No hay

            //Assert
            Assert.IsNotNull(cuadrado);
        }

        [TestCase]
        public void TestCreacionDeRectangulo()
        {
            //Arrange
            Rectangulo rectangulo = new Rectangulo(10, 5);

            //Act
            // No hay

            //Assert
            Assert.IsNotNull(rectangulo);
        }

        [TestCase]
        public void TestCreacionDeTriangulo()
        {
            //Arrange
            Triangulo triangulo = new Triangulo(10);

            //Act
            // No hay

            //Assert
            Assert.IsNotNull(triangulo);
        }

        [TestCase]
        public void TestCreacionDeTrapecio()
        {
            //Arrange
            Trapecio trapecio = new Trapecio(10, 20, 5, 4);

            //Act
            // No hay

            //Assert
            Assert.IsNotNull(trapecio);
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            //Arrange
            Cuadrado cuadrado = new Cuadrado(10);
            List<FormaGeometrica> listaDeFormas = new List<FormaGeometrica>();
            listaDeFormas.Add(cuadrado);

            //Act
            var resumen = FormaGeometrica.Imprimir(listaDeFormas, Idioma.SinTraducir);

            //Assert
            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Perímetro: 40 | Área: 100 |<br/>TOTAL :<br/>1 Forma Perímetro: 40 Área: 100", resumen);
        }

        [TestCase]
        public void TestResumenListaConUnCirculoEnIngles()
        {
            //Arrange
            Circulo circulo = new Circulo(10);
            List<FormaGeometrica> listaDeFormas = new List<FormaGeometrica>();
            listaDeFormas.Add(circulo);

            //Act
            var resumen = FormaGeometrica.Imprimir(listaDeFormas, Idioma.Ingles);

            //Assert
            Assert.AreEqual("<h1>Report Forms</h1>1 Circle | Perimeter: 62,83 | Area: 314,16 |<br/>TOTAL :<br/>1 Form Perimeter: 62,83 Area: 314,16", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            //Arrange
            Cuadrado cuadrado = new Cuadrado(10);
            Cuadrado segundoCuadrado = new Cuadrado(5);
            Cuadrado tercerCuadrado = new Cuadrado(18);
            Cuadrado cuartoCuadrado = new Cuadrado(12);

            List<FormaGeometrica> listaDeFormas = new List<FormaGeometrica>();
            listaDeFormas.Add(cuadrado);
            listaDeFormas.Add(segundoCuadrado);
            listaDeFormas.Add(tercerCuadrado);
            listaDeFormas.Add(cuartoCuadrado);

            //Act
            var resumen = FormaGeometrica.Imprimir(listaDeFormas, Idioma.Ingles);

            //Assert
            Assert.AreEqual("<h1>Report Forms</h1>4 Square | Perimeter: 180 | Area: 593 |<br/>TOTAL :<br/>4 Forms Perimeter: 180 Area: 593", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            //Arrange
            Cuadrado cuadrado = new Cuadrado(10);
            Circulo circulo = new Circulo(5);
            Rectangulo rectangulo = new Rectangulo(18, 5);
            Triangulo triangulo = new Triangulo(12);
            Trapecio trapecio = new Trapecio(2, 4, 5, 2);

            List<FormaGeometrica> listaDeFormas = new List<FormaGeometrica>();
            listaDeFormas.Add(cuadrado);
            listaDeFormas.Add(circulo);
            listaDeFormas.Add(rectangulo);
            listaDeFormas.Add(triangulo);
            listaDeFormas.Add(trapecio);

            var resumen = FormaGeometrica.Imprimir(listaDeFormas, Idioma.SinTraducir);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Perímetro: 40 | Área: 100 |<br/>1 Circulo | Perímetro: 31,42 | Área: 78,54 |<br/>1 Rectangulo | Perímetro: 46 | Área: 90 |<br/>1 Triangulo | Perímetro: 36 | Área: 62,35 |<br/>1 Trapecio | Perímetro: 10 | Área: 20 |<br/>TOTAL :<br/>5 Formas Perímetro: 163,42 Área: 350,89", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposIngles()
        {
            //Arrange
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

            //Act
            var resumen = FormaGeometrica.Imprimir(listaDeFormas, Idioma.Ingles);

            //Assert
            Assert.AreEqual("<h1>Report Forms</h1>1 Square | Perimeter: 8 | Area: 4 |<br/>1 Circle | Perimeter: 12,57 | Area: 12,57 |<br/>1 Rectangle | Perimeter: 8 | Area: 4 |<br/>1 Triangle | Perimeter: 6 | Area: 1,73 |<br/>1 Trapeze | Perimeter: 10 | Area: 20 |<br/>TOTAL :<br/>5 Forms Perimeter: 44,57 Area: 42,3", resumen);
        }

        [TestCase]
        public void TestObtenerCodigoIdiomaIngles()
        {
            //Act
            string codigoDeIdioma = FormaGeometrica.ObtenerCodigoIdioma(Idioma.Ingles);

            //Assert
            Assert.AreEqual("en", codigoDeIdioma);
        }

        [TestCase]
        public void TestObtenerCodigoIdiomaItaliano()
        {
            //Act
            string codigoDeIdioma = FormaGeometrica.ObtenerCodigoIdioma(Idioma.Italiano);

            //Assert
            Assert.AreEqual("it", codigoDeIdioma);
        }

        [TestCase]
        public void TestObtenerCodigoIdiomaFrances()
        {
            //Act
            string codigoDeIdioma = FormaGeometrica.ObtenerCodigoIdioma(Idioma.Frances);

            //Assert
            Assert.AreEqual("fr", codigoDeIdioma);
        }

        [TestCase]
        public void TestObtenerCodigoIdiomaPortugues()
        {
            //Act
            string codigoDeIdioma = FormaGeometrica.ObtenerCodigoIdioma(Idioma.Portugues);

            //Assert
            Assert.AreEqual("pt", codigoDeIdioma);
        }

        [TestCase]
        public void TestObtenerCodigoIdiomaEspaniol()
        {
            //Act
            string codigoDeIdioma = FormaGeometrica.ObtenerCodigoIdioma(Idioma.SinTraducir);

            //Assert
            Assert.AreEqual("es", codigoDeIdioma);
        }
    }
}
