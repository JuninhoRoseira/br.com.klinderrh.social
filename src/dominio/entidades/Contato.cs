using System;
using System.Collections.Generic;
using br.com.klinderrh.social.infra.comum;
using br.com.klinderrh.social.infra.recursos;

namespace br.com.klinderrh.social.dominio.entidades
{
	public class Contato : EntidadeBase
	{
		protected Contato() { }

		public Contato(string telefone, string email) : this()
		{
			Telefone = telefone;
			Email = email;
		}

		public void Validar()
		{
			Assertions<NullReferenceException>.IsNotNullOrEmpty(Telefone, string.Format(Messages.NotBeEmpty, "Telefone"));
			Assertions<NullReferenceException>.IsNotNullOrEmpty(Email, string.Format(Messages.NotBeEmpty, "Email"));
		}

		public string Telefone { get; private set; }
		public string Email { get; private set; }

	}

}