namespace br.com.klinderrh.social.dominio.entidades
{
	public class Cidade : EntidadeBase
	{
		protected Cidade() { }

		public Cidade(string nome, string sigla, int codigoDoEstado) : this()
		{
			Nome = nome;
			Sigla = sigla;
			CodigoDoEstado = codigoDoEstado;
		}

		public string Nome { get; private set; }
		public string Sigla { get; private set; }

		public int CodigoDoEstado  { get; private set; }
		public virtual Estado Estado { get; set; }

	}

}