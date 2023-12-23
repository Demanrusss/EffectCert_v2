IF OBJECT_ID(N'SchemasCertObjects', N'U') IS NULL
BEGIN

CREATE TABLE SchemasCertObjects
(
    [SchemaId] INT NOT NULL,
	[CertObjectId] INT NOT NULL,
    CONSTRAINT PK_SchemasCertObjects PRIMARY KEY (SchemaId, CertObjectId),
    CONSTRAINT FK_SchemasCertObjects_SchemaId FOREIGN KEY (SchemaId)
		REFERENCES Schemas(Id),
	CONSTRAINT FK_SchemasCertObjects_CertObjectId FOREIGN KEY (CertObjectId)
		REFERENCES CertObjects(Id)
)

END
