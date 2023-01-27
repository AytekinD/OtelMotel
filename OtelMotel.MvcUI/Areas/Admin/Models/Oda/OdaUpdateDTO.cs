using System.ComponentModel.DataAnnotations;

namespace OtelMotel.MvcUI.Areas.Admin.Models.Oda
{
	public class OdaUpdateDTO
	{
		public Guid Id { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "Oda Zorunlu Alandir")]
		[DataType(DataType.Text)]
		public string OdaNo { get; set; }
		public byte KisiSayisi { get; set; }
		public bool Durum { get; set; } = true;
	}
}
