using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using br.com.klinderrh.social.dominio.objetosdetransporte;
using br.com.klinderrh.social.infra.interfaces.aplicacao;

namespace br.com.klinderrh.social.web.api.Controllers
{
	[EnableCors("*", "*", "*")]
	[RoutePrefix("cargos")]
	public class CargoController : ApiController
	{
		private readonly ICargoAplicacao _cargoAplicacao;

		public CargoController(ICargoAplicacao cargoAplicacao)
		{
			_cargoAplicacao = cargoAplicacao;
		}

		[Authorize]
		[Route]
		public HttpResponseMessage Get()
		{
			try
			{
				var cargosAtivos = _cargoAplicacao.ObterTodosOsAtivos();

				return Request.CreateResponse(HttpStatusCode.OK, cargosAtivos);

			}
			catch (Exception ex)
			{
				return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao obter cargos.");
			}

		}
		
		[Authorize]
		[Route("{codigo:int}")]
		public HttpResponseMessage Get(int codigo)
		{
			try
			{
				var cargo = _cargoAplicacao.ObterPorCodigo(codigo);

				return Request.CreateResponse(HttpStatusCode.OK, cargo);

			}
			catch (Exception ex)
			{
				return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao obter cargo.");
			}

		}

		[Authorize]
		[Route("{textoDaBusca}")]
		public HttpResponseMessage Get(string textoDaBusca)
		{
			try
			{
				var cargos = _cargoAplicacao.ProcurarCargosPorTexto(textoDaBusca);

				return Request.CreateResponse(HttpStatusCode.OK, cargos);

			}
			catch (Exception ex)
			{
				return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao obter cargo.");
			}

		}

		[Authorize]
		[Route("ObterNiveis")]
		public HttpResponseMessage GetObterNiveis()
		{
			try
			{
				var niveis = _cargoAplicacao.ObterNiveis();

				return Request.CreateResponse(HttpStatusCode.OK, niveis);

			}
			catch (Exception ex)
			{
				return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao obter cargo.");
			}

		}

		[Authorize]
		[Route]
		public HttpResponseMessage Post(CargoModelo cargo)
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

		[Authorize]
		[Route]
		public HttpResponseMessage Put(CargoModelo cargo)
		{
			if (cargo == null)
				return Request.CreateResponse(HttpStatusCode.BadRequest);

			try
			{
				_cargoAplicacao.Modificar(cargo);

				return Request.CreateResponse(HttpStatusCode.OK, "Cargo modificado com sucesso.");

			}
			catch (Exception ex)
			{
				return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao modificar cargo.");
			}

		}

		[Authorize]
		[Route("{codigo:int}")]
		public HttpResponseMessage Delete(int codigo)
		{
			try
			{
				_cargoAplicacao.Excluir(codigo);

				return Request.CreateResponse(HttpStatusCode.OK, "Cargo excluído com sucesso.");

			}
			catch (Exception ex)
			{
				return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao excluir cargo.");
			}

		}

	}

}