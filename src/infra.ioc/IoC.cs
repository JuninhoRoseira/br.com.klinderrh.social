using KlinderRH.Social.Aplicacao;
using KlinderRH.Social.Dominio.Interfaces.Aplicacao;
using KlinderRH.Social.Dominio.Interfaces.Dados;
using KlinderRH.Social.Infra.Data.EntityFramework;
using KlinderRH.Social.Infra.Data.EntityFramework.Identity;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;

namespace KlinderRH.Social.Infra.IoC
{
	// GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);

	public class IoC
	{
		public IoC()
		{
			Kernel = new StandardKernel(
				new DataBindings(),
				new ApplicationBindings());
		}

		public IKernel Kernel { get; private set; }

	}

	public class DataBindings : NinjectModule
	{
		public override void Load()
		{
			Bind<Contexto>().ToSelf().InSingletonScope();
			Bind<ApplicationRoleManager>().ToSelf().InSingletonScope();
			Bind<ApplicationUserManager>().ToSelf().InSingletonScope();

			Bind<IAppUserStore>().To<ApplicationUserStore>().InRequestScope();
			Bind<IUnidadeDeTrabalho>().To<UnidadeDeTrabalho>().InRequestScope();
			Bind<IAuthorizationServerProvider>().To<AuthorizationServerProvider>();

		}

	}

	public class ApplicationBindings : NinjectModule
	{
		public override void Load()
		{
			Bind<IUsuarioAplicacao>().To<UsuarioAplicacao>();
			Bind<IPessoaAplicacao>().To<PessoaAplicacao>();
			Bind<IFuncionarioAplicacao>().To<FuncionarioAplicacao>();
			Bind<ICargoAplicacao>().To<CargoAplicacao>();
			Bind<IDepartamentoAplicacao>().To<DepartamentoAplicacao>();
		}
	}

}