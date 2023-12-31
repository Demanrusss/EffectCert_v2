﻿namespace EffectCert.DAL.Entities.Contractors
{
    public class AssessBodyEmployee : IEntity
    {
        public int Id { get; set; }
        public int ContractorLegalEmployeeId { get; set; }
        public ContractorLegalEmployee ContractorLegalEmployee { get; set; } = null!;
        public string Position { get; set; } = null!;
        public string? ExpertAuditorOrientation { get; set; }
        public int? AssessBodyId { get; set; }
    }
}
