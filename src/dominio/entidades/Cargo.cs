﻿using System;
using br.com.klinderrh.social.infra.comum;
using br.com.klinderrh.social.infra.recursos;

namespace br.com.klinderrh.social.dominio.entidades
{
	public class Cargo : EntidadeBase
	{
		protected Cargo() { }

		public Cargo(string nome, string sigla, string descricao)
		{
			AlterarDados(nome, sigla, descricao);
		}

		public string Nome { get; private set; }
		public string Sigla { get; private set; }
		public string Descricao { get; private set; }

		public void AlterarDados(string nome, string sigla, string descricao)
		{
			Nome = nome;
			Sigla = sigla;
			Descricao = descricao;

			Validar();

		}

		private void Validar()
		{
			Assertions<NullReferenceException>.IsNotNullOrEmpty(Nome, string.Format(Messages.NotBeEmpty, "Nome"));
			Assertions<NullReferenceException>.IsNotNullOrEmpty(Sigla, string.Format(Messages.NotBeEmpty, "Sigla"));
			Assertions<NullReferenceException>.IsNotNullOrEmpty(Descricao, string.Format(Messages.NotBeEmpty, "Descricao"));
		}

	}

}