using System;
using br.com.klinderrh.social.infra.comum;
using br.com.klinderrh.social.infra.recursos;

namespace br.com.klinderrh.social.dominio.entidades
{
	public class Contato : EntidadeBase
	{
		protected Contato() { }

		public Contato(string nome, string telefone, string email) : this()
		{
			Nome = nome;
			Telefone = telefone;
			Email = email;
		}

		public void Validar()
		{
			Assertions<NullReferenceException>.IsNotNullOrEmpty(Nome, string.Format(Messages.NotBeEmpty, "Nome"));
			Assertions<NullReferenceException>.IsNotNullOrEmpty(Telefone, string.Format(Messages.NotBeEmpty, "Telefone"));
			Assertions<NullReferenceException>.IsNotNullOrEmpty(Email, string.Format(Messages.NotBeEmpty, "Email"));
		}

		public string Nome { get; }
		public string Telefone { get; }
		public string Email { get; }

	}

}