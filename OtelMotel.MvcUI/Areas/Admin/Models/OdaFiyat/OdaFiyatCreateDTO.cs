using System.ComponentModel.DataAnnotations;

namespace OtelMotel.MvcUI.Areas.Admin.Models.OdaFiyat
{
    public class OdaFiyatCreateDTO
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "Baslangıc Zamanı Bos Bırakılamaz")]
        public DateTime Baslangic { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Bitis Zamanı Bos Birakilamaz")]
        public DateTime Bitis { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Fiyat Bos Biraklamaz")]

        public float Fiyat { get; set; }


        public List<string>? Odalar { get; set; }
    }
}
