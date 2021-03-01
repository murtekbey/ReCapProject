﻿CREATE TABLE Colors(
	ColorId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ColorName NVARCHAR (50) NOT NULL,
);

CREATE TABLE Brands(
	BrandId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	BrandName NVARCHAR (50) NOT NULL,
);

CREATE TABLE Cars(
	CarID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	BrandId INT NOT NULL,
	ColorId INT NOT NULL,
	ModelYear INT NOT NULL,
	DailyPrice DECIMAL NOT NULL,
	Descriptions NTEXT NULL,
	FOREIGN KEY (ColorID) REFERENCES Colors(ColorID),
	FOREIGN KEY (BrandID) REFERENCES Brands(BrandID)
);

CREATE TABLE Customers(
    Id INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
    UserId INT UNIQUE NOT NULL,
    CompanyName NVARCHAR (100) NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

CREATE TABLE Rentals(
    Id INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
    CarId INT  NOT NULL,
    CustomerId INT  NOT NULL,
    RentDate DATE NOT NULL,
    ReturnDate DATE NULL,
    FOREIGN KEY (CarId) REFERENCES Cars(Id),
    FOREIGN KEY (CustomerId) REFERENCES Customers(UserId)
);

CREATE TABLE CarImages (
    Id INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
    CarId INT NOT NULL,
    ImagePath NVARCHAR (MAX) NOT NULL,
    Date DATE NOT NULL,
    FOREIGN KEY (CarId) REFERENCES Cars(Id)
);

CREATE TABLE [dbo].[Users] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [FirstName]    VARCHAR (50)    NOT NULL,
    [LastName]     VARCHAR (50)    NOT NULL,
    [Email]        VARCHAR (50)    NOT NULL,
    [PasswordHash] VARBINARY (500) NOT NULL,
    [PasswordSalt] VARBINARY (500) NOT NULL,
    [Status]       BIT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[OperationClaims] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (250) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[UserOperationClaims] (
    [Id]               INT IDENTITY (1, 1) NOT NULL,
    [UserId]           INT NOT NULL,
    [OperationClaimId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([OperationClaimId]) REFERENCES [dbo].[OperationClaims] ([Id]),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);