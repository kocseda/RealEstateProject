using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmlakProjesi.Models
{
    public partial class Musteri
    {
        public Musteri()
        {
            Konut = new HashSet<Konut>();
        }

        public long MusteriId { get; set; }

        //some validations are provided for creating or editing. these validations are chosen due to attribute data types and constraints.

        [Required(ErrorMessage = "İsim girmek zorunludur.")]
        [Display(Name = "İsim", Prompt = "Frodo")]
        public string Isim { get; set; }

        [Required(ErrorMessage = "Soyisim girmek zorunludur.")]
        [Display(Name = "Soyisim", Prompt = "Baggins")]
        public string SoyIsim { get; set; }

        [Required(ErrorMessage = "Telefon numarası girmek zorunludur.")]
        [Display(Name = "Telefon Numarası", Prompt = "5222222222")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email girmek numarası zorunludur.")]
        [Display(Name = "Email", Prompt = "frodo@shire.com")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Adres girmek numarası zorunludur.")]
        [Display(Prompt = "Çıkın Çıkmazı Konut:107 Shire")]
        public string Adres { get; set; }
        public DateTime? OlusturmaTarihi { get; set; }

        public virtual ICollection<Konut> Konut { get; set; }
    }
}
