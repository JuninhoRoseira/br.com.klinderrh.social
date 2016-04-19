using System;
using System.Linq;
using System.Linq.Expressions;

namespace KlinderRH.Social.Dominio.Interfaces.Dados.Repositorios
{
	public interface IRepositorioGenericoDeEnums<T> where T : class
	{
		IQueryable<T> ObterPor(Expression<Func<T, bool>> condicao = null, params Expression<Func<T, object>>[] dependencias);
	}
}