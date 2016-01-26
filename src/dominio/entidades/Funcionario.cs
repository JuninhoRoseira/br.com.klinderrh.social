using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace br.com.klinderrh.social.dominio.entidades
{
	public class Funcionario : EntidadeBase
	{

		protected Funcionario() { }

		public Funcionario(string nome)
		{
			
		}

		public string Matricula { get; set; }
		
		public int? CodigoDaPessoa { get; set; }
		public Pessoa Pessoa { get; set; }

		public int CodigoDaEmpresa { get; set; }
		public virtual Empresa Empresa { get; set; }

		public int CodigoDoDepartamento { get; set; }
		public virtual Departamento Departamento { get; set; }

		public int CodigoDoCargo { get; set; }
		public virtual Cargo Cargo { get; set; }

	}

}