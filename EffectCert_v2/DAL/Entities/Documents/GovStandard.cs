﻿namespace EffectCert.DAL.Entities.Documents
{
    public class GovStandard
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Paragraphs { get; set; }
    }
}
