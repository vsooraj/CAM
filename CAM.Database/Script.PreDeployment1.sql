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
DROP table Softwares
Truncate table  Softwares
GO
CREATE TABLE Softwares(Id INT primary key identity(1,1), Name VARCHAR(max))
GO

INSERT INTO Softwares VALUES ( 'Apple');
INSERT INTO Softwares VALUES ( 'Samsung');
INSERT INTO Softwares VALUES ( 'OnePlus');
GO

select * from Softwares
GO
Alter table softwares add  createdDate  datetime default getdate()
Alter table softwares add  IP  varchar(50) default '0.0.0.0'

