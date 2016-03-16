using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using br.com.klinderrh.social.dominio.objetosdetransporte;
using br.com.klinderrh.social.infra.interfaces.aplicacao;

namespace br.com.klinderrh.social.web.api.Controllers
{

	[EnableCors(origins: "*", headers: "*", methods: "*")]
	[RoutePrefix("api")]
	public class FuncionarioController : ApiController
	{
		private const string RotaPadrao = "Funcionarios";
		private readonly IFuncionarioAplicacao _funcionarioAplicacao;

		public FuncionarioController(IFuncionarioAplicacao funcionarioAplicacao)
		{
			_funcionarioAplicacao = funcionarioAplicacao;
		}

		[Authorize]
		[HttpPost]
		[Route(RotaPadrao)]
		public HttpResponseMessage PostFuncionario(FuncionarioModelo funcionario)
		{

			if (funcionario == null)
				return Request.CreateResponse(HttpStatusCode.BadRequest);

			try
			{
				var novoFuncionatrio = _funcionarioAplicacao.Adicionar(funcionario);

				return Request.CreateResponse(HttpStatusCode.Created, novoFuncionatrio);

			}
			catch (Exception ex)
			{
				return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao incluir funcionário.");
			}

		}

	}

}