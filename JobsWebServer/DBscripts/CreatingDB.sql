--Finished DB

USE master

CREATE DATABASE IJobDB 

GO

USE master	

USE IJobDB

Go


CREATE TABLE Employees(
    EmployeeID INT PRIMARY KEY IDENTITY(1000,1) NOT NULL ,
    UserID INT NOT NULL,
    Employeed bit NOT NULL,
    RatingID INT NOT NULL
);

CREATE UNIQUE INDEX UserIDIndex
on Employees (UserID);


CREATE TABLE Employers(
    EmployerID INT PRIMARY KEY NOT NULL ,
    UserID INT NOT NULL,
    IsEmployee bit NOT NULL
);

CREATE UNIQUE INDEX UserIDIndex
on Employers (UserID);

CREATE TABLE JobOffers(
    JobOfferID INT PRIMARY KEY NOT NULL ,
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
on JobOffers (JobOfferStatusID);

CREATE UNIQUE INDEX EmployerIDIndex
on JobOffers (EmployerID);

CREATE TABLE Categories(
    CategoryID INT PRIMARY KEY IDENTITY(1,1) NOT NULL ,
    CategoryName INT NOT NULL
);

CREATE UNIQUE INDEX CategoryNameIndex
on Categories (CategoryName);

CREATE TABLE Comments(
    CommentID INT PRIMARY KEY IDENTITY(10000,1) NOT NULL ,
    Content INT NOT NULL,
    JobOfferID INT NOT NULL,
    JobRequestID INT NOT NULL,
    Likes INT NOT NULL
);

CREATE UNIQUE INDEX JobOfferIDIndex
on Comments (JobOfferID);

CREATE TABLE Rating(
    RatingID INT PRIMARY KEY IDENTITY(1,1) NOT NULL ,
    Rating INT NOT NULL
);

CREATE TABLE JobRequests(
    JobRequestID INT PRIMARY KEY IDENTITY(10000,1) NOT NULL ,
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
on JobRequests (EmployeeID);

CREATE TABLE ChatBox(
    PhraseID INT PRIMARY KEY IDENTITY(10,1) NOT NULL,
    Content VARCHAR(255) NOT NULL
);

CREATE TABLE InterstedInRequest(
    ID INT PRIMARY KEY IDENTITY(10,1) NOT NULL ,
    JobRequestID INT NOT NULL,
    EmployerID INT NOT NULL
);

CREATE TABLE JobApplications(
    AppID INT PRIMARY KEY IDENTITY(100000,1) NOT NULL ,
    EmployeeID INT NOT NULL,
    JobOfferID INT NOT NULL,
    JobAppStatus INT NOT NULL,
    EmployerID INT NOT NULL
);

CREATE UNIQUE INDEX AppStatusIndex
on JobApplications (JobAppStatus);

CREATE TABLE JobApplicationStatus(
    StatusID INT PRIMARY KEY IDENTITY(1,1) NOT NULL ,
    StatusName VARCHAR(255) NOT NULL
);

CREATE UNIQUE INDEX StatusNameIndex
on JobApplicationStatus (StatusName);


CREATE TABLE JobOfferStatus(
    JobOfferStatusID INT PRIMARY KEY IDENTITY(1,1) NOT NULL ,
    JobOfferStatus VARCHAR(255) NOT NULL
);

CREATE UNIQUE INDEX JobOfferStatusIndex
on JobOfferStatus (JobOfferStatus);

CREATE TABLE Users(
    UserID INT PRIMARY KEY IDENTITY(100000,1) NOT NULL,
    FirstName VARCHAR(255) NOT NULL,
    LastName INT NOT NULL,
    Email INT NOT NULL,
    Pass VARCHAR(255) NOT NULL,
    Nickname INT NOT NULL,
    Birthday INT NOT NULL,
    Gender INT NOT NULL,
    UserTypeID INT NOT NULL
);

CREATE UNIQUE INDEX LastNameIndex
on Users (LastName);

CREATE UNIQUE INDEX EmailIndex
on Users (Email);

CREATE TABLE UserTypes(
    UserTypeID INT PRIMARY KEY IDENTITY(1,1) NOT NULL ,
    UserTypeName VARCHAR(255) NOT NULL
);

USE IJobDB

ALTER TABLE
    JobApplications ADD CONSTRAINT jobapplications_employeeid_foreign FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID);
ALTER TABLE
    Employees ADD CONSTRAINT employees_ratingid_foreign FOREIGN KEY(RatingID) REFERENCES Rating(RatingID);
ALTER TABLE
    JobApplications ADD CONSTRAINT jobapplications_jobofferid_foreign FOREIGN KEY(JobOfferID) REFERENCES JobOffers(JobOfferID);
ALTER TABLE
    JobOffers ADD CONSTRAINT joboffers_employerid_foreign FOREIGN KEY(EmployerID) REFERENCES Employers(EmployerID);
ALTER TABLE
    JobOffers ADD CONSTRAINT joboffers_commentid_foreign FOREIGN KEY(CommentID) REFERENCES Comments(CommentID);
ALTER TABLE
    JobOffers ADD CONSTRAINT joboffers_categoryid_foreign FOREIGN KEY(CategoryID) REFERENCES Categories(CategoryID);
ALTER TABLE
    JobRequests ADD CONSTRAINT jobrequest_categoryid_foreign FOREIGN KEY(CategoryID) REFERENCES Categories(CategoryID);
ALTER TABLE
    JobRequests ADD CONSTRAINT jobrequest_commentid_foreign FOREIGN KEY(CommentID) REFERENCES Comments(CommentID);
ALTER TABLE
    JobRequests ADD CONSTRAINT jobrequest_jobofferstatusid_foreign FOREIGN KEY(JobOfferStatusID) REFERENCES JobOfferStatus(JobOfferStatusID);
ALTER TABLE
    InterstedInRequest ADD CONSTRAINT interstedinrequest_jobrequestid_foreign FOREIGN KEY(JobRequestID) REFERENCES JobRequests(JobRequestID);
ALTER TABLE
    JobApplications ADD CONSTRAINT jobapplications_employerid_foreign FOREIGN KEY(EmployerID) REFERENCES Employers(EmployerID);
ALTER TABLE
    JobApplications ADD CONSTRAINT jobapplications_jobappstatus_foreign FOREIGN KEY(JobAppStatus) REFERENCES JobApplicationStatus(StatusID);
ALTER TABLE
    JobOffers ADD CONSTRAINT joboffer_jobofferstatusid_foreign FOREIGN KEY(JobOfferStatusID) REFERENCES JobOfferStatus(JobOfferStatusID);
ALTER TABLE
    Users ADD CONSTRAINT users_usertypeid_foreign FOREIGN KEY(UserTypeID) REFERENCES UserTypes(UserTypeID);






USE [IJobDB]
GO

INSERT INTO [dbo].[Rating]
           ([Rating])
     VALUES
           (1)
GO

INSERT INTO [dbo].[Rating]
           (
           [Rating])
     VALUES
           (2)
GO


INSERT INTO [dbo].[Rating]
           (
           [Rating])
     VALUES
           (3)
GO

INSERT INTO [dbo].[Rating]
           (
          [Rating])
     VALUES
           (4)
GO


INSERT INTO [dbo].[Rating]
           ([Rating])
     VALUES
           (5)
GO
