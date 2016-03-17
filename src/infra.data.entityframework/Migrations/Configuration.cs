using System;
using System.Linq;
using br.com.klinderrh.social.dominio.entidades;

namespace br.com.klinderrh.social.infra.data.entityframework.Migrations
{
	using System.Data.Entity.Migrations;

	internal sealed class Configuration :
		DbMigrationsConfiguration<br.com.klinderrh.social.infra.data.entityframework.Contexto>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(br.com.klinderrh.social.infra.data.entityframework.Contexto context)
		{
			var usuario = new Usuario("Wilson", "juninhoroseira@gmail.com");

			usuario.AtribuirSenha("123456", "123456");

			context.Usuarios.Add(usuario);

			context.Estados.AddOrUpdate(
				new Estado("Acre", "AC"),
				new Estado("Alagoas", "AL"),
				new Estado("Amap�", "AP"),
				new Estado("Amazonas", "AM"),
				new Estado("Bahia", "BA"),
				new Estado("Cear�", "CE"),
				new Estado("Distrito Federal", "DF"),
				new Estado("Esp�rito Santo", "ES"),
				new Estado("Goi�s", "GO"),
				new Estado("Maranh�o", "MA"),
				new Estado("Mato Grosso", "MT"),
				new Estado("Mato Grosso do Sul", "MS"),
				new Estado("Minas Gerais", "MG"),
				new Estado("Par�", "PA"),
				new Estado("Para�ba", "PB"),
				new Estado("Paran�", "PR"),
				new Estado("Pernambuco", "PE"),
				new Estado("Piau�", "PI"),
				new Estado("Rio de Janeiro", "RJ"),
				new Estado("Rio Grande do Norte", "RN"),
				new Estado("Rio Grande do Sul", "RS"),
				new Estado("Rond�nia", "RO"),
				new Estado("Roraima", "RR"),
				new Estado("Santa Catarina", "SC"),
				new Estado("S�o Paulo", "SP"),
				new Estado("Sergipe", "SE"),
				new Estado("Tocantins", "TO"));

			context.SaveChanges();

			var estado = context.Estados.FirstOrDefault(e => e.UnidadeFederativa == "SP");

			if (estado != null)
			{
				context.Cidades.Add(new Cidade("Campinas", "CPS", estado.Codigo));
				context.Cidades.Add(new Cidade("S�o Paulo", "SPA", estado.Codigo));
			}

			estado = context.Estados.FirstOrDefault(e => e.UnidadeFederativa == "RJ");

			if (estado != null)
			{
				context.Cidades.Add(new Cidade("Rio de Janeiro", "RJN", estado.Codigo));
				context.Cidades.Add(new Cidade("Paraty", "PAR", estado.Codigo));
			}

			context.SaveChanges();

			context.Empresas.Add(new Empresa("Klinder RH", "Klinder RH", "132456", "987654")
			{
				DataDeAdesao = DateTime.Now
			});

			context.SaveChanges();

			context.Departamentos.Add(new Departamento("Presid�ncia")
			{
				Descricao = "Presid�ncia",
				Sigla = "PRES"
			});

			context.SaveChanges();

			context.Cargos.Add(new Cargo("Diretor Presidente", "DIRPRES", "Diretor Presidente"));

			context.SaveChanges();

		}

	}

}