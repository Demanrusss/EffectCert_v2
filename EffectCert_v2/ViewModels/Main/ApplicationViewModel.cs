﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using EffectCert.ViewModels.Contractors;
using EffectCert.ViewModels.Others;
using EffectCert.ViewModels.Documents;

namespace EffectCert.ViewModels.Main
{
    public class ApplicationViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Номер")]
        public string Number { get; set; } = null!;
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Дата")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        public int AssessBodyId { get; set; }
        [DisplayName("Орган подтверждения соответствия")]
        public AssessBodyViewModel? AssessBody { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        public int ContractorLegalId { get; set; }
        [DisplayName("Заявитель")]
        public ContractorLegalViewModel? ContractorLegal { get; set; }
        [DisplayName("Номер в электронном реестре")]
        public string? ElectronicNumber { get; set; }
        [DisplayName("Дата в электронном реестре")]
        public DateTime? ElectronicDate { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        public int SchemaId { get; set; }
        [DisplayName("Схема подтверждения соответствия")]
        public SchemaViewModel? Schema { get; set; }

        [DisplayName("Продукция")]
        public ICollection<ProductViewModel> Products { get; set; } = new HashSet<ProductViewModel>();
        public int[]? ProductsIds { get; set; }
        [DisplayName("Продукция и количество")]
        public ICollection<ProductQuantityViewModel> ProductQuantities { get; set; } = new HashSet<ProductQuantityViewModel>();
        public int[]? ProductQuantitiesIds { get; set; }
        [DisplayName("Технические регламенты")]
        public List<TechRegParagraphsViewModel> TechRegParagraphs { get; set; } = new List<TechRegParagraphsViewModel>();
    }
}
