using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using KlinderRH.Social.Dominio.Entidades;
using KlinderRH.Social.Dominio.Interfaces.Aplicacao;
using KlinderRH.Social.Dominio.ObjetosDeTransporte;

namespace KlinderRH.Social.Web.Api.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	[EnableCors("*", "*", "*")]
	[RoutePrefix("cargos")]
	public class CargoController : ApiController
	{
		private readonly ICargoAplicacao _cargoAplicacao;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cargoAplicacao"></param>
		public CargoController(ICargoAplicacao cargoAplicacao)
		{
			_cargoAplicacao = cargoAplicacao;
		}

		/// <summary>
		/// Obtem os cargos ativos.
		/// </summary>
		/// <returns>Coleção de cargos ativos</returns>
		[Authorize]
		[Route]
		[ResponseType(typeof(ICollection<Cargo>))]
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
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Authorize]
		[Route("{id:guid}")]
		public HttpResponseMessage Get(Guid id)
		{
			try
			{
				var cargo = _cargoAplicacao.ObterPorId(id);

				return Request.CreateResponse(HttpStatusCode.OK, cargo);

			}
			catch (Exception ex)
			{
				return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao obter cargo.");
			}

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="textoDaBusca"></param>
		/// <returns></returns>
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

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cargo"></param>
		/// <returns></returns>
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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cargo"></param>
		/// <returns></returns>
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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Authorize]
		[Route("{id:guid}")]
		public HttpResponseMessage Delete(Guid id)
		{
			try
			{
				_cargoAplicacao.Excluir(id);

				return Request.CreateResponse(HttpStatusCode.OK, "Cargo excluído com sucesso.");

			}
			catch (Exception ex)
			{
				return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao excluir cargo.");
			}

		}

	}

}