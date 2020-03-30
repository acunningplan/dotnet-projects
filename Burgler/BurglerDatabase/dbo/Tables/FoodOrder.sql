CREATE TABLE [dbo].[FoodOrder] (
    [FoodOrderId] UNIQUEIDENTIFIER NOT NULL,
    [Quantity]    INT              NOT NULL,
    [OrderID]     UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_FoodOrder] PRIMARY KEY CLUSTERED ([FoodOrderId] ASC),
    CONSTRAINT [FK_FoodOrder_Orders_OrderID] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Orders] ([OrderID])
);


GO
CREATE NONCLUSTERED INDEX [IX_FoodOrder_OrderID]
    ON [dbo].[FoodOrder]([OrderID] ASC);

