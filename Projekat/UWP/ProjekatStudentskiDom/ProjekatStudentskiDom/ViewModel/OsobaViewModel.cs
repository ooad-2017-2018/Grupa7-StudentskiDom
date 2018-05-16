using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatStudentskiDom;

namespace ProjekatStudentskiDom.ViewModel
{
	class OsobaViewModel
	{
		protected string ime;
		protected string prezime;
		protected string datumRodjenja;
		protected string username;
		protected string password;
		protected string jmbg;
		protected char pol;
		public string id;

		public OsobaViewModel() { }

		public string Ime { get { return ime; } set { this.ime = value; } }
		public string Prezime { get { return prezime; } set { this.prezime = value; } }
		public string DatumRodjenja { get { return datumRodjenja; } set { this.datumRodjenja = value; } }
		public string Username { get { return username; } set { this.username = value; } }
		public string Password { get { return password; } set { this.password = value; } }
		public string Jmbg { get { return jmbg; } set { this.jmbg = value; } }
		public char Pol { get { return pol; } set { this.pol = value; } }

		public override string ToString()
		{
			return ime + " " + prezime + ", datum rođenja: " + datumRodjenja + ", username: " + username + ", password: " + password;
		}
	}
}
