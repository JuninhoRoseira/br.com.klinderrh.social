using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.klinderrh.social.dominio.entidades
{
	public class Empresa : EntidadeBase
	{
		protected Empresa()
		{
			Enderecos = new List<Endereco>();
			Contatos = new List<Contato>();
		}

		public Empresa(string nome, string documento, string inscricao) : this()
		{
			Nome = nome;
			Documento = documento;
			Inscricao = inscricao;
		}

		public string Nome { get; }
		public string Documento { get; }
		public string Inscricao { get; }
		public DateTime DataDeAdesao { get; set; }
		public ICollection<Endereco> Enderecos { get; set; }
		public ICollection<Contato> Contatos { get; set; }

	}

}