﻿namespace EffectCert.DAL.Entities.Others
{
    public class Requirement : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
