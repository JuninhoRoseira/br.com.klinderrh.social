﻿using br.com.klinderrh.social.dominio.entidades;

namespace br.com.klinderrh.social.infra.data.entityframework.mapeamentos
{
	public class EstadoMap : MapeamentoBase<Estado>
	{
		public EstadoMap()
		{
			ToTable("Estado");

			Property(e => e.Nome).HasMaxLength(50).IsRequired().HasColumnAnnotation("Index", NovoIndice("IX_Estado_Nome"));
			Property(e => e.Pais).HasMaxLength(10).IsOptional();
			Property(e => e.UnidadeFederativa).HasMaxLength(2).IsRequired();

		}

	}
}