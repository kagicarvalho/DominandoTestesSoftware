using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.Tests
{
    public class AssertStringsTests
    {
        [Fact(DisplayName = "Retornar mome completo")]
        [Trait("Categoria", "Teste Assert Strings")]
        public void StringsTools_UnirNomes_retornarNomeCompleto()
        {
            // Arrange
            var sut = new StringsTools();

            // Act
            var nomeCompleto = sut.Unir("Kagi", "Carvalho");

            // Assert
            Assert.Equal("Kagi Carvalho", nomeCompleto);
        }

        [Fact(DisplayName = "Ignorar maiusculo e minusculo")]
        [Trait("Categoria", "Teste Assert Strings")]
        public void StringsTools_UnirNomes_DeveIgnorarCase()
        {
            // Arrange
            var sut = new StringsTools();

            // Act
            var nomeCompleto = sut.Unir("Kagi", "Carvalho");

            // Assert
            Assert.Equal("KAGI CARVALHO", nomeCompleto, true);
        }

        [Fact(DisplayName = "Verificar se contem determinado trecho")]
        [Trait("Categoria", "Teste Assert Strings")]
        public void StringsTools_UnirNomes_DeveConterTrecho()
        {
            // Arrange
            var sut = new StringsTools();

            // Act
            var nomeCompleto = sut.Unir("Kagi", "Carvalho");

            // Assert
            Assert.Contains("alho", nomeCompleto);
        }

        [Fact(DisplayName = "Verificar se comecar com determinadas palavras")]
        [Trait("Categoria", "Teste Assert Strings")]
        public void StringsTools_UnirNomes_DeveComecarCom()
        {
            // Arrange
            var sut = new StringsTools();

            // Act
            var nomeCompleto = sut.Unir("Kagi", "Carvalho");

            // Assert
            Assert.StartsWith("Ka", nomeCompleto);
        }


        [Fact(DisplayName = "Verificar se acaba com determinadas palavras")]
        [Trait("Categoria", "Teste Assert Strings")]
        public void StringsTools_UnirNomes_DeveAcabarCom()
        {
            // Arrange
            var sut = new StringsTools();

            // Act
            var nomeCompleto = sut.Unir("Kagi", "Carvalho");

            // Assert
            Assert.EndsWith("lho", nomeCompleto);
        }


        [Fact(DisplayName = "Validar usando Expressao regular (REGEX)")]
        [Trait("Categoria", "Teste Assert Strings")]
        public void StringsTools_UnirNomes_ValidarExpressaoRegular()
        {
            // Arrange
            var sut = new StringsTools();

            // Act
            var nomeCompleto = sut.Unir("Kagi", "Carvalho");

            // Assert
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", nomeCompleto);
        }
    }
}
