using System.ComponentModel.DataAnnotations;

namespace OtelMotel.MvcUI.Areas.Admin.Models.Musteri
{
	public class MusteriUpdateDTO
	{
		public Guid Id { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "Email Zorunlu Alandir")]
		[DataType(DataType.Text)]
		public string Ad { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "Email Zorunlu Alandir")]
		[DataType(DataType.Text)]
		public string Soyad { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "TcNo Zorunlu Alandir")]
		[MaxLength(11)]
		public string MusteriTcNo { get; set; }
		public string CepNo { get; set; }
		public bool Cinsiyet { get; set; }
		public Guid KullaniciId { get; set; }

	}
}
