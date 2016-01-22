namespace br.com.klinderrh.social.dominio.entidades
{
	public class Cidade : EntidadeBase
	{
		protected Cidade() { }

		public Cidade(string nome, string sigla, Estado estado) : this()
		{
			Nome = nome;
			Sigla = sigla;
			Estado = estado;
		}

		public string Nome { get; }
		public string Sigla { get; }
		public Estado Estado { get; }

	}

}