using System;
using System.Data.Entity.Migrations;
using System.Linq;
using br.com.klinderrh.social.dominio.entidades;
using br.com.klinderrh.social.dominio.objetosdevalor;
using br.com.klinderrh.social.infra.data.entityframework.identity;
using Microsoft.AspNet.Identity;

namespace br.com.klinderrh.social.infra.data.entityframework.Migrations
{
	internal sealed class Configuration : DbMigrationsConfiguration<Contexto>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}
		
		protected override void Seed(Contexto context)
		{

			context.Seed<TipoDeEndereco>();
			context.Seed<NivelDoCargo>();

			var usuario = new Usuario("Wilson", "juninhoroseira@gmail.com");

			usuario.AtribuirSenha("123456", "123456");

			context.Usuarios.Add(usuario);

			context.SaveChanges();

			var userManager = new ApplicationUserManager(new ApplicationUserStore(context));
			var result = userManager.Create(new ApplicationUser
			{
				Email = "juninhoroseira@gmail.com",
				Name = "Wilson Jos� Pinto J�nior",
				UserName = "juninhoroseira"
			}, "123456");

			Console.WriteLine("Usu�rio criado? {0}", result.Succeeded);
			
			context.Paises.AddOrUpdate(
				new Pais("Brasil"),
				new Pais("Argentina"),
				new Pais("Estados Unidos da Am�rica"));

			context.SaveChanges();

			var brasil = context.Paises.FirstOrDefault(p => p.Nome == "Brasil");
			
			context.Estados.AddOrUpdate(
				new Estado("Acre", "AC", brasil.Id),
				new Estado("Alagoas", "AL", brasil.Id),
				new Estado("Amap�", "AP", brasil.Id),
				new Estado("Amazonas", "AM", brasil.Id),
				new Estado("Bahia", "BA", brasil.Id),
				new Estado("Cear�", "CE", brasil.Id),
				new Estado("Distrito Federal", "DF", brasil.Id),
				new Estado("Esp�rito Santo", "ES", brasil.Id),
				new Estado("Goi�s", "GO", brasil.Id),
				new Estado("Maranh�o", "MA", brasil.Id),
				new Estado("Mato Grosso", "MT", brasil.Id),
				new Estado("Mato Grosso do Sul", "MS", brasil.Id),
				new Estado("Minas Gerais", "MG", brasil.Id),
				new Estado("Par�", "PA", brasil.Id),
				new Estado("Para�ba", "PB", brasil.Id),
				new Estado("Paran�", "PR", brasil.Id),
				new Estado("Pernambuco", "PE", brasil.Id),
				new Estado("Piau�", "PI", brasil.Id),
				new Estado("Rio de Janeiro", "RJ", brasil.Id),
				new Estado("Rio Grande do Norte", "RN", brasil.Id),
				new Estado("Rio Grande do Sul", "RS", brasil.Id),
				new Estado("Rond�nia", "RO", brasil.Id),
				new Estado("Roraima", "RR", brasil.Id),
				new Estado("Santa Catarina", "SC", brasil.Id),
				new Estado("S�o Paulo", "SP", brasil.Id),
				new Estado("Sergipe", "SE", brasil.Id),
				new Estado("Tocantins", "TO", brasil.Id));

			context.SaveChanges();

			var estado = context.Estados.FirstOrDefault(e => e.UnidadeFederativa == "SP");

			if (estado != null)
			{
				context.Cidades.Add(new Cidade("Campinas", "CPS", estado.Id));
				context.Cidades.Add(new Cidade("S�o Paulo", "SPA", estado.Id));
			}

			estado = context.Estados.FirstOrDefault(e => e.UnidadeFederativa == "RJ");

			if (estado != null)
			{
				context.Cidades.Add(new Cidade("Rio de Janeiro", "RJN", estado.Id));
				context.Cidades.Add(new Cidade("Paraty", "PAR", estado.Id));
			}

			context.SaveChanges();

			context.Empresas.Add(new Empresa("Klinder RH", "Klinder RH", "132456", "987654")
			{
				DataDeAdesao = DateTime.Now
			});

			context.SaveChanges();

			var empresa = context.Empresas.FirstOrDefault(e => e.RazaoSocial == "Klinder RH");

			context.Unidades.Add(new Unidade("Klinder RH - Unidade I", "Klinder RH - Unidade I", "132456", "987654", empresa.Id));

			context.SaveChanges();

			var unidade = context.Unidades.FirstOrDefault(u => u.RazaoSocial == "Klinder RH - Unidade I");

			context.Departamentos.Add(new Departamento("Presid�ncia", "PRES", "Presid�ncia", unidade.Id, null));

			context.SaveChanges();

			context.Cargos.Add(new Cargo("Diretor Presidente", "DIRPRES", "Diretor Presidente", NivelDoCargo.Diretor));

			context.SaveChanges();

		}
		
	}

}