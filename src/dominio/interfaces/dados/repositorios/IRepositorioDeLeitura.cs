using System;
using System.Linq;
using System.Linq.Expressions;
using KlinderRH.Social.Dominio.Entidades;

namespace KlinderRH.Social.Dominio.Interfaces.Dados.Repositorios
{
	public interface IRepositorioDeLeitura<T> where T : EntidadeBase
	{
		T ObterPorId(Guid id);
		IQueryable<T> ObterPor(Expression<Func<T, bool>> condicao = null, params Expression<Func<T, object>>[] dependencias);
	}
}