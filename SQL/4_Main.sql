IF OBJECT_ID(N'ActionPlans', N'U') IS NULL
BEGIN

CREATE TABLE ActionPlans
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Number] NVARCHAR(32) NOT NULL,
	[Date] DATETIME NOT NULL,
    [ApplicationId] INT NOT NULL,
    [AppAnalizeExpertId] INT NOT NULL,
    [ConformityAssessBodyHeadId] INT NOT NULL,
    [SelectProductEmployeeId] INT NULL,
    [ResultsAnalizeExpertId] INT NULL,
    [RegDocumentEmployeeId] INT NULL
)

END

IF OBJECT_ID(N'AppDecisions', N'U') IS NULL
BEGIN

CREATE TABLE AppDecisions
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Number] NVARCHAR(32) NOT NULL,
	[Date] DATETIME NOT NULL,
    [ApplicationId] INT NOT NULL,
    [ActionPlanId] INT NOT NULL,
    [ProductionAnalyzeAssessBodyId] INT NULL,
    [ProductionAnalyzeLaboratoryId] INT NULL,
    [InspectionAssessBodyId] INT NULL,
    [InspectionLaboratoryId] INT NULL,
    [InspectionPeriod] NVARCHAR(32) NULL,
    [SchemaAnotherId] INT NULL,
    [DeclarationNumber] NVARCHAR(32) NULL,
    [DeclarationDate] DATETIME NULL,
    [AssessContractNumber] NVARCHAR(32) NULL,
    [AssessContractDate] DATETIME NULL
)

END

IF OBJECT_ID(N'Applications', N'U') IS NULL
BEGIN

CREATE TABLE Applications
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Number] NVARCHAR(32) NOT NULL,
    [Date] DATETIME NOT NULL,
    [AssessBodyId] INT NOT NULL,
    [ContractorLegalId] INT NOT NULL,
	[ElectronicNumber] NVARCHAR(32) NULL,
    [ElectronicDate] DATETIME NULL,
    [SchemaId] INT NOT NULL
)

END

IF OBJECT_ID(N'ExpertDecisions', N'U') IS NULL
BEGIN

CREATE TABLE ExpertDecisions
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Number] NVARCHAR(32) NOT NULL,
	[Date] DATETIME NOT NULL,
    [ApplicationId] INT NOT NULL,
    [ConformityMarkInfo] NVARCHAR(128) NULL,
    [ExpertId] INT NOT NULL,
    [ValidDate] DATETIME NULL,
    [DocsAnalizeExpertId] INT NULL,
    [DocsAnalizeExpertSignDate] DATETIME NULL
)

END

IF OBJECT_ID(N'IssueDecisions', N'U') IS NULL
BEGIN

CREATE TABLE IssueDecisions
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Number] NVARCHAR(32) NOT NULL,
	[Date] DATETIME NOT NULL,
    [ApplicationId] INT NOT NULL,
    [CertificateId] INT NULL,
    [ExpertDecisionId] INT NOT NULL,
    [DeclarationId] INT NULL,
    [RecommendationId] INT NOT NULL
)

END

IF OBJECT_ID(N'Recommendations', N'U') IS NULL
BEGIN

CREATE TABLE Recommendations
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Number] NVARCHAR(32) NOT NULL,
	[Date] DATETIME NOT NULL,
    [ApplicationId] INT NOT NULL,
    [AppDecisionId] INT NOT NULL,
    [SelectProductsActId] INT NOT NULL,
    [ExpertDecisionId] INT NOT NULL
)

END

IF OBJECT_ID(N'SelectProductsActs', N'U') IS NULL
BEGIN

CREATE TABLE SelectProductsActs
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Number] NVARCHAR(32) NOT NULL,
	[Date] DATETIME NOT NULL,
    [ApplicationId] INT NOT NULL,
    [ActionPlanId] INT NOT NULL,
    [AddressId] INT NOT NULL,
    [SupplierId] INT NOT NULL,
    [StorageCondition] NVARCHAR(128) NOT NULL,
    [PackageType] NVARCHAR(128) NOT NULL,
    [ControlSamplesStorageTime] INT NOT NULL,
    [ControlSamplesQuantity] NVARCHAR(32) NOT NULL
)

END