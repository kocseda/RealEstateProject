using Ext.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmlakProjesi.Models
{
    public partial class Isyeri
    {
        public Isyeri()
        {
            Konut = new HashSet<Konut>();
        }

        public long IsyeriId { get; set; }

        //some validations are provided for creating or editing. these validations are chosen due to attribute data types and constraints.

        [Required(ErrorMessage = "Adres girmek zorunludur.")]
        [Display(Name = "İşletme Adı", Prompt = "Westeros Corp.")]
        public string IsletmeAdi { get; set; }

        [Display(Prompt = "Uğur Mumcu Cd. No:19/3 Çankaya/Ankara")]
        [Required(ErrorMessage = "Adres girmek zorunludur.")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Telefon numarası girmek zorunludur.")]
        [Display(Name = "Telefon Numarası", Prompt = "5222222222")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        public string PhoneNumber { get; set; }
        public DateTime? OlusturmaTarihi { get; set; }

        [Required(ErrorMessage = "Yetkili Adı zorunludur.")]
        [Display(Name = "Yetkili Adı", Prompt = "Sylvanas Windrunner")]
        public string YetkiliAdi { get; set; }

        public virtual ICollection<Konut> Konut { get; set; }
    }
}
