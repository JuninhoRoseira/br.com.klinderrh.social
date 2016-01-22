using br.com.klinderrh.social.dominio.entidades;

namespace br.com.klinderrh.social.infra.interfaces.data
{
	public interface IRepositorioGenerico<T> : IRepositorioDeGravacao<T>, IRepositorioDeLeitura<T> where T : EntidadeBase
	{
		 
	}
}