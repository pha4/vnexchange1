USE [aspnet-vnexchange1-92bcff6c-24d8-4a56-8f12-957817bb64cd]
GO

/****** Object: Table [dbo].[ItemType] Script Date: 5/19/2017 10:54:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ItemType] (
    [ItemTypeId]          INT            IDENTITY (1, 1) NOT NULL,
    [ItemId]              INT            NULL,
    [ItemTypeDescription] NVARCHAR (MAX) NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_ItemType_ItemId]
    ON [dbo].[ItemType]([ItemId] ASC);


GO
ALTER TABLE [dbo].[ItemType]
    ADD CONSTRAINT [PK_ItemType] PRIMARY KEY CLUSTERED ([ItemTypeId] ASC);


GO
ALTER TABLE [dbo].[ItemType]
    ADD CONSTRAINT [FK_ItemType_Item_ItemId] FOREIGN KEY ([ItemId]) REFERENCES [dbo].[Item] ([ItemId]);


