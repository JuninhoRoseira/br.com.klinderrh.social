using System.Collections.Generic;

namespace br.com.klinderrh.social.dominio.entidades
{
	public class Pais : EntidadeBase
	{
		protected Pais()
		{
			Estados = new List<Estado>();
		}

		public Pais(string nome)
		{
			Nome = nome;
		}

		public string Nome { get; private set; }
		public virtual ICollection<Estado> Estados { get; set; }

	}

}