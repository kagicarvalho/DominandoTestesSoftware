using Features.Clientes;
using Features.Tests.DadosHumanos;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Features.Tests.Mock
{
    [Collection(nameof(ClienteBogusCollection))]
    public class ClienteServiceTests
    {
        private readonly ClienteBogusFixtureTests _clienteBogusFixtureTests;

        public ClienteServiceTests(ClienteBogusFixtureTests clienteBogusFixtureTests)
        {
            _clienteBogusFixtureTests = clienteBogusFixtureTests;
        }

        [Fact(DisplayName = "Adicionar Cliente com Sucesso")]
        [Trait("Categoria", "Cliente Service Mock Tests")]
        public void ClienteService_Adicionar_DeveExecutarComSucesso()
        {
            //  Arrange
            var cliente = _clienteBogusFixtureTests.GerarClienteValido();
            var clienteRepository = new Mock<IClienteRepository>();
            var mediatr = new Mock<IMediator>();

            var clienteService = new ClienteService(clienteRepository.Object, mediatr.Object);


            // Act
            clienteService.Adicionar(cliente);


            // Assert
            Assert.True(cliente.EhValido());
            clienteRepository.Verify(expression: r => r.Adicionar(cliente), Times.Once);
            mediatr.Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);
        }

        [Fact(DisplayName = "Adicionar Cliente com Falha")]
        [Trait("Categoria", "Cliente Service Mock Tests")]
        public void ClienteService_Adicionar_DeveFalharDevidoClienteInvalido()
        {

            //  Arrange
            var cliente = _clienteBogusFixtureTests.GerarClienteInvalido();
            var clienteRepository = new Mock<IClienteRepository>();
            var mediatr = new Mock<IMediator>();

            var clienteService = new ClienteService(clienteRepository.Object, mediatr.Object);


            // Act
            clienteService.Adicionar(cliente);


            // Assert
            Assert.False(cliente.EhValido());
            clienteRepository.Verify(expression: r => r.Adicionar(cliente), Times.Never);
            mediatr.Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Never);
        }

        [Fact(DisplayName = "Obter Clientes Ativos")]
        [Trait("Categoria", "Cliente Service Mock Tests")]
        public void ClienteService_ObterTodosAtivos_DeveRetornarApenasClientesAtivos()
        {
            // Arrange
            var clienteRepository = new Mock<IClienteRepository>();
            var mediatr = new Mock<IMediator>();

            clienteRepository.Setup(c => c.ObterTodos()).Returns(_clienteBogusFixtureTests.ObterClientesVariados());

            var clienteService = new ClienteService(clienteRepository: clienteRepository.Object,mediator: mediatr.Object);

            // Act
            var clientes = clienteService.ObterTodosAtivos();


            // Assert
            clienteRepository.Verify(expression: r => r.ObterTodos(), Times.Once);
            Assert.True(condition: clientes.Any());
            Assert.False(clientes.Count(predicate: c => !c.Ativo) > 0);

        }
    }
}
