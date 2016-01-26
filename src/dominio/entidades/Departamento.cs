using System;
using System.Collections.Generic;

namespace br.com.klinderrh.social.dominio.entidades
{
	public class Departamento : EntidadeBase
	{

		protected Departamento()
		{
			DepartamentosFilho = new List<Departamento>();
		}

		public string Sigla { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }

		public int? CodigoDoDepartamentoPai { get; set; }
		public virtual Departamento DepartamentoPai { get; set; }

		public virtual ICollection<Departamento> DepartamentosFilho { get; set; }

	}

}