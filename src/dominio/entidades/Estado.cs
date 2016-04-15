using System;
using System.Collections.Generic;

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

		public Estado(string nome, string unidadeFederativa, Guid? paisId) : this(nome, unidadeFederativa)
		{
			PaisId = paisId;
		}

		public string Nome { get; private set; }
		public string UnidadeFederativa { get; private set; }
		public Guid? PaisId { get; private set; }
		public virtual Pais Pais { get; set; }

		public virtual ICollection<Cidade> Cidades { get; set; }

	}

}