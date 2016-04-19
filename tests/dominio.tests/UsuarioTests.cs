using KlinderRH.Social.Dominio.Entidades;
using NUnit.Framework;

namespace  KlinderRH.Social.Dominio.Tests
{
	[TestFixture]
	public class UsuarioTests
	{

		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void DeveCriarUsuarioValido()
		{
			var usuario = new Usuario("wilson", "juninhoroseira@gmail.com");

			usuario.AtribuirSenha("123456", "123456");
			usuario.Validar();

		}

	}

}