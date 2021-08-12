using Bogus;
using Bogus.DataSets;
using Features.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Features.Tests.DadosHumanos
{
    [CollectionDefinition(nameof(ClienteBogusCollection))]
    public class ClienteBogusCollection : ICollectionFixture<ClienteBogusFixtureTests>
    {

    }

    public class ClienteBogusFixtureTests : IDisposable
    {
        //public Cliente GerarClienteValido()
        //{
        //    var genero = new Faker().PickRandom<Name.Gender>();
        //var email = new Faker().Internet.Email();
        //var clientefaker = new Faker<Cliente>();
        //clientefaker.RuleFor(c => c.Nome, (f, c) => f.Name.FirstName());
        //
        //    var cliente = new Faker<Cliente>(locale: "pt_BR").CustomInstantiator(f => new Cliente(
        //            Guid.NewGuid(),
        //            nome: f.Name.FirstName(genero),
        //            sobrenome: f.Name.LastName(genero),
        //            dataNascimento: f.Date.Past(yearsToGoBack: 80, DateTime.Now.AddYears(-18)),
        //            dataCadastro: DateTime.Now,
        //            email: "",
        //            ativo: true))
        //        .RuleFor(property: c => c.Email, setter: (f, c) => f.Internet.Email(firstName: c.Nome.ToLower(), lastName: c.Sobrenome.ToLower()));

        //    return cliente;
        //}

        public Cliente GerarClienteValido()
        {
            return GerarListaCliente(1, true).FirstOrDefault();
        }

        public IEnumerable<Cliente> ObterClientesVariados()
        {
            var clientes = new List<Cliente>();

            clientes.AddRange(GerarListaCliente(50, true).ToList());
            clientes.AddRange(GerarListaCliente(50, false).ToList());

            return clientes;
        }


        public Cliente GerarClienteInvalido()
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var cliente = new Faker<Cliente>(locale: "pt_BR").CustomInstantiator(f => new Cliente(
                    Guid.NewGuid(),
                    nome: f.Name.FirstName(genero),
                    sobrenome: f.Name.LastName(genero),
                    dataNascimento: f.Date.Past(yearsToGoBack: 1, DateTime.Now.AddYears(1)),
                    dataCadastro: DateTime.Now,
                    email: "",
                    ativo: false));

            return cliente;
        }

        public IEnumerable<Cliente> GerarListaCliente(int quantidade, bool status)
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var cliente = new Faker<Cliente>(locale: "pt_BR").CustomInstantiator(f => new Cliente(
                    Guid.NewGuid(),
                    nome: f.Name.FirstName(genero),
                    sobrenome: f.Name.LastName(genero),
                    dataNascimento: f.Date.Past(yearsToGoBack: 80, DateTime.Now.AddYears(-18)),
                    dataCadastro: DateTime.Now,
                    email: "",
                    ativo: status))
                .RuleFor(property: c => c.Email, setter: (f, c) => f.Internet.Email(firstName: c.Nome.ToLower(), lastName: c.Sobrenome.ToLower()));

            return cliente.Generate(quantidade);
        }

        public void Dispose()
        {
        }
    }
}
