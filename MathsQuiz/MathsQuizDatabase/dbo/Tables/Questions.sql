CREATE TABLE [dbo].[Questions] (
    [QuestionID]     NVARCHAR (450) NOT NULL,
    [QuestionString] NVARCHAR (40)  NOT NULL,
    CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED ([QuestionID] ASC)
);

