using System;
using br.com.klinderrh.social.dominio.entidades;
using NUnit.Framework;

namespace br.com.klinderrh.social.dominio.tests
{
	[TestFixture]
	public class EntidadeBaseTests
	{
		[SetUp]
		public void Setup()
		{
			
		}

		[Test]
		public void DeveRetornarObjetoJSON()
		{
			var entidadeBase = new EntidadeBase(Guid.NewGuid());

			var valorDoObjeto = entidadeBase.ToJson();

			Assert.IsNotEmpty(valorDoObjeto);

			Console.WriteLine(valorDoObjeto);

		}

	}

}