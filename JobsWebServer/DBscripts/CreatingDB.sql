Use master

Create Database IJobDB

Go

--Creating dummy table and insertion

Use IJobDB

Go

Create Table Users (

ID int Identity primary key,

Email nvarchar(100) not null,

FirstName nvarchar(30) not null,

LastName nvarchar(30) not null,

UserPswd nvarchar(30) not null,

CONSTRAINT UC_Email UNIQUE(Email)

)

Go

INSERT INTO Users VALUES
('kuku@kuku.com','kuku','kaka','1234');

GO

SELECT * FROM Users