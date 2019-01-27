CREATE DATABASE MyDatabase
GO

USE MyDatabase
GO

CREATE TABLE dbo.Companies
(
 Id int IDENTITY(1,1) PRIMARY KEY,
 Name varchar(50) NULL,
 Email varchar(50) NULL,
 PhoneNumber varchar(50) null,
 Address varchar(50) null
)
GO

CREATE TABLE dbo.Employees
(   
 Id int IDENTITY(1,1) PRIMARY KEY,
 Name varchar(50) NULL,
 DOB date NULL,
 Email varchar(50) NULL,
 Gender varchar(6) null,
 PhoneNumber varchar(50) null,
 Address varchar(50) null,
 IdCardNumber varchar(50) null,
 CompanyId int null,
 constraint fk_employees_companies foreign key (CompanyId) references dbo.Companies (Id)
)
GO

CREATE TABLE dbo.Skills
(
 Id int IDENTITY(1,1) PRIMARY KEY,
 Description varchar(50) NULL,
 EmployeeId int NOT NULL,
 constraint fk_skills_employees foreign key (EmployeeId) references dbo.Employees (Id)
)
GO

INSERT INTO dbo.Companies (Name, Email, PhoneNumber, Address) VALUES ('Szintezis-Net', 'szintezis-net@email.hu', '0696431978', 'Gyor, Vasvari Pal utca');
INSERT INTO dbo.Companies (Name, Email, PhoneNumber, Address) VALUES ('Attrecto', 'attrecto@email.hu', '0696751964', 'Gyor, Wesselenyi utca');
INSERT INTO dbo.Companies (Name, Email, PhoneNumber, Address) VALUES ('Tricast', 'tricast@email.hu', '0696951426', 'Gyor, Marcius 15 utca');

INSERT INTO dbo.Employees (Name, DOB, Email, Gender, PhoneNumber, Address, IdCardNumber, CompanyId) VALUES ('Zoli', '1990-04-05', 'zoli@email.hu', 'male', '06209876234', 'Toltestava', '5468768', 3);
INSERT INTO dbo.Employees (Name, DOB, Email, Gender, PhoneNumber, Address, IdCardNumber, CompanyId) VALUES ('Gyula', '1990-05-01', 'gyula@email.hu', 'male', '06207412397', 'Gyor', '98515212', 3);
INSERT INTO dbo.Employees (Name, DOB, Email, Gender, PhoneNumber, Address, IdCardNumber, CompanyId) VALUES ('Bandi', '1986-07-21', 'bandi@email.hu', 'male', '06209586365', 'Gyor', '5154687', 1);
INSERT INTO dbo.Employees (Name, DOB, Email, Gender, PhoneNumber, Address, IdCardNumber) VALUES ('Soma', '1991-09-12', 'soma@email.hu', 'male', '06208315486', 'Gyor', '64861513');

INSERT INTO dbo.Skills (Description, EmployeeId) VALUES ('Java', 1);
INSERT INTO dbo.Skills (Description, EmployeeId) VALUES ('SQL', 1);
INSERT INTO dbo.Skills (Description, EmployeeId) VALUES ('Java', 2);
INSERT INTO dbo.Skills (Description, EmployeeId) VALUES ('C#', 3);
INSERT INTO dbo.Skills (Description, EmployeeId) VALUES ('Delphi', 4);