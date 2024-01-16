IF OBJECT_ID(N'TechRegsParagraphs', N'U') IS NULL
BEGIN

CREATE TABLE TechRegsParagraphs
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[TechRegId] INT NOT NULL,
	[Paragraphs] NVARCHAR(256) NULL,
    CONSTRAINT FK_TechRegsParagraphsTechRegs_TechRegId FOREIGN KEY (TechRegId)
	REFERENCES TechRegs(Id)
)

END

IF OBJECT_ID(N'ApplicationsTechRegsParagraphs', N'U') IS NULL
BEGIN

CREATE TABLE ApplicationsTechRegsParagraphs
(
	[ApplicationId] INT NOT NULL,
	[TechRegParagraphsId] INT NOT NULL,
    CONSTRAINT PK_ApplicationsTechRegsParagraphs PRIMARY KEY (ApplicationId, TechRegParagraphsId),
    CONSTRAINT FK_ApplicationsTechRegsParagraphs_ApplicationId FOREIGN KEY (ApplicationId)
		REFERENCES Applications(Id),
	CONSTRAINT FK_ApplicationsTechRegsParagraphs_TechRegParagraphsId FOREIGN KEY (TechRegParagraphsId)
		REFERENCES TechRegsParagraphs(Id)
)

END

IF OBJECT_ID(N'GovStandardsParagraphs', N'U') IS NULL
BEGIN

CREATE TABLE GovStandardsParagraphs
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[GovStandardId] INT NOT NULL,
	[Paragraphs] NVARCHAR(256) NULL,
    CONSTRAINT FK_GovStandardsParagraphsGovStandards_GovStandardId FOREIGN KEY (GovStandardId)
	REFERENCES GovStandards(Id)
)

END

IF OBJECT_ID(N'ApplicationsGovStandardsParagraphs', N'U') IS NULL
BEGIN

CREATE TABLE ApplicationsGovStandardsParagraphs
(
	[ApplicationId] INT NOT NULL,
	[GovStandardParagraphsId] INT NOT NULL,
    CONSTRAINT PK_ApplicationsGovStandardsParagraphs PRIMARY KEY (ApplicationId, GovStandardParagraphsId),
    CONSTRAINT FK_ApplicationsGovStandardsParagraphs_ApplicationId FOREIGN KEY (ApplicationId)
		REFERENCES Applications(Id),
	CONSTRAINT FK_ApplicationsGovStandardsParagraphs_GovStandardParagraphsId FOREIGN KEY (GovStandardParagraphsId)
		REFERENCES GovStandardsParagraphs(Id)
)

END