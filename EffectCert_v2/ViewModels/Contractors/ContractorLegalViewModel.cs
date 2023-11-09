﻿using System.ComponentModel;

namespace EffectCert.ViewModels.Contractors
{
    public class ContractorLegalViewModel
    {
        public int Id { get; set; }
        [DisplayName("Полное наименование")]
        public string FullName { get; set; } = null!;
        [DisplayName("Сокращенное наименование")]
        public string ShortName { get; set; } = null!;
        [DisplayName("БИН")]
        public string? BIN { get; set; }
        [DisplayName("Адрес регистрации")]
        public AddressViewModel RegAddress { get; set; } = null!;
        public int RegAddressId { get; set; }
        [DisplayName("Адрес фактический")]
        public AddressViewModel? FactAddress { get; set; }
        public int FactAddressId { get; set; }
        [DisplayName("Адреса совпадают")]
        public bool IsAddressSame { get; set; }
        [DisplayName("Банковский счет")]
        public BankAccountViewModel? BankAccount { get; set; }
        public int BankAccountId { get; set; }
        [DisplayName("Сотрудники")]
        public ICollection<ContractorLegalEmployeeViewModel> Employees { get; set; } = new List<ContractorLegalEmployeeViewModel>();
    }
}
