using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.Tests
{
    public class AssertNullBoolTests
    {
        [Fact(DisplayName = "Verificar se eh null ou vazio ")]
        [Trait("Categoria", "Teste Assert Null Or Bool")]
        public void Funcionario_Nome_NaoDeveSerNuloOuVazio()
        {
            // Arrange & Act
            var funcionario = new Funcionario("", 1000);

            // Assert
            Assert.False(string.IsNullOrEmpty(funcionario.Nome));
        }

        [Fact(DisplayName = "Verificar se possui apelido")]
        [Trait("Categoria", "Teste Assert Null Or Bool")]
        public void Funcionario_Apelido_NaoDeveTerApelido()
        {
            // Arrange & Act
            var funcionario = new Funcionario("", 1000);

            // Assert
            Assert.Null(funcionario.Apelido);

            // Assert Bool
            Assert.True(string.IsNullOrEmpty(funcionario.Apelido));
            Assert.False(funcionario.Apelido?.Length > 0);
        }
    }
}
