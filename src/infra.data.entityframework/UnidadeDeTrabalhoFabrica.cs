using br.com.klinderrh.social.infra.interfaces.data;

namespace br.com.klinderrh.social.infra.data.entityframework
{
	public class UnidadeDeTrabalhoFabrica : IUnidadeDeTrabalhoFabrica
	{
		public IUnidadeDeTrabalho Criar()
		{
			//return new UnidadeDeTrabalho(Contexto.Instancia);
			return new UnidadeDeTrabalho(new Contexto());
		}
	}
}