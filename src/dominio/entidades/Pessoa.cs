using System;
using System.Collections.Generic;

namespace br.com.klinderrh.social.dominio.entidades
{
	public class Pessoa : EntidadeBase

	{
		protected Pessoa()
		{
			Contatos = new List<Contato>();
			Enderecos = new List<Endereco>();
		}

		public string Nome { get; set; }
		public string RG { get; set; }
		public string CPF { get; set; }
		public DateTime DataDeNascimento { get; set; }

		public int? CodigoDoUsuario { get; set; }
		public Usuario Usuario { get; set; }

		public ICollection<Contato> Contatos { get; set; }
		public ICollection<Endereco> Enderecos { get; set; }

	}

}