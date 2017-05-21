USE [aspnet-vnexchange1-92bcff6c-24d8-4a56-8f12-957817bb64cd]
GO

/****** Object: Table [dbo].[ItemImage] Script Date: 5/19/2017 10:54:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ItemImage] (
    [ItemImageId] INT            IDENTITY (1, 1) NOT NULL,
    [ImagePath]   NVARCHAR (MAX) NULL,
    [ItemId]      INT            NOT NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_ItemImage_ItemId]
    ON [dbo].[ItemImage]([ItemId] ASC);


GO
ALTER TABLE [dbo].[ItemImage]
    ADD CONSTRAINT [PK_ItemImage] PRIMARY KEY CLUSTERED ([ItemImageId] ASC);


GO
ALTER TABLE [dbo].[ItemImage]
    ADD CONSTRAINT [FK_ItemImage_Item_ItemId] FOREIGN KEY ([ItemId]) REFERENCES [dbo].[Item] ([ItemId]) ON DELETE CASCADE;


