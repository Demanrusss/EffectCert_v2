IF OBJECT_ID(N'ExpertDecisionsTestProtocols', N'U') IS NULL
BEGIN

CREATE TABLE ExpertDecisionsTestProtocols
(
    [ExpertDecisionId] INT NOT NULL,
	[TestProtocolId] INT NOT NULL,
    CONSTRAINT PK_ExpertDecisionsTestProtocols PRIMARY KEY (ExpertDecisionId, TestProtocolId),
    CONSTRAINT FK_ExpertDecisionsTestProtocols_ExpertDecisionId FOREIGN KEY (ExpertDecisionId)
		REFERENCES ExpertDecisions(Id),
	CONSTRAINT FK_ExpertDecisionsTestProtocols_TestProtocolId FOREIGN KEY (TestProtocolId)
		REFERENCES TestProtocols(Id)
)

END