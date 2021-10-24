use master

create database IJobDB

use IJobDB

CREATE TABLE Employees(
    EmployeeID INT PRIMARY KEY IDENTITY(1000,1) NOT NULL ,
    UserID INT NOT NULL,
    Employeed bit NOT NULL,
    RatingID INT NOT NULL
);

CREATE TABLE Employers(
    EmployerID INT PRIMARY KEY IDENTITY(2000,1) NOT NULL ,
    UserID INT NOT NULL,
    IsEmployee bit NOT NULL
);

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

CREATE TABLE Categories(
    CategoryID INT PRIMARY KEY NOT NULL ,
    CategoryName VARCHAR(255) NOT NULL
);

CREATE TABLE Comments(
    CommentID INT PRIMARY KEY NOT NULL ,
    Content TEXT NOT NULL,
    JobOfferID INT NOT NULL,
    JobRequestID INT NOT NULL,
    Likes INT NOT NULL
);

CREATE TABLE Rating(
    RatingID INT PRIMARY KEY NOT NULL ,
    RatingName VARCHAR(255) NOT NULL
);

CREATE TABLE JobRequests(
    JobRequestID INT PRIMARY KEY NOT NULL ,
    Topic VARCHAR(255) NOT NULL,
    Content VARCHAR(255) NOT NULL,
    IsApplied bit NOT NULL,
    EmployeeID INT NOT NULL,
    EmployerID INT NOT NULL,
    CommentID INT NOT NULL,
    CategoryID INT NOT NULL,
    JobOfferStatusID INT NOT NULL
);

CREATE TABLE ChatBox(
    PhraseID INT PRIMARY KEY NOT NULL,
    Content VARCHAR(255) NOT NULL
);

CREATE TABLE InterstedInRequest(
    ID INT PRIMARY KEY NOT NULL ,
    JobRequestID INT NOT NULL,
    EmployerID INT NOT NULL
);

CREATE TABLE JobApplications(
    AppID INT PRIMARY KEY NOT NULL ,
    EmployeeID INT NOT NULL,
    JobOfferID INT NOT NULL,
    JobAppStatusID INT NOT NULL,
    EmployerID INT NOT NULL
);

CREATE TABLE JobApplicationStatus(
    StatusID INT PRIMARY KEY NOT NULL ,
    StatusName VARCHAR(255) NOT NULL
);

CREATE TABLE JobOfferStatus(
    JobOfferStatusID INT PRIMARY KEY NOT NULL ,
    JobOfferStatus VARCHAR(255) NOT NULL
);

CREATE TABLE Users(
    UserID INT PRIMARY KEY IDENTITY(100,1) NOT NULL,
    FirstName VARCHAR(255) NOT NULL,
    LastName VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    Pass VARCHAR(255) NOT NULL,
    Nickname VARCHAR(255) NOT NULL,
    Birthday DATE NOT NULL,
    Gender VARCHAR(255) NOT NULL,
    UserTypeID INT NOT NULL
);
CREATE TABLE UserTypes(
    UserTypeID INT PRIMARY KEY NOT NULL ,
    UserTypeName VARCHAR(255) NOT NULL
);

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
    JobRequests ADD CONSTRAINT jobrequests_categoryid_foreign FOREIGN KEY(CategoryID) REFERENCES Categories(CategoryID);
ALTER TABLE
    Comments ADD CONSTRAINT comments_jobrequestid_foreign FOREIGN KEY(JobRequestID) REFERENCES JobRequests(JobRequestID);
ALTER TABLE
    JobRequests ADD CONSTRAINT jobrequests_commentid_foreign FOREIGN KEY(CommentID) REFERENCES Comments(CommentID);
ALTER TABLE
    JobRequests ADD CONSTRAINT jobrequests_jobofferstatusid_foreign FOREIGN KEY(JobOfferStatusID) REFERENCES JobOfferStatus(JobOfferStatusID);
ALTER TABLE
    InterstedInRequest ADD CONSTRAINT interstedinrequest_jobrequestid_foreign FOREIGN KEY(JobRequestID) REFERENCES JobRequests(JobRequestID);
ALTER TABLE
    JobApplications ADD CONSTRAINT jobapplications_employerid_foreign FOREIGN KEY(EmployerID) REFERENCES Employers(EmployerID);
ALTER TABLE
    JobApplications ADD CONSTRAINT jobapplications_jobappstatusid_foreign FOREIGN KEY(JobAppStatusID) REFERENCES JobApplicationStatus(StatusID);
ALTER TABLE
    JobOffers ADD CONSTRAINT joboffers_jobofferstatusid_foreign FOREIGN KEY(JobOfferStatusID) REFERENCES JobOfferStatus(JobOfferStatusID);
ALTER TABLE
    Users ADD CONSTRAINT users_usertypeid_foreign FOREIGN KEY(UserTypeID) REFERENCES UserTypes(UserTypeID);


