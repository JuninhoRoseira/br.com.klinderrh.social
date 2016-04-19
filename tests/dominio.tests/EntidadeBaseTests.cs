using System;
using KlinderRH.Social.Dominio.Entidades;
using NUnit.Framework;

namespace  KlinderRH.Social.Dominio.Tests
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