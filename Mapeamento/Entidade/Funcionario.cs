using System;
using System.Collections.Generic;
using System.Text;

namespace Mapeamento.Entidade
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public IEnumerable<Telefone> Telefone { get; set; }
        public string CPF { get; set; }
        public string Funcional { get; set; }
        public decimal Salario { get; set; }
        public string Departamento { get; set; }

    }

    public class Endereco
    {
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
    }

    public class Telefone
    {
        public int DDD { get; set; }
        public int Numero { get; set; }
    }
}
