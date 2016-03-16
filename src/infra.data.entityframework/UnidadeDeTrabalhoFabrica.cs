using System;
using br.com.klinderrh.social.infra.interfaces.data;

namespace br.com.klinderrh.social.infra.data.entityframework
{
	public class UnidadeDeTrabalhoFabrica : IUnidadeDeTrabalhoFabrica
	{
		private UnidadeDeTrabalho _unidadeDeTrabalho;
		private Contexto _contexto;

		public IUnidadeDeTrabalho Criar()
		{
			if (_unidadeDeTrabalho == null)
			{
				if (_contexto == null)
				{
					_contexto = new Contexto();

				}

				_unidadeDeTrabalho = new UnidadeDeTrabalho(_contexto);

			}

			return _unidadeDeTrabalho;

		}

		public void Destruir(bool executar)
		{
			if (!executar)
				return;

			_contexto.Dispose();

			_contexto = null;
			_unidadeDeTrabalho = null;

		}

	}

}