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
	[RoutePrefix("auth")]
	public class AutenticacaoController : ApiController
	{
		private readonly IUsuarioAplicacao _usuarioAplicacao;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="usuarioAplicacao"></param>
		public AutenticacaoController(IUsuarioAplicacao usuarioAplicacao)
		{
			_usuarioAplicacao = usuarioAplicacao;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="usuario"></param>
		/// <returns></returns>
		[Route]
		public HttpResponseMessage Post(UsuarioModelo usuario)
		{
			if (usuario == null)
				return Request.CreateResponse(HttpStatusCode.BadRequest);

			try
			{
				var novoUsuario = _usuarioAplicacao.Registrar(new UsuarioModelo
				{
					Nome = usuario.Nome,
					Email = usuario.Email,
					Senha = usuario.Senha,
					ConfirmacaoDaSenha = usuario.ConfirmacaoDaSenha
				});

				return Request.CreateResponse(HttpStatusCode.Created, novoUsuario);

			}
			catch (Exception ex)
			{
				return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao incluir tipo de inspeção");
			}

		}

	}

}