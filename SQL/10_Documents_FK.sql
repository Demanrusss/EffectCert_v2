ALTER TABLE TestProtocols
ADD CONSTRAINT FK_TestProtocolsLaboratories_LaboratoryId FOREIGN KEY (LaboratoryId)
	REFERENCES Laboratories(Id)
;