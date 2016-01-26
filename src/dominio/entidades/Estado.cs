using System.Collections.Generic;
using br.com.klinderrh.social.dominio.objetosdevalor;

namespace br.com.klinderrh.social.dominio.entidades
{
	public class Estado : EntidadeBase
	{
		protected Estado()
		{
			Cidades = new List<Cidade>();
		}

		public Estado(string nome, string unidadeFederativa) : this(nome, unidadeFederativa, Paises.Brasil) { }

		public Estado(string nome, string unidadeFederativa, string pais) : this()
		{
			Nome = nome;
			UnidadeFederativa = unidadeFederativa;
			Pais = pais;
		}

		public string Nome { get; private set; }
		public string UnidadeFederativa { get; private set; }
		public string Pais { get; private set; }

		public virtual ICollection<Cidade> Cidades { get; set; }

	}

}