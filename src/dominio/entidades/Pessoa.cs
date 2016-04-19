using System;
using System.Collections.Generic;

namespace KlinderRH.Social.Dominio.Entidades
{
	public class Pessoa : EntidadeBase
	{
		protected Pessoa()
		{
			Contatos = new List<Contato>();
			Enderecos = new List<Endereco>();
		}

		public Pessoa(string nome, string rg, string cpf, DateTime dataDeNascimento) : this()
		{
			Nome = nome;
			RG = rg;
			CPF = cpf;
			DataDeNascimento = dataDeNascimento;
		}

		public string Nome { get; private set; }
		public string RG { get; private set; }
		public string CPF { get; private set; }
		public DateTime DataDeNascimento { get; private set; }

		public Guid? UsuarioId { get; set; }
		public Usuario Usuario { get; set; }

		public ICollection<Contato> Contatos { get; set; }
		public ICollection<Endereco> Enderecos { get; set; }

	}

}