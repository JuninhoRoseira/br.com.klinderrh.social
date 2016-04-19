using KlinderRH.Social.Dominio.Entidades;

namespace KlinderRH.Social.Infra.Data.EntityFramework.Mapeamentos
{
	public class CargoMap : MapeamentoBase<Cargo>
	{
		public CargoMap()
		{
			ToTable("Cargo");

			Property(c => c.Nome).HasMaxLength(100).IsRequired().HasColumnAnnotation("Index", NovoIndice("IX_Cargo_Nome"));
			Property(c => c.Sigla).HasMaxLength(10).IsOptional();
			Property(c => c.Descricao).HasMaxLength(1000).IsOptional();
			Property(c => c.Nivel).HasColumnName("NivelDoCargoId").IsRequired();

		}

	}
}