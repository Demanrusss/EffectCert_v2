namespace EffectCert.DAL.Entities.Contractors
{
    public class LaboratoryEmployee
    {
        public int Id { get; set; }
        public int ContractorLegalEmployeeId { get; set; }
        public string Position { get; set; } = null!;
    }
}
