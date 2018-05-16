using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatStudentskiDom;

namespace ProjekatStudentskiDom.ViewModel
{
	class AdminViewModel : OsobaViewModel
	{
		public string AdminId { get; set; }

		public AdminViewModel() : base()
		{

		}

		public override string ToString()
		{
			return base.ToString();
		}

	}
}
