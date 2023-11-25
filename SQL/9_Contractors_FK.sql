ALTER TABLE AssessBodies
ADD CONSTRAINT FK_AssessBodiesAddresses_AddressId FOREIGN KEY (AddressId)
	REFERENCES Addresses(Id),
ADD CONSTRAINT FK_AssessBodiesContractorLegals_ContractorLegalId FOREIGN KEY (ContractorLegalId)
	REFERENCES ContractorLegals(Id),
ADD CONSTRAINT FK_AssessBodiesAttestates_AttestateId FOREIGN KEY (AttestateId)
	REFERENCES Attestates(Id)
;

ALTER TABLE AssessBodyEmployees
ADD CONSTRAINT FK_AssessBodyEmployeesContractorLegalEmployees_ContractorLegalEmployeeId FOREIGN KEY (ContractorLegalEmployeeId)
	REFERENCES ContractorLegalEmployees(Id)
;

ALTER TABLE ContractorLegals
ADD CONSTRAINT FK_ContractorLegalsAddresses_RegAddressId FOREIGN KEY (RegAddressId)
	REFERENCES Addresses(Id),
 ADD CONSTRAINT FK_ContractorLegalsAddresses_FactAddressId FOREIGN KEY (FactAddressId)
	REFERENCES Addresses(Id), 
 ADD CONSTRAINT FK_ContractorLegalsBankAccounts_BankAccountId FOREIGN KEY (BankAccountId)
	REFERENCES BankAccounts(Id)
;

ALTER TABLE ContractorLegalEmployees
ADD CONSTRAINT FK_ContractorLegalEmployeesContractorIndividuals_ContractorIndividualId FOREIGN KEY (ContractorIndividualId)
	REFERENCES ContractorIndividuals(Id)
;

ALTER TABLE Laboratories
ADD CONSTRAINT FK_LaboratoriesContractorLegals_ContractorLegalId FOREIGN KEY (ContractorLegalId)
	REFERENCES ContractorLegals(Id),
ADD CONSTRAINT FK_LaboratoriesAttestates_AttestateId FOREIGN KEY (AttestateId)
	REFERENCES Attestates(Id)
;

ALTER TABLE LaboratoryEmployees
ADD CONSTRAINT FK_LaboratoryEmployeesContractorLegalEmployees_ContractorLegalEmployeeId FOREIGN KEY (ContractorLegalEmployeeId)
	REFERENCES ContractorLegalEmployees(Id)
;