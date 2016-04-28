using System;
using KlinderRH.Core.Comum;
using KlinderRH.Social.Infra.Recursos;

namespace KlinderRH.Social.Dominio.Entidades
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