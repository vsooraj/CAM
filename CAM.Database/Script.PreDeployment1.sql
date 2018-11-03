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

SELECT Id, Name,IP,Host,FORMAT ( InstalledDate, 'd', 'en-gb' ) as InstalledDate,Vendor,Version FROM Softwares

