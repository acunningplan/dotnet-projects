CREATE TABLE [dbo].[Orders] (
    [OrderID]            UNIQUEIDENTIFIER NOT NULL,
    [OrderedAt]          DATETIME2 (7)    NOT NULL,
    [ReadyAt]            DATETIME2 (7)    NOT NULL,
    [FoodTakenAt]        DATETIME2 (7)    NOT NULL,
    [Cancelled]          BIT              NOT NULL,
    [UserId]             NVARCHAR (MAX)   NULL,
    [FurtherDescription] NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([OrderID] ASC)
);

