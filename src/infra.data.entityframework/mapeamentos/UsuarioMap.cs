using KlinderRH.Social.Dominio.Entidades;

namespace KlinderRH.Social.Infra.Data.EntityFramework.Mapeamentos
{
	public class UsuarioMap : MapeamentoBase<Usuario>
	{
		public UsuarioMap()
		{
			ToTable("Usuario");

			Property(u => u.Senha)
				.HasMaxLength(100)
				.IsRequired();
			Property(u => u.Nome)
				.HasMaxLength(50)
				.IsRequired()
				.HasColumnAnnotation("Index", NovoIndiceUnico("IX_Usuario_Nome"));
			Property(u => u.Email)
				.HasMaxLength(50)
				.IsRequired()
				.HasColumnAnnotation("Index", NovoIndiceUnico("IX_Usuario_Email"));
			Property(u => u.Valido)
				.IsOptional();

		}

	}
}