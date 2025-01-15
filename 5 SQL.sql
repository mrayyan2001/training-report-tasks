CREATE TABLE ContactMessages (
    MessageID INT IDENTITY(1, 1) PRIMARY KEY,
    -- Unique identifier for each message, auto-increments starting from 1
    Name NVARCHAR(255) NOT NULL,
    -- Name of the sender
    Email NVARCHAR(255) NOT NULL,
    -- Email address of the sender
    Subject NVARCHAR(255),
    -- Subject of the message (optional)
    Message TEXT NOT NULL,
    -- The content of the message
    SubmittedAt DATETIME2 DEFAULT GETDATE() -- Timestamp when the message was submitted (uses GETDATE() for current timestamp)
);