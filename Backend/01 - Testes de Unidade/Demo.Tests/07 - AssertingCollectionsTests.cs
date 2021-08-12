using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.Tests
{
    public class AssertingCollectionsTests
    {
        [Fact(DisplayName = "Verifica se possui Habilidades")]
        [Trait("Categoria", "Teste Assert Collections")]
        public void Funcionario_Habilidades_NaoDevePossuirHabilidadesVazias()
        {
            // Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Kagi", 10000);

            // Assert
            Assert.All(funcionario.Habilidades, habilidades => Assert.False(string.IsNullOrEmpty(habilidades)));
        }

        [Fact(DisplayName = "Verifica se Junior possui habilidades basicas")]
        [Trait("Categoria", "Teste Assert Collections")]
        public void Funcionario_Habilidades_JuniorDevePossuirHabilidadeBasica()
        {
            // Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Kagi", 1000);

            // Assert
            Assert.Contains("OOP", funcionario.Habilidades);
        }

        [Fact(DisplayName = "Verifica se Junior possui habilidades avancadas")]
        [Trait("Categoria", "Teste Assert Collections")]
        public void Funcionario_Habilidades_JuniorNaoDevePossuirHabilidadeAvancada()
        {
            // Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Kagi", 1000);

            Assert.DoesNotContain("Microservices", funcionario.Habilidades);
        }

        [Fact(DisplayName = "Verifica se Senior possui todas as habilidades")]
        [Trait("Categoria", "Teste Assert Collections")]
        public void Funcionario_Habilidades_SenorDevePossuirTodasHabilidades()
        {
            // Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Eduardo", 15000);

            var HabilidadesBasicas = new[]
            {
                "Lógica de Programação",
                "OOP",
                "Testes",
                "Microservices"
            };

            // Assert
            Assert.Equal(HabilidadesBasicas, funcionario.Habilidades);
        }
    }
}
