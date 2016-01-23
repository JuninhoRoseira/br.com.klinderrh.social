using System.Collections.Generic;

namespace br.com.klinderrh.social.dominio.entidades
{
	public class Departamento : EntidadeBase
	{
		protected Departamento()
		{
			
		}
		public string Sigla { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }

		public Departamento AreaPai { get; set; }

		public ICollection<Departamento> AreasFilho { get; set; }

	}
}