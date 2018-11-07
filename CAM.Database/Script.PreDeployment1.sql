


/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

CREATE DATABASE CAM
GO

USE CAM
GO
--DROP table Softwares
--GO
--Truncate table  Softwares
GO
CREATE TABLE Softwares(Id INT primary key identity(1,1),
Name VARCHAR(max),
IP  varchar(50) default '0.0.0.0',
Host  varchar(50) default '0.0.0.0',
Version  varchar(50) default '0.0.0.0',
Vendor  varchar(250) default '',
CreatedDate  datetime default getdate(),
InstalledDate  datetime default getdate()

)
GO

INSERT INTO Softwares(Name) VALUES ( 'Apple');
INSERT INTO Softwares(Name)  VALUES ( 'Samsung');
INSERT INTO Softwares(Name)  VALUES ( 'OnePlus');

GO

--Alter table softwares add  IP  varchar(50) default '0.0.0.0'
--Alter table softwares add  Host  varchar(50) default '0.0.0.0'
--Alter table softwares add  InstalledDate  datetime default getdate()
--Alter table softwares add  Version  varchar(50) default '0.0.0.0'
--Alter table softwares add  Vendor  varchar(250) default ''
--Alter table softwares add  CreatedDate  datetime default getdate()

GO
select * from Softwares





	USE MASTER
	GO
	IF NOT EXISTS(SELECT * FROM SYS.DATABASES WHERE NAME = 'Intelligent')
	CREATE DATABASE Intelligent
	GO

	USE Intelligent
	GO
	CREATE TABLE Asset(

	Id INT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(100),
	UserId INT,
	IsActive BIT,
	CreatedDate DATETIME,
	CreatedBy INT,
	UpdatedDate DATETIME,
	UpdatedBy INT

	)

	ALTER Table Asset  add OS varchar(250) 
	ALTER Table Asset  add OSDescription varchar(250) 
	ALTER Table Asset  add BuiltType varchar(250) 
	ALTER Table Asset  add BuiltDescription varchar(250) 
	GO

	
--WITH 
--  cteTotalSales (Name)
--AS
--  (
--	SELECT * FROM
--	STRING_SPLIT(
--   'CS-001-DT-WS,
--	CS-010-DT-WS,
--	CS-011-DT-US,
--	CS-020-DT-US,
--	CS-021-DT-WS,
--	CS-100-DT-WS,
--	CS-101-LT-WS,
--	CS-200-LT-WS,
--	CS-201-DT-US,
--	CS-300-DT-US,
--	CS-301-DT-MAC,
--	CS-400-DT-MAC,
--	CS-401-LT-MAC,
--	CS-500-LT-MAC',',') 
--	)
--		--SELECT COUNT(*)
--	 --FROM cteTotalSales

--	SELECT Name
--	 FROM cteTotalSales
DECLARE @Count INT = 1;
DECLARE @asset_name VARCHAR(50) -- database name 
WHILE @Count <= 500
BEGIN
    IF @Count<=10
       SET @asset_name='CS-00'+CAST(@Count as varchar)+'-DT-WS'
	ELSE IF @Count>10 and @Count<=20
       SET @asset_name='CS-0'+CAST(@Count as varchar)+'-DT-US'
	ELSE IF @Count>20 and CAST(@Count as varchar)<=100
       SET @asset_name='CS-0'+CAST(@Count as varchar)+'-LT-US'
	 ELSE IF @Count>100 and @Count<=200
       SET @asset_name='CS-'+CAST(@Count as varchar)+'-DT-WS'
	ELSE IF @Count>200 and @Count<=300
       SET @asset_name='CS-'+CAST(@Count as varchar)+'-LT-WS'
	ELSE IF @Count>300 and @Count<=400
       SET @asset_name='CS-'+CAST(@Count as varchar)+'-DT-MAC'
	ELSE IF @Count>400 and @Count<=500
       SET @asset_name='CS-'+CAST(@Count as varchar)+'-LT-MAC'
	   PRINT @asset_name
	   INSERT INTO Asset(Name, UserId, IsActive, CreatedDate, CreatedBy) VALUES (@asset_name, 1, 1, GETDATE(), 1)
   SET @Count = @Count + 1;
END;

PRINT 'Done simulated FOR LOOP ';
Update Asset set name = 'CS-010-DT-WS' where id=10
GO
select * from Asset

--TRUNCATE TABLE Asset

	Update Asset set OS='Windows ',OSDescription='Windows System' Where Name like ('%WS%')
	Update Asset set OS='Ubuntu ',OSDescription='Ubuntu System' Where Name like ('%US%')
	Update Asset set OS='Mac System',OSDescription='Mac System' Where Name like ('%MAC%')
----------------------------------------------
	Update Asset set BuiltType='Laptop',BuiltDescription='Windows System' Where Name like ('%LT%')
	Update Asset set BuiltType='Desktop',BuiltDescription='Ubuntu System' Where Name like ('%DT%')
	Update Asset set BuiltType='Desktop',BuiltDescription='Mac System' Where Name like ('%MAC%') AND Name like ('%DT%')
	Update Asset set BuiltType='Server',BuiltDescription='Ubuntu System' Where Name like ('%DT%') and (id>10 and Id<=20 )AND Name like ('%US%')
	Update Asset set BuiltType='Server',BuiltDescription='Windows System' Where Name like ('%DT%') and id<=10 AND Name like ('%WS%')
	Update Asset set BuiltType='Desktop',BuiltDescription='Windows System' Where Name like ('%MAC%') AND Name like ('%DT%')






	CREATE TABLE [User](

	Id INT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(100),
	ManagerId INT,
	IsActive BIT,
	CreatedDate DATETIME,
	CreatedBy INT,
	UpdatedDate DATETIME,
	UpdatedBy INT

	)
	SELECT * FROM [USER]
	TRUNCATE TABLE [User]

	--loop start
	--DECLARE @userNo int = 0
	--WHILE @userNo < 100 
	--BEGIN
	--	SET @userNo = @userNo + 1
	--	INSERT INTO [User] (Name, ManagerId, IsActive, CreatedDate, CreatedBy) 
	--				VALUES ('User' + CONVERT(varchar(10),@userNo), 1, 1, GETDATE(), 1)
	--END
	--loop end

INSERT INTO [User]([Name],IsActive)values('Helpdesk',1)
INSERT INTO [User]([Name],IsActive)values('Shibu',1)
INSERT INTO [User]([Name],IsActive)values('Venkatesh',1)
INSERT INTO [User]([Name],IsActive)values('Pradeep',1)
INSERT INTO [User]([Name],IsActive)values('Venkat',1)
INSERT INTO [User]([Name],IsActive)values('June',1)
INSERT INTO [User]([Name],IsActive)values('Bindu',1)
INSERT INTO [User]([Name],IsActive)values('Asha',1)
INSERT INTO [User]([Name],IsActive)values('Shareem',1)
INSERT INTO [User]([Name],IsActive)values('Anilesh',1)
INSERT INTO [User]([Name],IsActive)values('Shoureef',1)
INSERT INTO [User]([Name],IsActive)values('Reshmi',1)
INSERT INTO [User]([Name],IsActive)values('Daniya Jose',1)
INSERT INTO [User]([Name],IsActive)values('Nived Chandran',1)
INSERT INTO [User]([Name],IsActive)values('Rebin Kuruvilla Varghese',1)
INSERT INTO [User]([Name],IsActive)values('Sandeep P R',1)
INSERT INTO [User]([Name],IsActive)values('Swaroop Joseph',1)
INSERT INTO [User]([Name],IsActive)values('Arun P',1)
INSERT INTO [User]([Name],IsActive)values('Chitra B',1)
INSERT INTO [User]([Name],IsActive)values('Sooraj V',1)
INSERT INTO [User]([Name],IsActive)values('Dilip Geevarghese',1)
INSERT INTO [User]([Name],IsActive)values('Sumi Menon K',1)
INSERT INTO [User]([Name],IsActive)values('Saritha K S',1)
INSERT INTO [User]([Name],IsActive)values('Sreejith T K',1)
INSERT INTO [User]([Name],IsActive)values('Vaishakh O K',1)
INSERT INTO [User]([Name],IsActive)values('Sanu K Soman',1)
INSERT INTO [User]([Name],IsActive)values('Arun A G',1)
INSERT INTO [User]([Name],IsActive)values('Dino Sunny',1)
INSERT INTO [User]([Name],IsActive)values('Angitha Das',1)
INSERT INTO [User]([Name],IsActive)values('Kiran K J',1)
INSERT INTO [User]([Name],IsActive)values('Neethu Raju',1)
INSERT INTO [User]([Name],IsActive)values('Dhanya E P',1)
INSERT INTO [User]([Name],IsActive)values('Akshay Venugopal',1)
INSERT INTO [User]([Name],IsActive)values('Rincy K Varghese',1)
INSERT INTO [User]([Name],IsActive)values('Riya Jose',1)
INSERT INTO [User]([Name],IsActive)values('Sebin Sebastian',1)
INSERT INTO [User]([Name],IsActive)values('Minnu Shaji',1)
INSERT INTO [User]([Name],IsActive)values('Aswathy C R',1)
INSERT INTO [User]([Name],IsActive)values('Vishnu R',1)
INSERT INTO [User]([Name],IsActive)values('Akhil Subramanyan',1)
INSERT INTO [User]([Name],IsActive)values('Feialoh Francis P',1)
INSERT INTO [User]([Name],IsActive)values('Abdul Salam K A',1)
INSERT INTO [User]([Name],IsActive)values('Adil T',1)
INSERT INTO [User]([Name],IsActive)values('Priyanka V',1)
INSERT INTO [User]([Name],IsActive)values('Denny Mathew',1)
INSERT INTO [User]([Name],IsActive)values('Catherine K G',1)
INSERT INTO [User]([Name],IsActive)values('Joe Davis',1)
INSERT INTO [User]([Name],IsActive)values('Anoop U',1)
INSERT INTO [User]([Name],IsActive)values('Remya D',1)
INSERT INTO [User]([Name],IsActive)values('Triju Issac',1)
INSERT INTO [User]([Name],IsActive)values('Vineeth Kumar',1)
INSERT INTO [User]([Name],IsActive)values('Indhu V S',1)
INSERT INTO [User]([Name],IsActive)values('Nimisha S',1)
INSERT INTO [User]([Name],IsActive)values('Krishna Kumar',1)
INSERT INTO [User]([Name],IsActive)values('Kiran Francis Sebastian',1)
INSERT INTO [User]([Name],IsActive)values('Soumya Subramaniam',1)
INSERT INTO [User]([Name],IsActive)values('Reshma Chandra Babu',1)
INSERT INTO [User]([Name],IsActive)values('Prasanth A P',1)
INSERT INTO [User]([Name],IsActive)values('Parvathy K S',1)
INSERT INTO [User]([Name],IsActive)values('Jidesh P M',1)
INSERT INTO [User]([Name],IsActive)values('Varma Parthiv Pradhu',1)
INSERT INTO [User]([Name],IsActive)values('Aishwarya Ravindran',1)
INSERT INTO [User]([Name],IsActive)values('Vivek Prakash',1)
INSERT INTO [User]([Name],IsActive)values('Eldhose Raju',1)
INSERT INTO [User]([Name],IsActive)values('Hariprasad',1)
INSERT INTO [User]([Name],IsActive)values('Amitha',1)
INSERT INTO [User]([Name],IsActive)values('Krishnapriya',1)
INSERT INTO [User]([Name],IsActive)values('Joe',1)
INSERT INTO [User]([Name],IsActive)values('Arnold',1)
INSERT INTO [User]([Name],IsActive)values('Subhash',1)
INSERT INTO [User]([Name],IsActive)values('Shalu',1)
INSERT INTO [User]([Name],IsActive)values('Sandra',1)
INSERT INTO [User]([Name],IsActive)values('Lucky Laxadhish',1)
INSERT INTO [User]([Name],IsActive)values('Jingle John',1)
INSERT INTO [User]([Name],IsActive)values('Abraham P Mathew',1)
INSERT INTO [User]([Name],IsActive)values('Divin Divakaran',1)
	




CREATE TABLE [dbo].[Softwares](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NULL,
	[IP] [varchar](50) NULL,
	[Host] [varchar](50) NULL,
	[Version] [varchar](50) NULL,
	[Vendor] [varchar](250) NULL,
	[CreatedDate] [datetime] NULL,
	[InstalledDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Softwares] ADD  DEFAULT ('0.0.0.0') FOR [IP]
GO
ALTER TABLE [dbo].[Softwares] ADD  DEFAULT ('0.0.0.0') FOR [Host]
GO
ALTER TABLE [dbo].[Softwares] ADD  DEFAULT ('0.0.0.0') FOR [Version]
GO
ALTER TABLE [dbo].[Softwares] ADD  DEFAULT ('') FOR [Vendor]
GO
ALTER TABLE [dbo].[Softwares] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Softwares] ADD  DEFAULT (getdate()) FOR [InstalledDate]
GO
Create Table [Department](
Id int Primary Key Identity(1,1),
[Name] varchar(200),
IsActive bit
)
GO
INSERT INTO [Department]([Name],IsActive)values('Software Development',1)
INSERT INTO [Department]([Name],IsActive)values('Sales  & Marketing',1)
INSERT INTO [Department]([Name],IsActive)values('Misc Services',1)
INSERT INTO [Department]([Name],IsActive)values('HR',1)
INSERT INTO [Department]([Name],IsActive)values('IT Services',1)

Create Table [Employee](
Id int Primary Key Identity(1,1),
[Name] varchar(200),
EmpId varchar(20),
DepartmentId int,
IsActive bit
)
GO
Create Table [Technologies](
Id int Primary Key Identity(1,1),
[Name] varchar(200),
IsActive bit
)
GO
--Create Table [User](
--Id int Primary Key Identity(1,1),
--[Name] varchar(200),
--[Password] varchar(200),
--IsActive bit
--)
--GO
GO
Create Table Location(
Id int Primary Key Identity(1,1),
[Name] varchar(200),
IsActive bit
)
GO
INSERT INTO Location([Name],IsActive)values('First Floor',1)
INSERT INTO Location([Name],IsActive)values('Second Floor',1)				

GO
Create Table DeviceHealthStatus(
Id int Primary Key Identity(1,1),
[Status] varchar(200),
IsActive bit
)
GO
INSERT INTO DeviceHealthStatus([Status],IsActive)values('Available',1)
INSERT INTO DeviceHealthStatus([Status],IsActive)values('No Charger',1)
INSERT INTO DeviceHealthStatus([Status],IsActive)values('Not Working',1)
INSERT INTO DeviceHealthStatus([Status],IsActive)values('Missing',1)
GO					 
Create Table DeviceType(
Id int Primary Key Identity(1,1),
[Type] varchar(200),
IsActive bit
)
GO
INSERT INTO DeviceType([Type],IsActive)values('Devices',1)
INSERT INTO DeviceType([Type],IsActive)values('Servers',1)
INSERT INTO DeviceType([Type],IsActive)values('Laptops',1)
INSERT INTO DeviceType([Type],IsActive)values('Others',1)
GO
Create Table DeviceSubType(
Id int Primary Key Identity(1,1),
[Type] varchar(200),
IsActive bit
)
GO
INSERT INTO DeviceType([Type],IsActive)values('Android',1)
INSERT INTO DeviceType([Type],IsActive)values('Windows',1)
INSERT INTO DeviceType([Type],IsActive)values('Linux',1)
INSERT INTO DeviceType([Type],IsActive)values('IOS',1)
INSERT INTO DeviceType([Type],IsActive)values('Others',1)
	 					 					 					 
GO
Create Table Device(
Id int Primary Key Identity(1,1),
DeviceID varchar(100),
Name varchar(250),
Status int,
Model varchar(250),
Manufacturer varchar(250),
Owner int,
Location varchar(250),
SerialNo varchar(250),
IMEINo varchar(250),
CreateDate DateTime,
UpdateDate DateTime,
IsActive bit

)
INSERT INTO Device(DeviceID,Name,[Status],Model,Owner,Location,SerialNo,IMEINo,CreateDate,UpdateDate,IsActive)values('CBT-612','Nexus7 ',3,'Nexus 7',2,1,null,null,getdate(),null,1)
INSERT INTO Device(DeviceID,Name,[Status],Model,Owner,Location,SerialNo,IMEINo,CreateDate,UpdateDate,IsActive)values('CBT-613','Nexus 9',1,'Nexus 9',2,1,'HT4ALJT03219',null,getdate(),null,1)
GO																																		   
INSERT INTO Device(DeviceID,Name,[Status],Model,Owner,Location,SerialNo,IMEINo,CreateDate,UpdateDate,IsActive)values('CBT-614','LGE',1,'LG-D852',9,2,'LGD852ca76a74e','354608064670278',getdate(),null,1)
GO																																		  
INSERT INTO Device(DeviceID,Name,[Status],Model,Owner,Location,SerialNo,IMEINo,CreateDate,UpdateDate,IsActive)values('CBT-615','Galaxy Tab S',1,'SM-T800',2,1,'32048ea1684c91f3',null,getdate(),null,1)
GO																																		   
INSERT INTO Device(DeviceID,Name,[Status],Model,Owner,Location,SerialNo,IMEINo,CreateDate,UpdateDate,IsActive)values('CBT-616','Nexus 6',1,'Nexus 6',1,2,'ZX1G4276NT','355470061650129',getdate(),null,1)
GO
INSERT INTO Device(DeviceID,Name,[Status],Model,Owner,Location,SerialNo,IMEINo,CreateDate,UpdateDate,IsActive)values('CBT-617',null,1,'AQ4501',1,null,null,null,getdate(),null,1)
GO																																										 
INSERT INTO Device(DeviceID,Name,[Status],Model,Owner,Location,SerialNo,IMEINo,CreateDate,UpdateDate,IsActive)values('CBT-618',null,4,'S3',1,1,null,null,getdate(),null,1)
GO
INSERT INTO Device(DeviceID,Name,[Status],Model,Owner,Location,SerialNo,IMEINo,CreateDate,UpdateDate,IsActive)values('CBT-619','Cabot Dev(GalaxyTab)',4,'SM-T561',2,1,'RZ2GA00Z12L','351962070490863',getdate(),null,1)
GO
INSERT INTO Device(DeviceID,Name,[Status],Model,Owner,Location,SerialNo,IMEINo,CreateDate,UpdateDate,IsActive)values('CBT-620','Motorola',1,'G3',7,2,'ZY2232T7J4','352356078058096',getdate(),null,1)
GO
INSERT INTO Device(DeviceID,Name,[Status],Model,Owner,Location,SerialNo,IMEINo,CreateDate,UpdateDate,IsActive)values('CBT-621','Galaxy S7',1,'SM-G930FD',5,1,'R58H522P61Y','358430075266392',getdate(),null,1)
GO
INSERT INTO Device(DeviceID,Name,[Status],Model,Owner,Location,SerialNo,IMEINo,CreateDate,UpdateDate,IsActive)values('CBT-622','G5',1,'Nexus 6',6,2,'ZX1G4276NT',null,getdate(),null,1)
GO
INSERT INTO Device(DeviceID,Name,[Status],Model,Owner,Location,SerialNo,IMEINo,CreateDate,UpdateDate,IsActive)values('CBT-623','Yoga Tab',4,'YT3-850M',10,1,'HGAD38LA','867152026083858',getdate(),null,1)
GO
INSERT INTO Device(DeviceID,Name,[Status],Model,Owner,Location,SerialNo,IMEINo,CreateDate,UpdateDate,IsActive)values('CBT-624',null,1,null,1,null,null,null,getdate(),null,1)
GO
																																							  
INSERT INTO Device(DeviceID,Name,[Status],Model,Owner,Location,SerialNo,IMEINo,CreateDate,UpdateDate,IsActive)values('CBT-625','iPad Air2',4,'MH0W2HN/A',4,1,null,null,getdate(),null,1)
GO
INSERT INTO Device(DeviceID,Name,[Status],Model,Owner,Location,SerialNo,IMEINo,CreateDate,UpdateDate,IsActive)values('CBT-626','iPad pro 12.9',1,'ML0F2LL/A',11,1,'DLXR921CGMLD','044B178345328001512',getdate(),null,1)
GO
--INSERT INTO Device(DeviceID,Name,[Status],Model,Owner,Location,SerialNo,IMEINo,CreateDate,UpdateDate,IsActive)values('CBT-626','iPad pro 12.9',1,'ML0F2LL/A,'11,1,DLXR921CGMLD,044B178345328001512,getdate(),null,1)
GO
INSERT INTO Device(DeviceID,Name,[Status],Model,Owner,Location,SerialNo,IMEINo,CreateDate,UpdateDate,IsActive)values('CBT-627','iPad mini3',4,'MGYE2HN/A',1,1,'DLXNM7NCG5V3','042D4C4330298001424',getdate(),null,1)
GO 
INSERT INTO Device(DeviceID,Name,[Status],Model,Owner,Location,SerialNo,IMEINo,CreateDate,UpdateDate,IsActive)values('CBT-628','iPhone 6+',1,'MGAM2LL/A',8,2,'F2LNCCENG5QG','35 438606 064354 6',getdate(),null,1)
GO
INSERT INTO Device(DeviceID,Name,[Status],Model,Owner,Location,SerialNo,IMEINo,CreateDate,UpdateDate,IsActive)values('CBT-629','iPad2',4,'mc769hn/a',1,2,null,null,getdate(),null,1)
GO
INSERT INTO Device(DeviceID,Name,[Status],Model,Owner,Location,SerialNo,IMEINo,CreateDate,UpdateDate,IsActive)values('CBT-630','iPad',4,'md368hn/a',1,null,null,null,getdate(),null,1)
GO
INSERT INTO Device(DeviceID,Name,[Status],Model,Owner,Location,SerialNo,IMEINo,CreateDate,UpdateDate,IsActive)values('CBT-631','iPhone 5S',1,'ME306LL/A',3,1,'F2LLT2AEFF9V',null,getdate(),null,1)
GO
INSERT INTO Device(DeviceID,Name,[Status],Model,Owner,Location,SerialNo,IMEINo,CreateDate,UpdateDate,IsActive)values('CBT-632','iPhone 5',4,'MD293LL/A',1,2,'F19L44GJFH19','13434007162403',getdate(),null,1)
GO
INSERT INTO Device(DeviceID,Name,[Status],Model,Owner,Location,SerialNo,IMEINo,CreateDate,UpdateDate,IsActive)values('CBME306LL/AT-633','iPad mini4',4,'MK6J2HN/A',1,1,'F9FR8218GHK9','04131A2B46328001512',getdate(),null,1)
GO
INSERT INTO Device(DeviceID,Name,[Status],Model,Owner,Location,SerialNo,IMEINo,CreateDate,UpdateDate,IsActive)values('CBT-634','iPad Pro 9.7',4,'MLMN2HN/A',3,1,'nuDMPT10XYHM9ll',null,getdate(),null,1)
GO
INSERT INTO Device(DeviceID,Name,[Status],Model,Owner,Location,SerialNo,IMEINo,CreateDate,UpdateDate,IsActive)values('CBT-635','iPad',2,'A1219',1,2,'J3035E67Z38',null,getdate(),null,1)
GO
INSERT INTO Device(DeviceID,Name,[Status],Model,Owner,Location,SerialNo,IMEINo,CreateDate,UpdateDate,IsActive)values('CBT-636','Tab 7 Essential',1,'Lenovo TB-7304F',1,2,'8SHQ31207260HB417B2',null,getdate(),null,1)
GO
INSERT INTO Device(DeviceID,Name,[Status],Model,Owner,Location,SerialNo,IMEINo,CreateDate,UpdateDate,IsActive)values('CBT-637','iPad',4,'A1430',1,null,'DYTHV621DVGJ',null,getdate(),null,1)
GO
INSERT INTO Device(DeviceID,Name,[Status],Model,Owner,Location,SerialNo,IMEINo,CreateDate,UpdateDate,IsActive)values('CBT-638','ViewPad',2,'E100/VS14445',1,2,null,null,getdate(),null,1)
GO
INSERT INTO Device(DeviceID,Name,[Status],Model,Owner,Location,SerialNo,IMEINo,CreateDate,UpdateDate,IsActive)values('CBT-639','mi',2,'T320e',1,2,'SH29GTV00149','353115058202572',getdate(),null,1)
GO
INSERT INTO Device(DeviceID,Name,[Status],Model,Owner,Location,SerialNo,IMEINo,CreateDate,UpdateDate,IsActive)values('CBT-640','Cabots iPad Air2',4,'MH0W2HN/A',1,'DMPPR4EDG5VV',null,null,getdate(),null,1)
GO
INSERT INTO Device(DeviceID,Name,[Status],Model,Owner,Location,SerialNo,IMEINo,CreateDate,UpdateDate,IsActive)values('CBT-641','ipad',2,'A1395',1,2,'DMTGC62WDFHW',null,getdate(),null,1)
GO
INSERT INTO Device(DeviceID,Name,[Status],Model,Owner,Location,SerialNo,IMEINo,CreateDate,UpdateDate,IsActive)values('CBT-672',' ',1,null,6,2,null,null,getdate(),null,1)
GO


Go 
 
Create Table DeviceStatus(
Id int Primary Key Identity(1,1),
UpdateDate DateTime,
SerialNo varchar(250),
IMEINo varchar(250),
Charge varchar(250),
Status int
)
GO


INSERT INTO DeviceStatus(UpdateDate,SerialNo,Charge)values(getdate(),'ZX1G4276NT','30.000002')
INSERT INTO DeviceStatus(UpdateDate,SerialNo,Charge)values(getdate(),'ZY2232T7J4','62')
INSERT INTO DeviceStatus(UpdateDate,SerialNo,Charge)values(getdate(),'TB-7304F','72')
INSERT INTO DeviceStatus(UpdateDate,SerialNo,Charge)values(getdate(),'HT4ALJT03219','46')
INSERT INTO DeviceStatus(UpdateDate,SerialNo,Charge)values(getdate(),'SM-T800','89')
INSERT INTO DeviceStatus(UpdateDate,SerialNo,Charge)values(getdate(),'LGD852ca76a74e','33')
INSERT INTO DeviceStatus(UpdateDate,SerialNo,Charge)values(getdate(),'32048ea1684c91f3','12')
INSERT INTO DeviceStatus(UpdateDate,SerialNo,Charge)values(getdate(),'RZ2GA00Z12L','35')
INSERT INTO DeviceStatus(UpdateDate,SerialNo,Charge)values(getdate(),'R58H522P61Y','56')
INSERT INTO DeviceStatus(UpdateDate,SerialNo,Charge)values(getdate(),'HGAD38LA','23')
INSERT INTO DeviceStatus(UpdateDate,SerialNo,Charge)values(getdate(),'DLXR921CGMLD','67')
INSERT INTO DeviceStatus(UpdateDate,SerialNo,Charge)values(getdate(),'DLXNM7NCG5V3','67')
INSERT INTO DeviceStatus(UpdateDate,SerialNo,Charge)values(getdate(),'F2LNCCENG5QG','34')
INSERT INTO DeviceStatus(UpdateDate,SerialNo,Charge)values(getdate(),'F2LLT2AEFF9V','99')
INSERT INTO DeviceStatus(UpdateDate,SerialNo,Charge)values(getdate(),'F19L44GJFH19','86')
INSERT INTO DeviceStatus(UpdateDate,SerialNo,Charge)values(getdate(),'F9FR8218GHK9','96')
INSERT INTO DeviceStatus(UpdateDate,SerialNo,Charge)values(getdate(),'DMPT10XYHM9','32')
INSERT INTO DeviceStatus(UpdateDate,SerialNo,Charge)values(getdate(),'J3035E67Z38','46')
INSERT INTO DeviceStatus(UpdateDate,SerialNo,Charge)values(getdate(),'8SHQ31207260HB417B2','76')
INSERT INTO DeviceStatus(UpdateDate,SerialNo,Charge)values(getdate(),'DYTHV621DVGJ','89')
INSERT INTO DeviceStatus(UpdateDate,SerialNo,Charge)values(getdate(),'SH29GTV00149','34')
INSERT INTO DeviceStatus(UpdateDate,SerialNo,Charge)values(getdate(),'DMPPR4EDG5VV','12')
INSERT INTO DeviceStatus(UpdateDate,SerialNo,Charge)values(getdate(),'DMTGC62WDFHW','45')
GO


---- Define the CTE expression name and column list.  
--WITH Sales_CTE (SalesPersonID, SalesOrderID, SalesYear)  
--AS  
---- Define the CTE query.  
--(  
--    SELECT SalesPersonID, SalesOrderID, YEAR(OrderDate) AS SalesYear  
--    FROM Sales.SalesOrderHeader  
--    WHERE SalesPersonID IS NOT NULL  
--)  
---- Define the outer query referencing the CTE name.  
--SELECT SalesPersonID, COUNT(SalesOrderID) AS TotalSales, SalesYear  
--FROM Sales_CTE  
--GROUP BY SalesYear, SalesPersonID  
--ORDER BY SalesPersonID, SalesYear;  
--GO  
SET NOCOUNT ON;  
DECLARE    @Asset varchar(280), @product nvarchar(50);  
PRINT '-------- Asset Data rubing --------';  
DECLARE Asset_cursor CURSOR FOR   
SELECT Name from Asset

OPEN Asset_cursor  
FETCH NEXT FROM Asset_cursor INTO @Asset  

IF @@FETCH_STATUS <> 0   
   PRINT @Asset
	
WHILE @@FETCH_STATUS = 0  
BEGIN  

--select * from  Asset Where @Asset like ('%WS%')
PRINT @Asset
	Update Asset set OS='Windows ',OSDescription='Windows System' Where Name like ('%WS%')
	Update Asset set OS='Ubuntu ',OSDescription='Ubuntu System' Where Name like ('%US%')
	Update Asset set OS='Mac System',OSDescription='Mac System' Where Name like ('%MAC%')
----------------------------------------------
	Update Asset set BuiltType='Laptop',BuiltDescription='Windows System' Where Name like ('%LT%')
	Update Asset set BuiltType='Desktop',BuiltDescription='Ubuntu System' Where Name like ('%DT%')
	Update Asset set BuiltType='Desktop',BuiltDescription='Mac System' Where Name like ('%MAC%') AND Name like ('%DT%')
	Update Asset set BuiltType='Server',BuiltDescription='Ubuntu System' Where Name like ('%DT%') and (id>10 and Id<=20 )AND Name like ('%US%')
	Update Asset set BuiltType='Server',BuiltDescription='Windows System' Where Name like ('%DT%') and id<=10 AND Name like ('%WS%')
	Update Asset set BuiltType='Desktop',BuiltDescription='Windows System' Where Name like ('%MAC%') AND Name like ('%DT%')
	PRINT @ASSET
FETCH NEXT FROM Asset_cursor INTO @Asset  
END  

CLOSE Asset_cursor  
DEALLOCATE Asset_cursor  




DROP TABLE Software 
CREATE TABLE [dbo].[Software](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NULL,
	--[IP] [varchar](50) NULL,
	--[Host] [varchar](50) NULL,
	[Version] [varchar](50) NULL,
	[Vendor] [varchar](250) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
--ALTER TABLE [dbo].[Softwares] ADD  DEFAULT ('0.0.0.0') FOR [IP]
--GO
--ALTER TABLE [dbo].[Softwares] ADD  DEFAULT ('0.0.0.0') FOR [Host]
GO
ALTER TABLE [dbo].[Software] ADD  DEFAULT ('0.0.0.0') FOR [Version]
GO
ALTER TABLE [dbo].[Software] ADD  DEFAULT ('') FOR [Vendor]
GO
ALTER TABLE [dbo].[Software] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Software] ADD  DEFAULT (1) FOR [CreatedBy]
GO


-- Get the next Asset.  


--Softwares Windows Laptop 
--Windows XP
--windows 7
--windows 8
--Windows 8.1
--Windows 10
--Softwares Windows Server 
--Windows Server 2003	   
--Windows Server 2003 R2 
--Windows Server 2008	   
--Windows Server 2008 R2 
--Windows Server 2012	   
--Windows Server 2012 R2 
--Windows Server 2016	   
--Windows Server 2019	   
--Visual Studio 2015
--Visual Studio 2017
--MS Office 2019
--MS Office 2016
--MS Office 2013
--MS Office 2010
--MS Office 2007
--MS Office 2003
--SQL Server 2017	
--SQL Server 2016	
--SQL Server 2014	
--SQL Server 2012	
--SQL Server 2008 R2	
--SQL Server 2008	
--SQL Server 2005	
--Softwares Linux Server 
--Red Hat Enterprise Linux
--CentOS
--SUSE Linux Enterprise Server
--Debian
--Ubuntu 
--openSUSE
--Fedora

--Softwares Linux Laptop 
--Ubuntu 
--MySQL 5.1
--MySQL 5.5
--MySQL 5.6
--MySQL 5.7
--MySQL 8.0
--OpenOffice 2
--OpenOffice 3
--Php 5
--Php 6
--Php 7
--Android Studio 2
--Android Studio 3
--PhpStorm 5
--Sublime Text 3
--Notepadd++
--Atom
--Node 8
--SQL Server Management Studio 2016
--SQL Server Management Studio 2017
--SQL Server Management Studio 2018

select * from [Software]
INSERT INTO Software


	 




