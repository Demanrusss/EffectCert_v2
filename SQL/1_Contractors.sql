IF OBJECT_ID(N'Addresses', N'U') IS NULL
BEGIN

CREATE TABLE Addresses
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Country] NVARCHAR(128) NOT NULL, 
	[Index] NVARCHAR(16) NULL,
	[AddressStr] NVARCHAR(256) NULL
)

END

IF OBJECT_ID(N'AssessBodies', N'U') IS NULL
BEGIN

CREATE TABLE AssessBodies
(
	[Id] INT NOT NULL PRIMARY KEY,
    [Name] NVARCHAR(256) NOT NULL,
    [ShortName] NVARCHAR(256) NOT NULL,
    [AddressId] INT NOT NULL,
    [ContractorLegalId] INT NOT NULL,
    [AttestateId] INT NOT NULL
)

END

IF OBJECT_ID(N'AssessBodyEmployees', N'U') IS NULL
BEGIN

CREATE TABLE AssessBodyEmployees
(
	[Id] INT NOT NULL PRIMARY KEY,
	[ContractorLegalEmployeeId] INT NOT NULL,
    [Position] NVARCHAR(128) NOT NULL,
    [ExpertAuditorOrientation] NVARCHAR(256) NULL
)

END

IF OBJECT_ID(N'BankAccounts', N'U') IS NULL
BEGIN

CREATE TABLE BankAccounts
(
	[Id] INT NOT NULL PRIMARY KEY,
	[IIK] NVARCHAR(20) NOT NULL, 
	[BIK] NVARCHAR(8) NOT NULL,
	[BankName] NVARCHAR(128) NOT NULL
)

END

IF OBJECT_ID(N'ContractorIndividuals', N'U') IS NULL
BEGIN

CREATE TABLE ContractorIndividuals
(
	[Id] INT NOT NULL PRIMARY KEY,
	[LastName] NVARCHAR(32) NOT NULL, 
	[FirstName] NVARCHAR(32) NOT NULL,
	[MiddleName] NVARCHAR(32) NULL,
	[IIN] NVARCHAR(12) NULL
)

END

IF OBJECT_ID(N'ContractorLegals', N'U') IS NULL
BEGIN

CREATE TABLE ContractorLegals
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(256) NOT NULL, 
	[ShortName] NVARCHAR(256) NOT NULL,
	[BIN] NVARCHAR(12) NULL,
	[RegAddressId] INT NOT NULL,
	[FactAddressId] INT NOT NULL,
	[BankAccountId] INT NULL
)

END

IF OBJECT_ID(N'ContractorLegalEmployees', N'U') IS NULL
BEGIN

CREATE TABLE ContractorLegalEmployees
(
	[Id] INT NOT NULL PRIMARY KEY,
	[ContractorIndividualId] INT NOT NULL, 
	[Position] NVARCHAR(128) NOT NULL,
	[IsManager] BIT NOT NULL
)

END

IF OBJECT_ID(N'Laboratories', N'U') IS NULL
BEGIN

CREATE TABLE Laboratories
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(256) NOT NULL, 
	[ShortName] NVARCHAR(256) NOT NULL,
	[ContractorLegalId] INT NOT NULL,
	[AttestateId] INT NULL
)

END

IF OBJECT_ID(N'LaboratoryEmployees', N'U') IS NULL
BEGIN

CREATE TABLE LaboratoryEmployees
(
	[Id] INT NOT NULL PRIMARY KEY,
	[ContractorLegalEmployeeId] INT NOT NULL, 
	[Position] NVARCHAR(128) NOT NULL
)

END