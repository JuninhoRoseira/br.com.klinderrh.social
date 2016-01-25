using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace br.com.klinderrh.social.dominio.entidades
{
	public class Colaborador : EntidadeBase
	{

		protected Colaborador()
		{

		}

		public string NumeroInscricao { get; set; }

		public Pessoa Pessoa { get; set; }
		public Empresa Empresa { get; set; }
		public Departamento Departamento { get; set; }
		public Cargo Cargo { get; set; }

	}

}