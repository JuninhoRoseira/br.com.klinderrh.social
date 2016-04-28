using System;
using System.Data.Entity.Migrations;
using System.Linq;
using KlinderRH.Social.Dominio.Entidades;
using KlinderRH.Social.Dominio.ObjetosDeValor;
using Microsoft.AspNet.Identity;

namespace KlinderRH.Social.Infra.Data.EntityFramework.Migrations
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

			// Roles
			context.AppRoleManager.CreateRole("Administradores");
			context.AppRoleManager.CreateRole("Usuarios");

			// Users
			context.AppUserManager.CreateUser("juninhoroseira@gmail.com", "Wilson José Pinto Júnior", "juninhoroseira", "Teste@123");

			var user = context.Users.FirstOrDefault(u => u.UserName == "juninhoroseira");

			if (user != null)
			{
				context.AppUserManager.AddToRoles(user.Id, new[] {"Administradores", "Usuarios"});
			}

			// Países
			context.Paises.AddOrUpdate(
				new Pais("Brasil"),
				new Pais("Argentina"),
				new Pais("Estados Unidos da América"));

			context.SaveChanges();

			var brasil = context.Paises.FirstOrDefault(p => p.Nome == "Brasil");
			
			context.Estados.AddOrUpdate(
				new Estado("Acre", "AC", brasil.Id),
				new Estado("Alagoas", "AL", brasil.Id),
				new Estado("Amapá", "AP", brasil.Id),
				new Estado("Amazonas", "AM", brasil.Id),
				new Estado("Bahia", "BA", brasil.Id),
				new Estado("Ceará", "CE", brasil.Id),
				new Estado("Distrito Federal", "DF", brasil.Id),
				new Estado("Espírito Santo", "ES", brasil.Id),
				new Estado("Goiás", "GO", brasil.Id),
				new Estado("Maranhão", "MA", brasil.Id),
				new Estado("Mato Grosso", "MT", brasil.Id),
				new Estado("Mato Grosso do Sul", "MS", brasil.Id),
				new Estado("Minas Gerais", "MG", brasil.Id),
				new Estado("Pará", "PA", brasil.Id),
				new Estado("Paraíba", "PB", brasil.Id),
				new Estado("Paraná", "PR", brasil.Id),
				new Estado("Pernambuco", "PE", brasil.Id),
				new Estado("Piauí", "PI", brasil.Id),
				new Estado("Rio de Janeiro", "RJ", brasil.Id),
				new Estado("Rio Grande do Norte", "RN", brasil.Id),
				new Estado("Rio Grande do Sul", "RS", brasil.Id),
				new Estado("Rondônia", "RO", brasil.Id),
				new Estado("Roraima", "RR", brasil.Id),
				new Estado("Santa Catarina", "SC", brasil.Id),
				new Estado("São Paulo", "SP", brasil.Id),
				new Estado("Sergipe", "SE", brasil.Id),
				new Estado("Tocantins", "TO", brasil.Id));

			context.SaveChanges();

			var estado = context.Estados.FirstOrDefault(e => e.UnidadeFederativa == "SP");

			if (estado != null)
			{
				context.Cidades.Add(new Cidade("Campinas", "CPS", estado.Id));
				context.Cidades.Add(new Cidade("São Paulo", "SPA", estado.Id));
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

			context.Departamentos.Add(new Departamento("Presidência", "PRES", "Presidência", unidade.Id, null));

			context.SaveChanges();

			context.Cargos.Add(new Cargo("Diretor Presidente", "DIRPRES", "Diretor Presidente", NivelDoCargo.Diretor));

			context.SaveChanges();

		}
		
	}

}