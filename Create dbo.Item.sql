USE [aspnet-vnexchange1-92bcff6c-24d8-4a56-8f12-957817bb64cd]
GO

/****** Object: Table [dbo].[Item] Script Date: 5/19/2017 10:53:46 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Item] (
    [ItemId]           INT             IDENTITY (1, 1) NOT NULL,
    [ItemDate]         DATETIME2 (7)   NOT NULL,
    [ItemDescription]  NVARCHAR (MAX)  NULL,
    [ItemManufacturer] NVARCHAR (MAX)  NULL,
    [ItemOwner]        INT             NOT NULL,
    [ItemPrice]        DECIMAL (18, 2) NOT NULL,
    [ItemTitle]        NVARCHAR (MAX)  NULL
);


