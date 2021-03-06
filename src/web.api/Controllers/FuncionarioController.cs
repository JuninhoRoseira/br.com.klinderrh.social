﻿using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using KlinderRH.Social.Dominio.Interfaces.Aplicacao;
using KlinderRH.Social.Dominio.ObjetosDeTransporte;

namespace KlinderRH.Social.Web.Api.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	[EnableCors("*", "*", "*")]
	[RoutePrefix("funcionarios")]
	public class FuncionarioController : ApiController
	{
		private readonly IFuncionarioAplicacao _funcionarioAplicacao;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="funcionarioAplicacao"></param>
		public FuncionarioController(IFuncionarioAplicacao funcionarioAplicacao)
		{
			_funcionarioAplicacao = funcionarioAplicacao;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="funcionario"></param>
		/// <returns></returns>
		[Authorize]
		[Route]
		public HttpResponseMessage Post(FuncionarioModelo funcionario)
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