using br.com.klinderrh.social.dominio.entidades;

namespace br.com.klinderrh.social.infra.interfaces.aplicacao
{
	public interface IUsuarioAplicacao
	{
		Usuario Registrar(string nome, string email, string senha, string confirmacaoDaSenha);
		Usuario Autenticar(string email, string senha);
	}
}