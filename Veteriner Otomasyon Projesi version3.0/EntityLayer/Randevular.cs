using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
	[Table("tblRandevular")]
	public class Randevular
	{
		[Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public DateTime Tarih { get; set; }
		[ForeignKey("Musteri")]
		public string MusteriTC { get; set; }
		public Musteri Musteri { get; set; }
		[ForeignKey("Doktorlar")]
		public int DoktorId { get; set; }
		public Doktorlar Doktorlar { get; set; }
		public string Açıklama { get; set; }
		public string Durum { get; set; }
	}
}
