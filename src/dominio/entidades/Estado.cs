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

		public Estado(string nome, string unidadeFederativa) : this()
		{
			Nome = nome;
			UnidadeFederativa = unidadeFederativa;
		}

		public Estado(string nome, string unidadeFederativa, Pais pais) : this(nome, unidadeFederativa)
		{
			Pais = pais;
		}

		public string Nome { get; private set; }
		public string UnidadeFederativa { get; private set; }
		public int? CodigoDoPais { get; set; }
		public virtual Pais Pais { get; private set; }

		public virtual ICollection<Cidade> Cidades { get; set; }

	}

}