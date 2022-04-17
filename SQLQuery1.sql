
CREATE DATABASE AdoNet

USE AdoNet

CREATE TABLE Employee(
Id INT PRIMARY KEY IDENTITY,
Fullname NVARCHAR(50)
)

INSERT INTO Employee 
VALUES ('Jale Quliyeva'),
('Ilknur Ezizov')


SELECT * FROM Employee



