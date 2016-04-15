using System;
using Newtonsoft.Json;

namespace br.com.klinderrh.social.dominio.entidades
{
	public class EntidadeBase
	{
		protected EntidadeBase() : this(Guid.NewGuid()) { }

		public EntidadeBase(Guid id)
		{
			Id = id;
			DataDeCadastro = DateTime.Now;
			Ativo = true;
		}

		public Guid Id { get; private set; }
		public DateTime DataDeCadastro { get; private set; }
		public bool Ativo { get; set; }

		public string ToJson()
		{
			return JsonConvert.SerializeObject(this);
		}

	}

}