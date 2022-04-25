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
	NumApplied INT NOT NULL,
	JobTitle VARCHAR(255) NOT NULL,
	RequiredAge INT NOT NULL,
	RequiredEmployees INT NOT NULL,
    JobOfferDescription TEXT NOT NULL,
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
    CategoryName VARCHAR(255) NOT NULL
);

CREATE UNIQUE INDEX CategoryNameIndex
on Categories (CategoryName);

CREATE TABLE Comments(
    CommentID INT PRIMARY KEY IDENTITY(10000,1) NOT NULL ,
    Content TEXT NOT NULL,
    JobOfferID INT NOT NULL,
    JobRequestID INT NOT NULL,
    Likes INT NOT NULL
);

CREATE UNIQUE INDEX JobOfferIDIndex
on Comments (JobOfferID);
--Change to plural and in the forgein as well
CREATE TABLE Rating(
    RatingID INT PRIMARY KEY NOT NULL ,
    RatingName VARCHAR(255) NOT NULL
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
    JobAppStatusID INT NOT NULL,
    EmployerID INT NOT NULL
);

CREATE UNIQUE INDEX AppStatusIndex
on JobApplications (JobAppStatusID);

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
    LastName VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    Pass VARCHAR(255) NOT NULL,
    Nickname VARCHAR(255) NOT NULL,
    Birthday DATE NOT NULL,
    Gender VARCHAR(255) NOT NULL,
    UserTypeID INT NOT NULL,
	PrivateAnswer VARCHAR(255) NOT NULL
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
	JobRequests ADD CONSTRAINT jobrequests_employeeid_foreign FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID);
ALTER TABLE
    Employees ADD CONSTRAINT employees_ratingid_foreign FOREIGN KEY(RatingID) REFERENCES Rating(RatingID);
ALTER TABLE
	JobRequests ADD CONSTRAINT jobrequests_employerid_foreign FOREIGN KEY(EmployerID) REFERENCES Employers(EmployerID);
ALTER TABLE
    JobApplications ADD CONSTRAINT jobapplications_jobofferid_foreign FOREIGN KEY(JobOfferID) REFERENCES JobOffers(JobOfferID);
ALTER TABLE
    Comments ADD CONSTRAINT comments_jobofferid_foreign FOREIGN KEY(JobOfferID) REFERENCES JobOffers(JobOfferID);
ALTER TABLE
    JobOffers ADD CONSTRAINT joboffers_employerid_foreign FOREIGN KEY(EmployerID) REFERENCES Employers(EmployerID);
ALTER TABLE
    JobOffers ADD CONSTRAINT joboffers_commentid_foreign FOREIGN KEY(CommentID) REFERENCES Comments(CommentID);
ALTER TABLE
    JobOffers ADD CONSTRAINT joboffers_categoryid_foreign FOREIGN KEY(CategoryID) REFERENCES Categories(CategoryID);
ALTER TABLE
    JobRequests ADD CONSTRAINT jobrequest_categoryid_foreign FOREIGN KEY(CategoryID) REFERENCES Categories(CategoryID);
ALTER TABLE
    Comments ADD CONSTRAINT comments_jobrequestid_foreign FOREIGN KEY(JobRequestID) REFERENCES JobRequests(JobRequestID);
ALTER TABLE
    JobRequests ADD CONSTRAINT jobrequest_commentid_foreign FOREIGN KEY(CommentID) REFERENCES Comments(CommentID);
ALTER TABLE
    JobRequests ADD CONSTRAINT jobrequest_jobofferstatusid_foreign FOREIGN KEY(JobOfferStatusID) REFERENCES JobOfferStatus(JobOfferStatusID);
ALTER TABLE
    InterstedInRequest ADD CONSTRAINT interstedinrequest_jobrequestid_foreign FOREIGN KEY(JobRequestID) REFERENCES JobRequests(JobRequestID);
ALTER TABLE
    JobApplications ADD CONSTRAINT jobapplications_employerid_foreign FOREIGN KEY(EmployerID) REFERENCES Employers(EmployerID);
ALTER TABLE
    JobApplications ADD CONSTRAINT jobapplications_jobappstatusid_foreign FOREIGN KEY(JobAppStatusID) REFERENCES JobApplicationStatus(StatusID);
ALTER TABLE
    JobOffers ADD CONSTRAINT joboffer_jobofferstatusid_foreign FOREIGN KEY(JobOfferStatusID) REFERENCES JobOfferStatus(JobOfferStatusID);
ALTER TABLE
    Users ADD CONSTRAINT users_usertypeid_foreign FOREIGN KEY(UserTypeID) REFERENCES UserTypes(UserTypeID);

--Creating Rating Table
 USE [IJobDB]
GO

INSERT INTO [dbo].[Rating]
           ([RatingID]
           ,[RatingName])
     VALUES
           (1,
		   'Bad')
GO

INSERT INTO [dbo].[Rating]
           ([RatingID]
           ,[RatingName])
     VALUES
           (2,
		   'Not bad')
GO


INSERT INTO [dbo].[Rating]
           ([RatingID]
           ,[RatingName])
     VALUES
           (3,
		   'Good')
GO

INSERT INTO [dbo].[Rating]
           ([RatingID]
           ,[RatingName])
     VALUES
           (4,
		   'Very good')
GO


INSERT INTO [dbo].[Rating]
           ([RatingID]
           ,[RatingName])
     VALUES
           (5,
		   'Excellent')
GO


--Creating UserTypes Table
USE [IJobDB]
GO

INSERT INTO [dbo].[UserTypes]
           ([UserTypeName])
     VALUES
           ('Admin')
GO

INSERT INTO [dbo].[UserTypes]
           ([UserTypeName])
     VALUES
           ('Employer')
GO

INSERT INTO [dbo].[UserTypes]
           ([UserTypeName])
     VALUES
           ('Employee')
GO

SELECT * FROM UserTypes


--Creating Users Table
USE [IJobDB]
GO

INSERT INTO [dbo].[Users]
           ([FirstName]
           ,[LastName]
           ,[Email]
           ,[Pass]
           ,[Nickname]
           ,[Birthday]
           ,[Gender]
           ,[UserTypeID]
		   ,[PrivateAnswer])
     VALUES
           ('Lucas',
           'Haribo',
           'lucas@gmail.com',
           '12',
           'Luc1',
           '2016/08/27 21:02:44',
           'Male',
           '2',
		   'Medevdev')
GO

INSERT INTO [dbo].[Users]
           ([FirstName]
           ,[LastName]
           ,[Email]
           ,[Pass]
           ,[Nickname]
           ,[Birthday]
           ,[Gender]
           ,[UserTypeID]
		   ,[PrivateAnswer])
     VALUES
           ('Steve',
           'Jobs',
           'steve@gmail.com',
           'steve12',
           'AppleFounder',
           '1955/02/24 21:02:44',
           'Male',
           '1',
		   'Reed')
GO



USE [IJobDB]
GO

INSERT INTO [dbo].[Users]
           ([FirstName]
           ,[LastName]
           ,[Email]
           ,[Pass]
           ,[Nickname]
           ,[Birthday]
           ,[Gender]
           ,[UserTypeID]
           ,[PrivateAnswer])
     VALUES
           ('Admin'
           ,'Admin'
           ,'Admin@gmail.com'
           ,'123'
           ,'Admin'
           ,'2000-5-11'
           ,'Male'
           ,1
           ,'Lucas')
GO
SELECT * FROM Users

USE [IJobDB]
GO

INSERT INTO [dbo].[Categories]
           ([CategoryName])
     VALUES
           ('Dogwalking')
GO

INSERT INTO [dbo].[Categories]
           ([CategoryName])
     VALUES
           ('Babysitting')
GO

INSERT INTO [dbo].[Categories]
           ([CategoryName])
     VALUES
           ('Private Tutoring')
GO

INSERT INTO [dbo].[Categories]
           ([CategoryName])
     VALUES
           ('Serving (waitress)')
GO

INSERT INTO [dbo].[Categories]
           ([CategoryName])
     VALUES
           ('Deliveries')
GO

INSERT INTO [dbo].[Categories]
           ([CategoryName])
     VALUES
           ('Food Vendor')
GO

INSERT INTO [dbo].[Categories]
           ([CategoryName])
     VALUES
           ('Store Seller')
GO

INSERT INTO [dbo].[Categories]
           ([CategoryName])
     VALUES
           ('Guide')
GO

INSERT INTO [dbo].[Categories]
           ([CategoryName])
     VALUES
           ('Handing out flyers')
GO


GO

INSERT INTO [dbo].[Categories]
           ([CategoryName])
     VALUES
           ('Mail Delivery')
GO


INSERT INTO [dbo].[Categories]
           ([CategoryName])
     VALUES
           ('Other')
GO

<!-- לשים אופציהכאן באחר שהם יכולים לכתוב ואז אני אסמוך עליהם שזה תקין ולא צריך ולידציה -->

select * from Categories ORDER BY CategoryID

