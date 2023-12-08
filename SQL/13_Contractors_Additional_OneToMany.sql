ALTER TABLE AssessBodyEmployees
ADD AssessBodyId INT NULL
;

ALTER TABLE AssessBodyEmployees
ADD CONSTRAINT FK_AssessBodyEmployeesAssessBodies_AssessBodyId FOREIGN KEY (AssessBodyId)
	REFERENCES AssessBodies(Id)
;

ALTER TABLE ContractorLegalEmployees
ADD ContractorLegalId INT NULL
;

ALTER TABLE ContractorLegalEmployees
ADD CONSTRAINT FK_ContractorLegalEmployeesContractorLegals_ContractorLegalId FOREIGN KEY (ContractorLegalId)
	REFERENCES ContractorLegals(Id)
;

ALTER TABLE LaboratoryEmployees
ADD LaboratoryId INT NULL
;

ALTER TABLE LaboratoryEmployees
ADD CONSTRAINT FK_LaboratoryEmployeesLaboratories_LaboratoryId FOREIGN KEY (LaboratoryId)
	REFERENCES Laboratories(Id)
;