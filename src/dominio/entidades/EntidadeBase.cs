﻿using System;
using Newtonsoft.Json;

namespace br.com.klinderrh.social.dominio.entidades
{
	public class EntidadeBase
	{
		protected EntidadeBase() : this(0) { }

		public EntidadeBase(int codigo)
		{
			Codigo = codigo;
			DataDeCadastro = DateTime.Now;
			Ativo = true;
		}

		public int Codigo { get; }
		public DateTime DataDeCadastro { get; }
		public bool Ativo { get; set; }

		public string ToJson()
		{
			return JsonConvert.SerializeObject(this);
		}

	}

}