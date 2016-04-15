using System;
using System.IO;
using br.com.klinderrh.social.infra.comum;
using br.com.klinderrh.social.infra.recursos;
using br.com.klinderrh.social.infra.seguranca;

namespace br.com.klinderrh.social.dominio.entidades
{
	public class Usuario : EntidadeBase
	{
		protected Usuario() { }

		public Usuario(string nome, string email) : this()
		{
			Nome = nome;
			Email = email;
			Senha = string.Empty;
		}

		public Usuario(Guid id, string nome, string email) : base(id)
		{
			Nome = nome;
			Email = email;
			Senha = string.Empty;
		}

		public string Nome { get; private set; }
		public string Email { get; private set; }
		public bool EmailConfirmado { get; set; }
		public string Senha { get; private set; }
		public bool Valido { get; set; }

		public void Validar()
		{
			Assertions<NullReferenceException>.IsNotNullOrEmpty(Nome, string.Format(Messages.NotBeEmpty, "Nome"));
			Assertions<InvalidDataException>.IsValidEmail(Email, string.Format(Messages.IsInvalid, "Email"));
			Assertions<NullReferenceException>.IsNotNullOrEmpty(Senha, string.Format(Messages.NotBeEmpty, "Senha"));
		}

		public void CriarNovaSenha()
		{
			Senha = "123456";
		}

		public string AtribuirSenha(string senha, string confirmacaoDaSenha)
		{
			Assertions<NullReferenceException>.IsNotNullOrEmpty(senha, string.Format(Messages.NotBeEmpty, "Senha"));
			Assertions<NullReferenceException>.IsGreaterOrEquasTo(senha.Trim().Length, 6, string.Format(Messages.NotGreaterOrEqualTo, "Senha", "6"));
			Assertions<NullReferenceException>.IsNotNullOrEmpty(confirmacaoDaSenha, string.Format(Messages.NotBeEmpty, "ConfirmacaoDaSenha"));
			Assertions<InvalidDataException>.AreEqual(senha, confirmacaoDaSenha, string.Format(Messages.AreNotEquals, "Senhas"));

			var senhaCriptografada = Criptografia.CriarHash(senha);

			Senha = senhaCriptografada;

			return senhaCriptografada;

		}

		public void VerificarSenha(string senha)
		{
			Assertions<NullReferenceException>.IsNotNullOrEmpty(senha, string.Format(Messages.NotBeEmpty, "Senha"));

			var valid = Criptografia.ValidarSenha(senha, Senha);

			Assertions<InvalidDataException>.IsTrue(valid, "Senha nválida.");

		}

		public void AlterarDados(string novoNome, string novoEmail)
		{
			Assertions<NullReferenceException>.IsNotNullOrEmpty(novoNome, string.Format(Messages.NotBeEmpty, "novoNome"));
			Assertions<InvalidDataException>.IsValidEmail(novoEmail, string.Format(Messages.IsInvalid, "novoEmail"));

			Nome = novoNome;
			Email = novoEmail;

		}

	}

}