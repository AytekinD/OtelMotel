using System.ComponentModel.DataAnnotations;

namespace OtelMotel.MvcUI.Areas.Admin.Models.Kullanici
{
    public class KullaniciCreateDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "KullaniciAdi Zorunludur")]
        public string KullaniciAdi { get; set; }
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = false, ErrorMessage = "Email Zorunlu Alandir")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Sifre Zorunlu Alandir")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Sifre Zorunlu Alandir")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Sifre Bilgileri uyumsuzdur")]
        public string RePassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "TcNo Zorunludur")]
        [MaxLength(11)]
        public string TcNo { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public bool Cinsiyet { get; set; }
        public DateTime DogumTarihi { get; set; }
        public IFormFile? ImageFile { get; set; }


    }
}
