﻿IF OBJECT_ID(N'CertObjects', N'U') IS NULL
BEGIN

CREATE TABLE CertObjects
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(32) NOT NULL
)

END

IF OBJECT_ID(N'Inconsistences', N'U') IS NULL
BEGIN

CREATE TABLE Inconsistences
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Name] NVARCHAR(128) NOT NULL
)

END

IF OBJECT_ID(N'MeasurementUnits', N'U') IS NULL
BEGIN

CREATE TABLE MeasurementUnits
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(32) NOT NULL,
    [ShortName] NVARCHAR(32) NOT NULL
)

END

IF OBJECT_ID(N'Products', N'U') IS NULL
BEGIN

CREATE TABLE Products
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(128) NOT NULL,
    [GroupName] NVARCHAR(64) NULL,
    [Type] NVARCHAR(64) NULL,
    [TradeMark] NVARCHAR(64) NULL,
    [Model] NVARCHAR(64) NULL,
    [Article] NVARCHAR(64) NULL,
	[ManufacturerId] INT NOT NULL,
	[TNVED] NVARCHAR(10) NOT NULL
)

END

IF OBJECT_ID(N'ProductQuantities', N'U') IS NULL
BEGIN

CREATE TABLE ProductQuantities
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [ProductId] INT NOT NULL,
	[Quantity] REAL NOT NULL,
	[MeasurementUnitId] INT NOT NULL,
	[MadeDate] DATETIME NOT NULL
)

END

IF OBJECT_ID(N'Requirements', N'U') IS NULL
BEGIN

CREATE TABLE Requirements
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(128) NOT NULL
)

END

IF OBJECT_ID(N'Schemas', N'U') IS NULL
BEGIN

CREATE TABLE Schemas
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(8) NOT NULL
)

END

IF OBJECT_ID(N'SelectedSampleQuantities', N'U') IS NULL
BEGIN

CREATE TABLE SelectedSampleQuantities
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ProductQuantityId] INT NOT NULL,
    [Quantity] REAL NOT NULL,
	[MeasurementUnitId] INT NOT NULL
)

END