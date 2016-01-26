using System;
using System.Collections.Generic;

namespace br.com.klinderrh.social.dominio.entidades
{
	public class Empresa : EntidadeBase
	{
		protected Empresa()
		{
			Enderecos = new List<Endereco>();
			Contatos = new List<Pessoa>();
			Funcionarios = new List<Funcionario>();
		}

		public Empresa(string razaoSocial, string nomeFantasia, string documento, string inscricao) : this()
		{
			RazaoSocial = razaoSocial;
			NomeFantasia = nomeFantasia;
			CNPJ = documento;
			IE = inscricao;
		}

		public string RazaoSocial { get; private set; }
		public string NomeFantasia { get; private set; }
		public string CNPJ { get; private set; }
		public string IE { get; private set; }
		public DateTime DataDeAdesao { get; set; }

		public ICollection<Endereco> Enderecos { get; set; }
		public ICollection<Pessoa> Contatos { get; set; }
		public virtual ICollection<Funcionario> Funcionarios { get; set; }

	}

}