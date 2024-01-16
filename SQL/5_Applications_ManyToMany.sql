IF OBJECT_ID(N'ApplicationsContracts', N'U') IS NULL
BEGIN

CREATE TABLE ApplicationsContracts
(
    [ApplicationId] INT NOT NULL,
	[ContractId] INT NOT NULL,
    CONSTRAINT PK_ApplicationsContracts PRIMARY KEY (ApplicationId, ContractId),
    CONSTRAINT FK_ApplicationsContracts_ApplicationId FOREIGN KEY (ApplicationId)
		REFERENCES Applications(Id),
	CONSTRAINT FK_ApplicationsContracts_ContractId FOREIGN KEY (ContractId)
		REFERENCES Contracts(Id)
)

END

IF OBJECT_ID(N'ApplicationsGTDs', N'U') IS NULL
BEGIN

CREATE TABLE ApplicationsGTDs
(
	[ApplicationId] INT NOT NULL,
	[GTDId] INT NOT NULL,
    CONSTRAINT PK_ApplicationsGTDs PRIMARY KEY (ApplicationId, GTDId),
    CONSTRAINT FK_ApplicationsGTDs_ApplicationId FOREIGN KEY (ApplicationId)
		REFERENCES Applications(Id),
	CONSTRAINT FK_ApplicationsGTDs_GTDId FOREIGN KEY (GTDId)
		REFERENCES GTDs(Id)
)

END

IF OBJECT_ID(N'ApplicationsInvoices', N'U') IS NULL
BEGIN

CREATE TABLE ApplicationsInvoices
(
	[ApplicationId] INT NOT NULL,
	[InvoiceId] INT NOT NULL,
    CONSTRAINT PK_ApplicationsInvoices PRIMARY KEY (ApplicationId, InvoiceId),
    CONSTRAINT FK_ApplicationsInvoices_ApplicationId FOREIGN KEY (ApplicationId)
		REFERENCES Applications(Id),
	CONSTRAINT FK_ApplicationsInvoices_InvoiceId FOREIGN KEY (InvoiceId)
		REFERENCES Invoices(Id)
)

END

IF OBJECT_ID(N'ApplicationsManufacturerStandards', N'U') IS NULL
BEGIN

CREATE TABLE ApplicationsManufacturerStandards
(
	[ApplicationId] INT NOT NULL,
	[ManufacturerStandardId] INT NOT NULL,
    CONSTRAINT PK_ApplicationsManufacturerStandards PRIMARY KEY (ApplicationId, ManufacturerStandardId),
    CONSTRAINT FK_ApplicationsManufacturerStandards_ApplicationId FOREIGN KEY (ApplicationId)
		REFERENCES Applications(Id),
	CONSTRAINT FK_ApplicationsManufacturerStandards_ManufacturerStandardId FOREIGN KEY (ManufacturerStandardId)
		REFERENCES ManufacturerStandards(Id)
)

END

IF OBJECT_ID(N'ApplicationsProducts', N'U') IS NULL
BEGIN

CREATE TABLE ApplicationsProducts
(
	[ApplicationId] INT NOT NULL,
	[ProductId] INT NOT NULL,
    CONSTRAINT PK_ApplicationsProducts PRIMARY KEY (ApplicationId, ProductId),
    CONSTRAINT FK_ApplicationsProducts_ApplicationId FOREIGN KEY (ApplicationId)
		REFERENCES Applications(Id),
	CONSTRAINT FK_ApplicationsProducts_ProductId FOREIGN KEY (ProductId)
		REFERENCES Products(Id)
)

END

IF OBJECT_ID(N'ApplicationsProductQuantities', N'U') IS NULL
BEGIN

CREATE TABLE ApplicationsProductQuantities
(
	[ApplicationId] INT NOT NULL,
	[ProductQuantityId] INT NOT NULL,
    CONSTRAINT PK_ApplicationsProductQuantities PRIMARY KEY (ApplicationId, ProductQuantityId),
    CONSTRAINT FK_ApplicationsProductQuantities_ApplicationId FOREIGN KEY (ApplicationId)
		REFERENCES Applications(Id),
	CONSTRAINT FK_ApplicationsProductQuantities_ProductQuantityId FOREIGN KEY (ProductQuantityId)
		REFERENCES ProductQuantities(Id)
)

END

IF OBJECT_ID(N'ApplicationsRequirements', N'U') IS NULL
BEGIN

CREATE TABLE ApplicationsRequirements
(
	[ApplicationId] INT NOT NULL,
	[RequirementId] INT NOT NULL,
    CONSTRAINT PK_ApplicationsRequirements PRIMARY KEY (ApplicationId, RequirementId),
    CONSTRAINT FK_ApplicationsRequirements_ApplicationId FOREIGN KEY (ApplicationId)
		REFERENCES Applications(Id),
	CONSTRAINT FK_ApplicationsRequirements_RequirementId FOREIGN KEY (RequirementId)
		REFERENCES Requirements(Id)
)

END