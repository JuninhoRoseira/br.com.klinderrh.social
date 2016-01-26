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
				new Estado("Amapá", "AP"),
				new Estado("Amazonas", "AM"),
				new Estado("Bahia", "BA"),
				new Estado("Ceará", "CE"),
				new Estado("Distrito Federal", "DF"),
				new Estado("Espírito Santo", "ES"),
				new Estado("Goiás", "GO"),
				new Estado("Maranhão", "MA"),
				new Estado("Mato Grosso", "MT"),
				new Estado("Mato Grosso do Sul", "MS"),
				new Estado("Minas Gerais", "MG"),
				new Estado("Pará", "PA"),
				new Estado("Paraíba", "PB"),
				new Estado("Paraná", "PR"),
				new Estado("Pernambuco", "PE"),
				new Estado("Piauí", "PI"),
				new Estado("Rio de Janeiro", "RJ"),
				new Estado("Rio Grande do Norte", "RN"),
				new Estado("Rio Grande do Sul", "RS"),
				new Estado("Rondônia", "RO"),
				new Estado("Roraima", "RR"),
				new Estado("Santa Catarina", "SC"),
				new Estado("São Paulo", "SP"),
				new Estado("Sergipe", "SE"),
				new Estado("Tocantins", "TO"));

			context.SaveChanges();

			var estado = context.Estados.FirstOrDefault(e => e.UnidadeFederativa == "SP");
			
			context.Cidades.Add(new Cidade("Campinas", "CPS", estado.Codigo));
			context.Cidades.Add(new Cidade("São Paulo", "SPA", estado.Codigo));

			estado = context.Estados.FirstOrDefault(e => e.UnidadeFederativa == "RJ");

			context.Cidades.Add(new Cidade("Rio de Janeiro", "RJN", estado.Codigo));
			context.Cidades.Add(new Cidade("Paraty", "PAR", estado.Codigo));

			context.SaveChanges();

		}

	}

}