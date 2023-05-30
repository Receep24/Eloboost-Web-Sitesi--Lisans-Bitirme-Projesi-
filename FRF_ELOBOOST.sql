create database FRF_ELOBOOST
use FRF_ELOBOOST

If Not Exists(Select * From INFORMATION_SCHEMA.TABLES Where TABLE_NAME = 'Genders')
	Create Table Genders
	(
		GenderID	int identity,
		GenderName	varchar(50),
		Constraint PK_Genders_GenderID Primary Key(GenderID)		
	)
Go
If Not Exists(Select * From INFORMATION_SCHEMA.TABLES Where TABLE_NAME = 'Users')
CREATE TABLE Users (
   userID INT IDENTITY,
   username VARCHAR(50) NOT NULL ,
   password VARCHAR(50) NOT NULL,
   usertype VARCHAR(50) NOT NULL,
   Constraint PK_Users_userID Primary Key(userID)
   );
Go

If Not Exists(Select * From INFORMATION_SCHEMA.TABLES Where TABLE_NAME = 'Admins')
CREATE TABLE Admins (
   AdminsID INT IDENTITY,  
   username VARCHAR(50) NOT NULL ,
   password VARCHAR(50) NOT NULL,
   usertype VARCHAR(50) NOT NULL,
   GenderID INT,
   FirstName VARCHAR(50) NOT NULL,
   LastName VARCHAR(50) NOT NULL,
   Email VARCHAR(50) NOT NULL UNIQUE,
   TelefonNo VARCHAR(20) NOT NULL,
   Constraint PK_Admins_AdminID Primary Key(AdminsID),
   	Constraint FK_Admins_GenderID Foreign Key(GenderID) References Genders(GenderID)

);
Go

If Not Exists(Select * From INFORMATION_SCHEMA.TABLES Where TABLE_NAME = 'Ranks')
CREATE TABLE Ranks (
    RankID INT IDENTITY,
	RankName varchar(50),
	RankPrice int,
	Constraint PK_Ranks_RankID Primary Key(RankID)	
)
Go
If Not Exists(Select * From INFORMATION_SCHEMA.TABLES Where TABLE_NAME = 'Games')
	Create Table Games
	(
		GamesID	int identity,
		GamesName	varchar(50),
		RankID int,		
		Constraint PK_Games_GamesID Primary Key(GamesID),
		Constraint FK_Games_RankID Foreign Key(RankID) References Ranks(RankID)

	)
Go
If Not Exists(Select * From INFORMATION_SCHEMA.TABLES Where TABLE_NAME = 'Comments')
	Create Table Comments
	(
		CommentsID	int identity,
		CustomerID int,
		GamesID int,
		CommentsName	varchar(50),
		Constraint PK_Comments_CommentsID Primary Key(CommentsID),
		Constraint FK_Comments_GamesID Foreign Key(GamesID) References Games(GamesID),
		Constraint FK_Comments_CustomerID Foreign Key(CustomerID) References Customers(CustomerID)

	)
Go
If Not Exists(Select * From INFORMATION_SCHEMA.TABLES Where TABLE_NAME = 'Customers')
CREATE TABLE Customers (
    CustomerID INT IDENTITY,	
	username VARCHAR(50) NOT NULL ,
    password VARCHAR(50) NOT NULL,
    usertype VARCHAR(50) NOT NULL,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
	GenderID INT,
    Email NVARCHAR(100) NOT NULL,
    PhoneNumber NVARCHAR(20) NOT NULL   	   
	Constraint PK_Customers_CustomerID Primary Key(CustomerID),
	Constraint FK_Customers_GenderID Foreign Key(GenderID) References Genders(GenderID)
)
Go
If Not Exists(Select * From INFORMATION_SCHEMA.TABLES Where TABLE_NAME = 'Elooboster')
CREATE TABLE Elooboster (
    EloobosterID INT IDENTITY,
	username VARCHAR(50) NOT NULL ,
    password VARCHAR(50) NOT NULL,
    usertype VARCHAR(50) NOT NULL,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
	GenderID INT,
    Email NVARCHAR(100) NOT NULL  	   
	Constraint PK_Elooboster_MusteriID Primary Key(EloobosterID),
	Constraint FK_Elooboster_GenderID Foreign Key(GenderID) References Genders(GenderID)
)
Go
If Not Exists(Select * From INFORMATION_SCHEMA.TABLES Where TABLE_NAME = 'Adverts')
CREATE TABLE Adverts (
    AdvertsID INT IDENTITY,
	EloobosterID INT,
	GamesID INT,
	RankID INT,
    AdvertTitle NVARCHAR(50) NOT NULL,
	AdvertDate Date NOT NULL	
	Constraint PK_Adverts_AdvertsID Primary Key(AdvertsID),
	Constraint FK_Adverts_EloobosterID Foreign Key(EloobosterID) References Elooboster(EloobosterID),
	Constraint FK_Adverts_GamesID Foreign Key(GamesID) References Games(GamesID),
	Constraint FK_Adverts_RankID Foreign Key(RankID) References Ranks(RankID)
	)
Go
If Not Exists(Select * From INFORMATION_SCHEMA.TABLES Where TABLE_NAME = 'Meetings')
CREATE TABLE Meetings (
    MeetID INT IDENTITY,
	CustomerID INT,
	EloobosterID INT,
	AdvertsID INT,
	GamesID INT,
	RankID INT,
	MeetingDate DATE NOT NULL,    
	Constraint PK_Meetings_MeetID Primary Key(MeetID),
	Constraint FK_Meetings_CustomerID Foreign Key(CustomerID) References Customers(CustomerID),
	Constraint FK_Meetings_EloobosterID Foreign Key(EloobosterID) References Elooboster(EloobosterID),
	Constraint FK_Meetings_AdvertsID Foreign Key(AdvertsID) References Adverts(AdvertsID),
	Constraint FK_Meetings_GamesID Foreign Key(GamesID) References Games(GamesID),
	Constraint FK_Meetings_RankID Foreign Key(RankID) References Ranks(RankID)
	)
Go

Create TRIGGER musterises on dbo.Customers AFTER INSERT 
AS 
 SET NOCOUNT ON 
 INSERT INTO dbo.Users(username,password,usertype) Select username,password,usertype FROM inserted
Go 
Create TRIGGER eloboosterses on dbo.Elooboster AFTER INSERT 
AS 
 SET NOCOUNT ON 
 INSERT INTO dbo.Users(username,password,usertype) Select username,password,usertype FROM inserted
Go 
Create TRIGGER adminses on dbo.Admins AFTER INSERT 
AS 
 SET NOCOUNT ON 
 INSERT INTO dbo.Users(username,password,usertype) Select username,password,usertype FROM inserted
Go
