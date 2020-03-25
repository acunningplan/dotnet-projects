CREATE TABLE [dbo].[Orders] (
    [OrderID]          INT           IDENTITY (1, 1) NOT NULL,
    [OrderDescription] NVARCHAR (40) NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([OrderID] ASC)
);

