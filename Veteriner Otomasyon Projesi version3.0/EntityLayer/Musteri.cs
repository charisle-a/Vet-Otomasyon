using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
	[Table("tblMusteri")]
	public class Musteri
	{
		[Key]
		public string TCNO { get; set; }
		public string Ad { get; set; }
		public string Soyad{ get; set; }
		public string TelNo { get; set; }

	}
}
