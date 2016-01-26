using System.Collections.Generic;

namespace br.com.klinderrh.social.dominio.entidades
{
	public class Cargo : EntidadeBase
	{
		protected Cargo() { }

		public Cargo(string nome)
		{
			Nome = Nome;
		}

		public string Nome { get; private set; }
		public string Sigla { get; set; }
		public string Descricao { get; set; }

	}

}