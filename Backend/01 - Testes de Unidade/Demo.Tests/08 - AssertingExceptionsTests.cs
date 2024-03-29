﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.Tests
{
    public class AssertingExceptionsTests
    {
        [Fact(DisplayName = "Verifica o retorno ao dividir por zero")]
        [Trait("Categoria", "Teste Assert Exceptions")]
        public void Calculadora_Dividir_DeveRetornarErroDivisaoPorZero()
        {
            // Arrange
            var calculadora = new Calculadora();

            // Act & Assert
            Assert.Throws<DivideByZeroException>(() => calculadora.Dividir(10, 0));
        }

        [Fact(DisplayName = "Verifica se salario é inferio ao permitido")]
        [Trait("Categoria", "Teste Assert Exceptions")]
        public void Funcionario_Salario_DeveRetornarErroSalarioInferiorPermitido()
        {
            // Arrange & Act & Assert
            var exception = Assert.Throws<Exception>(() => FuncionarioFactory.Criar("Kagi", 250));

            Assert.Equal("Salario inferior ao permitido", exception.Message);
        }
    }
}
