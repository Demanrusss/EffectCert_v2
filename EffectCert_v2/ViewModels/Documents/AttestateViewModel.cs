namespace EffectCert.ViewModels.Documents
{
    public class AttestateViewModel
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public DateTime Date { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
