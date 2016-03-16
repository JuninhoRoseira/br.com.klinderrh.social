namespace br.com.klinderrh.social.infra.interfaces.data
{
	public interface IUnidadeDeTrabalhoFabrica
	{
		IUnidadeDeTrabalho Criar();
		void Destruir(bool executar);
	}
}