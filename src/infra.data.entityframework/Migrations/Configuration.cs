using System;
using System.Data.Entity.Migrations;
using System.Linq;
using br.com.klinderrh.social.dominio.entidades;
using br.com.klinderrh.social.dominio.objetosdevalor;

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

			context.Paises.AddOrUpdate(
				new Pais("Brasil"),
				new Pais("Argentina"),
				new Pais("Estados Unidos da Am�rica"));

			context.SaveChanges();

			var brasil = context.Paises.FirstOrDefault(p => p.Codigo == 1);
			
			context.Estados.AddOrUpdate(
				new Estado("Acre", "AC", brasil),
				new Estado("Alagoas", "AL", brasil),
				new Estado("Amap�", "AP", brasil),
				new Estado("Amazonas", "AM", brasil),
				new Estado("Bahia", "BA", brasil),
				new Estado("Cear�", "CE", brasil),
				new Estado("Distrito Federal", "DF", brasil),
				new Estado("Esp�rito Santo", "ES", brasil),
				new Estado("Goi�s", "GO", brasil),
				new Estado("Maranh�o", "MA", brasil),
				new Estado("Mato Grosso", "MT", brasil),
				new Estado("Mato Grosso do Sul", "MS", brasil),
				new Estado("Minas Gerais", "MG", brasil),
				new Estado("Par�", "PA", brasil),
				new Estado("Para�ba", "PB", brasil),
				new Estado("Paran�", "PR", brasil),
				new Estado("Pernambuco", "PE", brasil),
				new Estado("Piau�", "PI", brasil),
				new Estado("Rio de Janeiro", "RJ", brasil),
				new Estado("Rio Grande do Norte", "RN", brasil),
				new Estado("Rio Grande do Sul", "RS", brasil),
				new Estado("Rond�nia", "RO", brasil),
				new Estado("Roraima", "RR", brasil),
				new Estado("Santa Catarina", "SC", brasil),
				new Estado("S�o Paulo", "SP", brasil),
				new Estado("Sergipe", "SE", brasil),
				new Estado("Tocantins", "TO", brasil));

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

			var empresa = context.Empresas.FirstOrDefault(e => e.Codigo == 1);

			context.Unidades.Add(new Unidade("Klinder RH - Unidade I", "Klinder RH - Unidade I", "132456", "987654", empresa.Codigo));

			context.SaveChanges();

			var unidade = context.Unidades.FirstOrDefault(u => u.Codigo == 1);

			context.Departamentos.Add(new Departamento("Presid�ncia", "PRES", "Presid�ncia", unidade.Codigo, null));

			context.SaveChanges();

			context.Cargos.Add(new Cargo("Diretor Presidente", "DIRPRES", "Diretor Presidente", NivelDoCargo.Diretor));

			context.SaveChanges();

		}
		
	}

}