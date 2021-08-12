using Features.Tests.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Features.Tests.DadosHumanos
{
    [Collection(nameof(ClienteBogusCollection))]
    public class ClienteBogusTests
    {
        private readonly ClienteBogusFixtureTests _clienteBogusFixtureTests;

        public ClienteBogusTests(ClienteBogusFixtureTests clienteFixtureTests)
        {
            _clienteBogusFixtureTests = clienteFixtureTests;
        }

        [Fact(DisplayName = "Novo Cliente Válido")]
        [Trait("Categoria","Cliente Bogus Testes")]
        public void Cliene_NovoCliente_DeveEstarValido()
        {
            // Arrange
            var cliente = _clienteBogusFixtureTests.GerarClienteValido();

            // Act
            var result = cliente.EhValido();

            // Assert
            Assert.True(result);
            Assert.Equal(0, cliente.ValidationResult.Errors.Count);
        }

        [Fact(DisplayName = "Novo Cliente invalido")]
        [Trait("Categoria", "Cliente Bogus Testes")]
        public void Cliene_NovoCliente_DeveEstarInvalido()
        {
            // Arrange
            var cliente = _clienteBogusFixtureTests.GerarClienteInvalido();

            // Act
            var result = cliente.EhValido();

            // Assert
            Assert.False(result);
            Assert.NotEqual(0, cliente.ValidationResult.Errors.Count);
        }


    }
}
