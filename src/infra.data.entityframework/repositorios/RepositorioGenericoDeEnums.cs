using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using br.com.klinderrh.social.infra.interfaces.data;

namespace br.com.klinderrh.social.infra.data.entityframework.repositorios
{
	public class RepositorioGenericoDeEnums<T> : IRepositorioGenericoDeEnums<T> where T : class
	{
		private readonly DbContext _contexto;
		private readonly DbSet<T> _dbSet;

		public RepositorioGenericoDeEnums(DbContext contexto)
		{
			_contexto = contexto;
			_dbSet = _contexto.Set<T>();
		}

		public IQueryable<T> ObterPor(Expression<Func<T, bool>> condicao = null,
			params Expression<Func<T, object>>[] dependencias)
		{
			var query = condicao != null
				? _dbSet.AsNoTracking().Where(condicao)
				: _dbSet.AsNoTracking();

			query = dependencias.Aggregate(query,
				(current, include) => current.Include(include));

			return query;

		}

	}

}