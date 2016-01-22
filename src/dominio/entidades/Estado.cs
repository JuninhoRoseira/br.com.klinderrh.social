using br.com.klinderrh.social.dominio.objetosdevalor;

namespace br.com.klinderrh.social.dominio.entidades
{
	public class Estado : EntidadeBase
	{
		protected Estado() : this(Paises.Brasil) { }

		public Estado(string pais)
		{
			Pais = pais;
		}

		public Estado(string nome, string unidadeFederativa, string pais) : this(pais)
		{
			Nome = nome;
			UnidadeFederativa = unidadeFederativa;
		}

		public string Nome { get; }
		public string UnidadeFederativa { get; }
		public string Pais { get; }

	}

}