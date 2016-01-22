using br.com.klinderrh.social.dominio.entidades;
using NUnit.Framework;

namespace br.com.klinderrh.social.dominio.tests
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