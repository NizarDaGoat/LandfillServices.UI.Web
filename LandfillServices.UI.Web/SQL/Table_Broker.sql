﻿BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.LandfillUser SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Broker
	(
	ID int NOT NULL,
	Created datetime NOT NULL,
	Updated datetime NOT NULL,
	CompanyName nvarchar(200) NOT NULL,
	InternalCode nvarchar(200) NOT NULL,
	CompanyRegistrationNumber nvarchar(200) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Broker ADD CONSTRAINT
	PK_Broker PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Broker ADD CONSTRAINT
	FK_Broker_LandfillUser FOREIGN KEY
	(
	ID
	) REFERENCES dbo.LandfillUser
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Broker SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
GRANT SELECT, Update, delete , insert ON dbo.Broker TO Public 