using Features.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Features.Tests.Traits
{
    public class ClienteTests
    {
        [Fact(DisplayName ="Novo cliente valido")]
        [Trait("Categoria", "Cliente Trait Testes")]
        public void Cliente_NovoCliente_DeveEstarValido()
        {
            // Arrange 
            var cliente = new Cliente(
                    Guid.NewGuid(),
                    "Kagi",
                    "Carvalho",
                    DateTime.Now.AddYears(-27),
                    DateTime.Now,
                    "kagi@gmail.com",
                    true);

            // Act
            var result = cliente.EhValido();

            // Assert
            Assert.True(result);
            Assert.Equal(0, cliente.ValidationResult.Errors.Count);
        }

        [Fact(DisplayName = "Novo cliente invalido")]
        [Trait("Categoria", "Cliente Trait Testes")]
        public void Cliente_NovoCliente_DeveEstarInalido()
        {
            // Arrange 
            var cliente = new Cliente(
                    Guid.NewGuid(),
                    "",
                    "",
                    DateTime.Now,
                    DateTime.Now,
                    "kagi3gmail.com",
                    true);

            // Act
            var result = cliente.EhValido();

            // Assert
            Assert.False(result);
            Assert.NotEqual(0, cliente.ValidationResult.Errors.Count);
        }
    }
}
