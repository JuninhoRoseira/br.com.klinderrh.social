using System;

namespace KlinderRH.Social.Dominio.Entidades
{
	public class Cidade : EntidadeBase
	{
		protected Cidade() { }

		public Cidade(string nome, string sigla, Guid estadoId) : this()
		{
			Nome = nome;
			Sigla = sigla;
			EstadoId = estadoId;
		}

		public string Nome { get; private set; }
		public string Sigla { get; private set; }
		public Guid EstadoId  { get; private set; }
		public virtual Estado Estado { get; set; }

	}

}