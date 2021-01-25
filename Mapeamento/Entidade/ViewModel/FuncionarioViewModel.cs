using System;
using System.Collections.Generic;
using System.Text;

namespace Mapeamento.Entidade.ViewModel
{
    public class FuncionarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public EnderecoViewModel Endereco { get; set; }
        public List<TelefoneViewModel> Telefone { get; set; }
        public string CPF { get; set; }
        public string Funcional { get; set; }
        public decimal Salario { get; set; }
        public string Departamento { get; set; }
    }

    public class EnderecoViewModel
    {
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
    }

    public class TelefoneViewModel
    {
        public int DDD { get; set; }
        public int Numero { get; set; }
    }
}
