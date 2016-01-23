using System;
using System.Collections.Generic;

namespace br.com.klinderrh.social.dominio.entidades
{
	public class Empresa : EntidadeBase
	{
		protected Empresa()
		{
			Enderecos = new List<Endereco>();
			PessoasDeContato = new List<Pessoa>();
			Colaboradores = new List<Colaborador>();
		}

		public Empresa(string razaoSocial, string nomeFantasia, string documento, string inscricao) : this()
		{
			RazaoSocial = razaoSocial;
			NomeFantasia = nomeFantasia;
			Documento = documento;
			Inscricao = inscricao;
		}

		public string RazaoSocial { get; private set; }
		public string NomeFantasia { get; private set; }
		public string Documento { get; private set; }
		public string Inscricao { get; private set; }
		public DateTime DataDeAdesao { get; set; }

		public ICollection<Endereco> Enderecos { get; set; }
		public ICollection<Pessoa> PessoasDeContato { get; set; }
		public ICollection<Colaborador> Colaboradores { get; set; }

	}

}