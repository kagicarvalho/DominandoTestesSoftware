using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.Tests
{
    public class AssertingObjectTypesTestes
    {
        [Fact(DisplayName = "Verifica se o retorno é do tipo funcionario")]
        [Trait("Categoria", "Teste Assert Object Types")]
        public void FuncionarioFactory_Criar_DeveRetornarTipoFuncionario()
        {
            // Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Kagi", 10000);

            Assert.IsType<Funcionario>(funcionario);
        }

        [Fact(DisplayName = "Verifica se o retorno é do tipo é derivado/contém Pessoa")]
        [Trait("Categoria", "Teste Assert Object Types")]
        public void FuncionarioFactory_Criar_DeveRetornarTipoDerivadoPessoa()
        {
            // Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Kagi", 10000);

            // Assert
            Assert.IsAssignableFrom<Pessoa>(funcionario);
        }
    }
}
