CREATE TABLE Feedback (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Content NVARCHAR(MAX) NOT NULL,
    Rating INT CHECK (Rating >= 1 AND Rating <= 5),
    CreatedAt DATETIME2 NOT NULL,
    UpdatedAt DATETIME2 NULL,
    EventId INT NOT NULL 
);
