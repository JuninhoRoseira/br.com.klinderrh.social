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
	public class CargoController : ApiController
	{
		private const string RotaPadrao = "Cargos";
		private readonly ICargoAplicacao _cargoAplicacao;

		public CargoController(ICargoAplicacao cargoAplicacao)
		{
			_cargoAplicacao = cargoAplicacao;
		}

		[Authorize]
		[HttpPost]
		[Route(RotaPadrao)]
		public HttpResponseMessage PostCargo(CargoModelo cargo)
		{

			if (cargo == null)
				return Request.CreateResponse(HttpStatusCode.BadRequest);

			try
			{
				var novoFuncionatrio = _cargoAplicacao.Adicionar(cargo);

				return Request.CreateResponse(HttpStatusCode.Created, novoFuncionatrio);

			}
			catch (Exception ex)
			{
				return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao incluir cargo.");
			}

		}

	}

}