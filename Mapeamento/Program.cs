using AutoMapper;
using Bogus;
using Mapeamento.Entidade;
using Mapeamento.Entidade.ViewModel;
using System;
using Bogus.Extensions.Brazil;
using System.Collections.Generic;
using System.Diagnostics;

namespace Mapeamento
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Funcionario, FuncionarioViewModel>();
                cfg.CreateMap<Endereco, EnderecoViewModel>();
                cfg.CreateMap<Telefone, TelefoneViewModel>();
            });

            var mapper = configuration.CreateMapper();
            var funcionario = CriarFuncionarioFaker();

            var stopwatchAutoMapper = new Stopwatch();
            var stopwatchMap = new Stopwatch();
            stopwatchAutoMapper.Start();
            var funcionarioViewModel = mapper.Map<FuncionarioViewModel>(funcionario);
            stopwatchAutoMapper.Stop();
            Console.WriteLine("AutoMapper: {0}", stopwatchAutoMapper.Elapsed);

            stopwatchMap.Start();
            Map(funcionario);
            stopwatchMap.Stop();
            Console.WriteLine("Map: {0}", stopwatchMap.Elapsed);

            Console.WriteLine($"Diferença: {stopwatchAutoMapper.Elapsed - stopwatchMap.Elapsed}");


            Console.ReadKey();
        }

        static FuncionarioViewModel Map(Funcionario obj)
        {
            var funcionario = new FuncionarioViewModel()
            {
                Id = obj.Id,
                Nome = obj.Nome,
                CPF = obj.CPF,
                Departamento = obj.Departamento,
                Endereco = new EnderecoViewModel()
                {
                    Logradouro = obj.Endereco.Logradouro,
                    Bairro = obj.Endereco.Bairro,
                    CEP = obj.Endereco.CEP,
                    Numero = obj.Endereco.Numero
                },
                Funcional = obj.Funcional,
                Salario = obj.Salario
            };

            foreach (var item in obj.Telefone)
            {
                funcionario.Telefone = new List<TelefoneViewModel>();
                funcionario.Telefone.Add(new TelefoneViewModel()
                {
                    DDD = item.DDD,
                    Numero = item.Numero
                });
            }

            return funcionario;
        }

        static Funcionario CriarFuncionarioFaker()
        {
            var funcionario = new Faker<Funcionario>("pt_BR")
                .StrictMode(true)
                .RuleFor(c => c.Id, f => f.Random.Int(1, 1000))
                .RuleFor(c => c.Nome, f => f.Person.FullName)
                .RuleFor(c => c.CPF, f => f.Person.Cpf())
                .RuleFor(c => c.Departamento, f => f.Commerce.Department())
                .RuleFor(c => c.Funcional, f => f.Commerce.ProductName())
                .RuleFor(c => c.Salario, f => f.Random.Decimal())
                .RuleFor(c => c.Endereco, CriarEnderecoFaker())
                .RuleFor(c => c.Telefone, CriarTelefoneFaker())
                .Generate();

            return funcionario;
        }

        static Endereco CriarEnderecoFaker()
        {
            var endereco = new Faker<Endereco>("pt_BR")
                .StrictMode(true)
                .RuleFor(c => c.Logradouro, f => f.Address.StreetAddress())
                .RuleFor(c => c.Numero, f => f.Random.Int(1, 1000))
                .RuleFor(c => c.Bairro, f => f.Address.Direction())
                .RuleFor(c => c.CEP, f => f.Address.ZipCode())
                .Generate();

            return endereco;
        }

        static IEnumerable<Telefone> CriarTelefoneFaker()
        {
            var telefone = new Faker<Telefone>("pt_BR")
                .StrictMode(true)
                .RuleFor(c => c.DDD, f => f.Random.Int(1, 99))
                .RuleFor(c => c.Numero, f => f.Random.Int(1, 1000000))
                .Generate(10);

            return telefone;
        }
    }
}
