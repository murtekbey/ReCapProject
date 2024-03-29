﻿USE ReCapProject;

CREATE TABLE [dbo].[Users] (
    [UserId]       INT             IDENTITY (1, 1) NOT NULL,
    [FirstName]    VARCHAR (50)    NOT NULL,
    [LastName]     VARCHAR (50)    NOT NULL,
    [Email]        VARCHAR (50)    NOT NULL,
    [PasswordHash] VARBINARY (500) NOT NULL,
    [PasswordSalt] VARBINARY (500) NOT NULL,
    [Status]       BIT             NOT NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);

CREATE TABLE [dbo].[OperationClaims] (
    [OperationClaimId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]             VARCHAR (250) NOT NULL,
    PRIMARY KEY CLUSTERED ([OperationClaimId] ASC)
);

CREATE TABLE [dbo].[UserOperationClaims] (
    [UserOperationClaimId] INT IDENTITY (1, 1) NOT NULL,
    [UserId]               INT NOT NULL,
    [OperationClaimId]     INT NOT NULL,
    PRIMARY KEY CLUSTERED ([UserOperationClaimId] ASC),
    FOREIGN KEY ([OperationClaimId]) REFERENCES [dbo].[OperationClaims] ([OperationClaimId]),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId])
);

CREATE TABLE [dbo].[Brands] (
    [BrandId]   INT           IDENTITY (1, 1) NOT NULL,
    [BrandName] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([BrandId] ASC)
);

CREATE TABLE [dbo].[Colors] (
    [ColorId]   INT           IDENTITY (1, 1) NOT NULL,
    [ColorName] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([ColorId] ASC)
);

CREATE TABLE [dbo].[Cars] (
    [CarId]        INT          IDENTITY (1, 1) NOT NULL,
    [BrandId]      INT          NOT NULL,
    [ColorId]      INT          NOT NULL,
    [ModelYear]    INT          NOT NULL,
    [DailyPrice]   DECIMAL (18) NOT NULL,
    [Description]  NTEXT        NULL,
    [FindeksScore] INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([CarId] ASC),
    FOREIGN KEY ([ColorId]) REFERENCES [dbo].[Colors] ([ColorId]),
    FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brands] ([BrandId])
);

CREATE TABLE [dbo].[CarImages] (
    [CarImageId] INT            IDENTITY (1, 1) NOT NULL,
    [CarId]      INT            NOT NULL,
    [ImagePath]  NVARCHAR (MAX) NOT NULL,
    [Date]       DATE           NOT NULL,
    [IsMain]     BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([CarImageId] ASC),
    FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([CarId])
);

CREATE TABLE [dbo].[CreditCard] (
    [CreditCardId] INT           IDENTITY (1, 1) NOT NULL,
    [UserId]       INT           NOT NULL,
    [CardName]     VARCHAR (250) NOT NULL,
    [CardNumber]   VARCHAR (20)  NOT NULL,
    [Cvv]          VARCHAR (10)  NOT NULL,
    PRIMARY KEY CLUSTERED ([CreditCardId] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId])
);

CREATE TABLE [dbo].[Customers] (
    [CustomerId]  INT            IDENTITY (1, 1) NOT NULL,
    [UserId]      INT            NOT NULL,
    [CompanyName] NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([CustomerId] ASC),
    UNIQUE NONCLUSTERED ([UserId] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId])
);

CREATE TABLE [dbo].[FindeksScores] (
    [FindeksScoreId] INT IDENTITY (1, 1) NOT NULL,
    [CustomerId]     INT NOT NULL,
    [Score]          INT NOT NULL,
    PRIMARY KEY CLUSTERED ([FindeksScoreId] ASC),
    FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([CustomerId])
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

CREATE TABLE [dbo].[Rentals] (
    [RentalId]   INT  IDENTITY (1, 1) NOT NULL,
    [CarId]      INT  NOT NULL,
    [CustomerId] INT  NOT NULL,
    [RentDate]   DATE NOT NULL,
    [ReturnDate] DATE NULL,
    PRIMARY KEY CLUSTERED ([RentalId] ASC),
    FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([CarId]),
    FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([CustomerId])
);