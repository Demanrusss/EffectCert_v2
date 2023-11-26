ALTER TABLE ActionPlans
ADD CONSTRAINT FK_ActionPlansApplications_ApplicationId FOREIGN KEY (ApplicationId)
	REFERENCES Applications(Id),
	CONSTRAINT FK_ActionPlansAssessBodyEmployees_AppAnalizeExpertId FOREIGN KEY (AppAnalizeExpertId)
	REFERENCES AssessBodyEmployees(Id),
	CONSTRAINT FK_ActionPlansAssessBodyEmployees_ConformityAssessBodyHeadId FOREIGN KEY (ConformityAssessBodyHeadId)
	REFERENCES AssessBodyEmployees(Id),
	CONSTRAINT FK_ActionPlansContractorLegalEmployees_SelectProductEmployeeId FOREIGN KEY (SelectProductEmployeeId)
	REFERENCES ContractorLegalEmployees(Id),
	CONSTRAINT FK_ActionPlansAssessBodyEmployees_ResultsAnalizeExpertId FOREIGN KEY (ResultsAnalizeExpertId)
	REFERENCES AssessBodyEmployees(Id),
	CONSTRAINT FK_ActionPlansAssessBodyEmployees_RegDocumentEmployeeId FOREIGN KEY (RegDocumentEmployeeId)
	REFERENCES AssessBodyEmployees(Id)
;

ALTER TABLE AppDecisions
ADD CONSTRAINT FK_AppDecisionsApplications_ApplicationId FOREIGN KEY (ApplicationId)
	REFERENCES Applications(Id),
	CONSTRAINT FK_AppDecisionsActionPlans_ActionPlanId FOREIGN KEY (ActionPlanId)
	REFERENCES ActionPlans(Id),
	CONSTRAINT FK_AppDecisionsAssessBodies_ProductionAnalyzeAssessBodyId FOREIGN KEY (ProductionAnalyzeAssessBodyId)
	REFERENCES AssessBodies(Id),
	CONSTRAINT FK_AppDecisionsLaboratories_ProductionAnalyzeLaboratoryId FOREIGN KEY (ProductionAnalyzeLaboratoryId)
	REFERENCES Laboratories(Id),
	CONSTRAINT FK_AppDecisionsAssessBodies_InspectionAssessBodyId FOREIGN KEY (InspectionAssessBodyId)
	REFERENCES AssessBodies(Id),
	CONSTRAINT FK_AppDecisionsLaboratories_InspectionLaboratoryId FOREIGN KEY (InspectionLaboratoryId)
	REFERENCES Laboratories(Id),
	CONSTRAINT FK_AppDecisionsSchemas_SchemaAnotherId FOREIGN KEY (SchemaAnotherId)
	REFERENCES [Schemas](Id)
;

ALTER TABLE Applications
ADD CONSTRAINT FK_ApplicationsAssessBodies_AssessBodyId FOREIGN KEY (AssessBodyId)
	REFERENCES AssessBodies(Id),
	CONSTRAINT FK_ApplicationsContractorLegals_ContractorLegalId FOREIGN KEY (ContractorLegalId)
	REFERENCES ContractorLegals(Id),
	CONSTRAINT FK_ApplicationsSchemas_SchemaId FOREIGN KEY (SchemaId)
	REFERENCES [Schemas](Id)
;

ALTER TABLE ExpertDecisions
ADD CONSTRAINT FK_ExpertDecisionsApplications_ApplicationId FOREIGN KEY (ApplicationId)
	REFERENCES Applications(Id),
	CONSTRAINT FK_ExpertDecisionsAssessBodyEmployees_ExpertId FOREIGN KEY (ExpertId)
	REFERENCES AssessBodyEmployees(Id),
	CONSTRAINT FK_ExpertDecisionsAssessBodyEmployees_DocsAnalizeExpertId FOREIGN KEY (DocsAnalizeExpertId)
	REFERENCES AssessBodyEmployees(Id)
;

ALTER TABLE IssueDecisions
ADD CONSTRAINT FK_IssueDecisionsApplications_ApplicationId FOREIGN KEY (ApplicationId)
	REFERENCES Applications(Id),
	CONSTRAINT FK_IssueDecisionsCertificates_CertificateId FOREIGN KEY (CertificateId)
	REFERENCES [Certificates](Id),
	CONSTRAINT FK_IssueDecisionsExpertDecisions_ExpertDecisionId FOREIGN KEY (ExpertDecisionId)
	REFERENCES ExpertDecisions(Id),
	CONSTRAINT FK_IssueDecisionsDeclarations_DeclarationId FOREIGN KEY (DeclarationId)
	REFERENCES Declarations(Id),
	CONSTRAINT FK_IssueDecisionsRecommendations_RecommendationId FOREIGN KEY (RecommendationId)
	REFERENCES Recommendations(Id)
;

ALTER TABLE Recommendations
ADD CONSTRAINT FK_RecommendationsApplications_ApplicationId FOREIGN KEY (ApplicationId)
	REFERENCES Applications(Id),
	CONSTRAINT FK_RecommendationsDecisions_AppDecisionId FOREIGN KEY (AppDecisionId)
	REFERENCES AppDecisions(Id),
	CONSTRAINT FK_RecommendationsSelectProductsActs_SelectProductsActId FOREIGN KEY (SelectProductsActId)
	REFERENCES SelectProductsActs(Id),
	CONSTRAINT FK_RecommendationsExpertDecisions_ExpertDecisionId FOREIGN KEY (ExpertDecisionId)
	REFERENCES ExpertDecisions(Id)
;

ALTER TABLE SelectProductsActs
ADD CONSTRAINT FK_SelectProductsActsApplications_ApplicationId FOREIGN KEY (ApplicationId)
	REFERENCES Applications(Id),
	CONSTRAINT FK_SelectProductsActsActionPlans_ActionPlanId FOREIGN KEY (ActionPlanId)
	REFERENCES ActionPlans(Id),
	CONSTRAINT FK_SelectProductsActsAddresses_AddressId FOREIGN KEY (AddressId)
	REFERENCES Addresses(Id),
	CONSTRAINT FK_SelectProductsActsContractorLegals_SupplierId FOREIGN KEY (SupplierId)
	REFERENCES ContractorLegals(Id)
;