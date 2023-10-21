namespace EffectCert.DAL.Entities.Contractors
{
    public class LaboratoryEmployee : IEntity
    {
        public int Id { get; set; }
        private int ContractorLegalEmployeeId { get; set; }
        public ContractorLegalEmployee ContractorLegalEmployee { get; set; } = null!;
        public string Position { get; set; } = null!;
    }
}
