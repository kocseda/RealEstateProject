using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmlakProjesi.Models
{
    public partial class Konut
    {
        public long KonutId { get; set; }

        //some validations are provided for creating or editing. these validations are chosen due to attribute data types and constraints.

        [Display(Name = "İşletme Adı", Prompt = "Ofis")]
        public long? IsyeriId { get; set; }

        [Display(Name = "Müşteri Kullanıcı Adı", Prompt = "Ofis")]
        public long? MusteriId { get; set; }

        [Required(ErrorMessage = "Emlak türü girmek zorunludur.")]
        [Display(Name = "Emlak Türü", Prompt = "Ofis")]
        public string EmlakTuru { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Geçerli bir alan giriniz.")]
        [Required(ErrorMessage = "Alan girmek zorunludur.")]
        [Display(Name = "Alan (metrekare)", Prompt = "1000")]
        public double Alan { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Oda sayısı rakamlardan oluşmalıdır.")]
        [Display(Name = "Oda Sayısı", Prompt = "3")]
        public int? OdaSayisi { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Kat No. rakamlardan oluşmalıdır.")]
        [Display(Name = "Kat No.", Prompt = "5")]
        public int? KatNo { get; set; }

        [Display(Name = "Isınma Türü", Prompt = "Yerden Isıtma")]
        public string IsinmaTuru { get; set; }

        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Geçerli bir satış fiyatı giriniz.")]
        [Display(Name = "Satış Fiyatı (TL)", Prompt = "21.75")]
        public double? SatisFiyati { get; set; }
        public DateTime? OlusturmaTarihi { get; set; }

        public virtual Isyeri Isyeri { get; set; }
        public virtual Musteri Musteri { get; set; }
    }
}
