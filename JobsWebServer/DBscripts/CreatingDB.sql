--Use master

--Create Database IJobDB

--Go

----Creating dummy table and insertion

--Use IJobDB

--Go

--Create Table Users (

--ID int Identity primary key,

--Email nvarchar(100) not null,

--FirstName nvarchar(30) not null,

--LastName nvarchar(30) not null,

--UserPswd nvarchar(30) not null,

--CONSTRAINT UC_Email UNIQUE(Email)

--)

--Go

--INSERT INTO Users VALUES
--('kuku@kuku.com','kuku','kaka','1234');

--GO

--SELECT * FROM Users


--Finished DB

USE master

CREATE DATABASE IJobDB 

GO

USE master	

USE IJobDB

Go

CREATE TABLE Employee(
    EmployeeID INT PRIMARY KEY IDENTITY(1000,1) NOT NULL ,
    FirstName VARCHAR(255) NOT NULL,
    LastName VARCHAR(255) NOT NULL,
    Nickname VARCHAR(255) NOT NULL,
    Employeed bit NOT NULL,
    Birthday DATE NOT NULL,
    Gender VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    RatingID INT NOT NULL
);

CREATE UNIQUE INDEX EmailIndex
on Employee (Email);

CREATE UNIQUE INDEX LastNameIndex
on Employee (LastName);


CREATE TABLE Employer(
    EmployerID INT PRIMARY KEY IDENTITY(1000,1) NOT NULL ,
    FirstName VARCHAR(255) NOT NULL,
    LastName VARCHAR(255) NOT NULL,
    Nickname VARCHAR(255) NOT NULL,
    Birthday DATE NOT NULL,
    IsEmployee bit NOT NULL,
    Gender VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    IsAdmin bit NOT NULL
);

CREATE UNIQUE INDEX LastNameIndex
on Employer (LastName);

CREATE UNIQUE INDEX EmailIndex
on Employer (Email);

CREATE TABLE JobOffer(
    JobOfferID INT PRIMARY KEY IDENTITY(100,2) NOT NULL ,
    CategoryID INT NOT NULL,
    EmployerID INT NOT NULL,
    Applied bit NOT NULL,
    Topic TEXT NOT NULL,
    Content TEXT NOT NULL,
    IsPrivate bit NOT NULL,
    JobOfferStatusID INT NOT NULL,
    CommentID INT NOT NULL
);

CREATE UNIQUE INDEX JobOfferStatusIDIndex
on JobOffer (JobOfferStatusID);

CREATE TABLE Categories(
    CategoryID INT PRIMARY KEY IDENTITY(1,1) NOT NULL ,
    CategoryName INT NOT NULL
);

CREATE UNIQUE INDEX CategoryNameIndex
on Categories (CategoryName);

CREATE TABLE Comment(
    CommentID INT PRIMARY KEY IDENTITY(500,1) NOT NULL ,
    Content INT NOT NULL,
    JobOfferID INT NOT NULL,
    JobRequestID INT NOT NULL,
    LikeAmount INT NOT NULL
);

CREATE UNIQUE INDEX JobOfferIDIndex
on Comment (JobOfferID);

CREATE TABLE Rating(
    ID INT PRIMARY KEY IDENTITY(1000,1) NOT NULL ,
    Rating INT NOT NULL
);

CREATE TABLE JobRequest(
    JobRequestID INT PRIMARY KEY IDENTITY(100,1) NOT NULL ,
    Topic VARCHAR(255) NOT NULL,
    Content VARCHAR(255) NOT NULL,
    IsApplied bit NOT NULL,
    EmployeeID INT NOT NULL,
    EmployerID INT NOT NULL,
    CommentID INT NOT NULL,
    CategoryID INT NOT NULL,
    JobOfferStatusID INT NOT NULL
);

CREATE UNIQUE INDEX EmployeeIDIndex
on JobRequest (EmployeeID);


CREATE TABLE ChatBox(
    PhraseID INT PRIMARY KEY IDENTITY(50,1) NOT NULL,
    Content VARCHAR(255) NOT NULL
);

CREATE TABLE InterstedInRequest(
    ID INT PRIMARY KEY IDENTITY(10,1) NOT NULL ,
    JobRequestID INT NOT NULL,
    EmployerID INT NOT NULL
);

CREATE TABLE JobApplication(
    AppID INT PRIMARY KEY IDENTITY(1000,1) NOT NULL ,
    EmployeeID INT NOT NULL,
    JobOfferID INT NOT NULL,
    AppStatus int NOT NULL,
    EmployerID INT NOT NULL
);

CREATE UNIQUE INDEX AppStatusIndex
on JobApplication (AppStatus);


CREATE TABLE JobApplicationStatus(
    StatusID INT PRIMARY KEY IDENTITY(1000,1) NOT NULL ,
    StatusName VARCHAR(255) NOT NULL
);

CREATE UNIQUE INDEX StatusNameIndex
on JobApplicationStatus (StatusName);

CREATE TABLE JobOfferStatus(
    JobOfferStatusID INT PRIMARY KEY IDENTITY(1000,1) NOT NULL ,
    JobOfferStatus VARCHAR(255) NOT NULL
);

CREATE UNIQUE INDEX JobOfferStatusIndex
on JobOfferStatus (JobOfferStatus);


USE IJobDB

ALTER TABLE
    JobApplication ADD CONSTRAINT jobapplication_employeeid_foreign FOREIGN KEY(EmployeeID) REFERENCES Employee(EmployeeID);
ALTER TABLE
    Employee ADD CONSTRAINT employee_ratingid_foreign FOREIGN KEY(RatingID) REFERENCES Rating(ID);
ALTER TABLE
    JobApplication ADD CONSTRAINT jobapplication_jobofferid_foreign FOREIGN KEY(JobOfferID) REFERENCES JobOffer(JobOfferID);
ALTER TABLE
    JobOffer ADD CONSTRAINT joboffer_employerid_foreign FOREIGN KEY(EmployerID) REFERENCES Employer(EmployerID);
ALTER TABLE
    JobOffer ADD CONSTRAINT joboffer_commentid_foreign FOREIGN KEY(CommentID) REFERENCES Comment(CommentID);
ALTER TABLE
    JobOffer ADD CONSTRAINT joboffer_categoryid_foreign FOREIGN KEY(CategoryID) REFERENCES Categories(CategoryID);
ALTER TABLE
    JobRequest ADD CONSTRAINT jobrequest_categoryid_foreign FOREIGN KEY(CategoryID) REFERENCES Categories(CategoryID);
ALTER TABLE
    JobRequest ADD CONSTRAINT jobrequest_commentid_foreign FOREIGN KEY(CommentID) REFERENCES Comment(CommentID);
ALTER TABLE
    JobRequest ADD CONSTRAINT jobrequest_jobofferstatusid_foreign FOREIGN KEY(JobOfferStatusID) REFERENCES JobOfferStatus(JobOfferStatusID);
ALTER TABLE
    InterstedInRequest ADD CONSTRAINT interstedinrequest_jobrequestid_foreign FOREIGN KEY(JobRequestID) REFERENCES JobRequest(JobRequestID);
ALTER TABLE
    JobApplication ADD CONSTRAINT jobapplication_employerid_foreign FOREIGN KEY(EmployerID) REFERENCES Employer(EmployerID);
ALTER TABLE
    JobApplication ADD CONSTRAINT jobapplication_appstatus_foreign FOREIGN KEY(AppStatus) REFERENCES JobApplicationStatus(StatusID);
ALTER TABLE
    JobOffer ADD CONSTRAINT joboffer_jobofferstatusid_foreign FOREIGN KEY(JobOfferStatusID) REFERENCES JobOfferStatus(JobOfferStatusID);