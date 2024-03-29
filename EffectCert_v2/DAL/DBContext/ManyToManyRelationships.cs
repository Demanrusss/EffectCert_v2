﻿namespace EffectCert.DAL.DBContext
{
    public class ActionPlansLaboratories
    {
        public int ActionPlanId { get; set; }
        public int LaboratoryId { get; set; }
    }

    public class ApplicationsContracts
    {
        public int ApplicationId { get; set; }
        public int ContractId { get; set; }
    }

    public class ApplicationsGovStandardsParagraphs
    {
        public int ApplicationId { get; set; }
        public int GovStandardParagraphsId { get; set; }
    }

    public class ApplicationsGTDs
    {
        public int ApplicationId { get; set; }
        public int GTDId { get; set; }
    }

    public class ApplicationsInvoices
    {
        public int ApplicationId { get; set; }
        public int InvoiceId { get; set; }
    }

    public class ApplicationsManufacturerStandards
    {
        public int ApplicationId { get; set; }
        public int ManufacturerStandardId { get; set; }
    }

    public class ApplicationsProductQuantities
    {
        public int ApplicationId { get; set; }
        public int ProductQuantityId { get; set; }
    }

    public class ApplicationsProducts
    {
        public int ApplicationId { get; set; }
        public int ProductId { get; set; }
    }

    public class ApplicationsRequirements
    {
        public int ApplicationId { get; set; }
        public int RequirementId { get; set; }
    }

    public class ApplicationsTechRegsParagraphs
    {
        public int ApplicationId { get; set; }
        public int TechRegParagraphsId { get; set; }
    }

    public class ExpertDecisionsTestProtocols
    {
        public int ExpertDecisionId { get; set; }
        public int TestProtocolId { get; set; }
    }

    public class SelectProductsActsSelectedSampleQuantities
    {
        public int SelectProductsActId { get; set; }
        public int SelectedSampleQuantityId { get; set; }
    }

    public class SchemasCertObjects
    {
        public int SchemaId { get; set; }
        public int CertObjectId { get; set; }
    }
}
