namespace EffectCert.DAL.Entities.Contractors
{
    public class ContractorIndividual : IEntity
    {
        public int Id { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string? IIN { get; set; }
    }
}
