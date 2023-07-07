namespace EffectCert.DAL.Entities.Contractors
{
    public class BankAccount
    {
        public int Id { get; set; }
        public string IIK { get; set; } = null!;
        public string BankName { get; set; } = null!;
        public string BIK { get; set; } = null!;
    }
}
