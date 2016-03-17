using System;
using System.Collections;
using System.Data.Entity;
using br.com.klinderrh.social.dominio.entidades;
using br.com.klinderrh.social.infra.data.entityframework.repositorios;
using br.com.klinderrh.social.infra.interfaces.data;

namespace br.com.klinderrh.social.infra.data.entityframework
{
	public class UnidadeDeTrabalho : IUnidadeDeTrabalho
	{

		private readonly Contexto _contexto;
		private DbContextTransaction _transacao;
		private Hashtable _repositories;
		
		private bool TransacaoAtiva => (_transacao != null);

		public UnidadeDeTrabalho(Contexto contexto)
		{
			_contexto = contexto;
		}

		public bool IniciarTransacao()
		{
			if (TransacaoAtiva)
				return false;

			_transacao = _contexto.Database.BeginTransaction();

			return true;

		}

		public void EfetivarTransacao(bool executar)
		{
			if (!TransacaoAtiva)
				throw new NullReferenceException("Nenhuma transação ativa no momento.");

			if (!executar) return;

			_transacao.Commit();

			LiberarTransacao();

		}

		public void DescartarTransacao(bool executar)
		{
			if (!TransacaoAtiva)
				throw new NullReferenceException("Nenhuma transação ativa no momento.");

			if (!executar) return;

			_transacao.Rollback();

			LiberarTransacao();

		}

		public void Salvar()
		{
			_contexto.SaveChanges();
		}

		private void LiberarTransacao()
		{
			_transacao.Dispose();

			_transacao = null;
			_repositories = null;

		}

		public IRepositorioGenerico<T> ObterRepositorio<T>() where T : EntidadeBase
		{
			if (_repositories == null)
				_repositories = new Hashtable();

			var type = typeof(T).Name;

			if (!_repositories.ContainsKey(type))
			{
				var repositoryType = typeof(RepositorioGenerico<>);

				var repositoryInstance = Activator.CreateInstance(
					repositoryType.MakeGenericType(typeof(T)), _contexto);

				_repositories.Add(type, repositoryInstance);

			}

			return (IRepositorioGenerico<T>)_repositories[type];

		}

	}

}