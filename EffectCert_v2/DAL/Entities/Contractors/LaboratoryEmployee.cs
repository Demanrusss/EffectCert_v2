namespace EffectCert.DAL.Entities.Contractors
{
    public class LaboratoryEmployee : IEntity
    {
        public int Id { get; set; }
        public int ContractorLegalEmployeeId { get; set; }
        public ContractorLegalEmployee ContractorLegalEmployee { get; set; } = null!;
        public string Position { get; set; } = null!;
        public int? LaboratoryId { get; set; }
    }
}
