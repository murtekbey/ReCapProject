CREATE TABLE [dbo].[Users] (
    [UserId]           INT             IDENTITY (1, 1) NOT NULL,
    [FirstName]    VARCHAR (50)    NOT NULL,
    [LastName]     VARCHAR (50)    NOT NULL,
    [Email]        VARCHAR (50)    NOT NULL,
    [PasswordHash] VARBINARY (500) NOT NULL,
    [PasswordSalt] VARBINARY (500) NOT NULL,
    [Status]       BIT             NOT NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);

CREATE TABLE [dbo].[OperationClaims] (
    [OperationClaimId]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (250) NOT NULL,
    PRIMARY KEY CLUSTERED ([OperationClaimId] ASC)
);

CREATE TABLE [dbo].[UserOperationClaims] (
    [UserOperationClaimId]               INT IDENTITY (1, 1) NOT NULL,
    [UserId]           INT NOT NULL,
    [OperationClaimId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([UserOperationClaimId] ASC),
    FOREIGN KEY ([OperationClaimId]) REFERENCES [dbo].[OperationClaims] ([OperationClaimId]),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId])
);

CREATE TABLE Customers(
    CustomerId INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
    UserId INT UNIQUE NOT NULL,
    CompanyName NVARCHAR (100) NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

CREATE TABLE Colors(
	ColorId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ColorName NVARCHAR (50) NOT NULL,
);

CREATE TABLE Brands(
	BrandId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	BrandName NVARCHAR (50) NOT NULL,
);

CREATE TABLE Cars(
	CarId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	BrandId INT NOT NULL,
	ColorId INT NOT NULL,
	ModelYear INT NOT NULL,
	DailyPrice DECIMAL NOT NULL,
	Descriptions NTEXT NULL,
	FOREIGN KEY (ColorID) REFERENCES Colors(ColorID),
	FOREIGN KEY (BrandID) REFERENCES Brands(BrandID)
);

CREATE TABLE Rentals(
    RentalId INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
    CarId INT  NOT NULL,
    CustomerId INT  NOT NULL,
    RentDate DATE NOT NULL,
    ReturnDate DATE NULL,
    FOREIGN KEY (CarId) REFERENCES Cars(CarId),
    FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId)
);

CREATE TABLE [dbo].[CarImages] (
    [CarImageId] INT            IDENTITY (1, 1) NOT NULL,
    [CarId]      INT            NOT NULL,
    [ImagePath]  NVARCHAR (MAX) NOT NULL,
    [Date]       DATE           NOT NULL,
    [IsMain] BIT NOT NULL, 
    PRIMARY KEY CLUSTERED ([CarImageId] ASC),
    FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([CarId])
);

CREATE TABLE [dbo].[Payments] (
    [PaymentId]   INT          IDENTITY (1, 1) NOT NULL,
    [CustomerId]  INT          NOT NULL,
    [CarId]       INT          NOT NULL,
    [Amount]      DECIMAL (18) NOT NULL,
    [PaymentDate] DATE         NOT NULL,
    PRIMARY KEY CLUSTERED ([PaymentId] ASC),
    FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([CustomerId]),
    FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([CarId])
);