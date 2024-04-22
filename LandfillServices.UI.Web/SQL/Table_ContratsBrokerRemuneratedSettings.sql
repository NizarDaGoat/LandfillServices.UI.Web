BEGIN TRANSACTION
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
ALTER TABLE dbo.ContractsBroker SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.ContratsBrokerRemuneratedSettings
	(
	ID int NOT NULL IDENTITY (1, 1),
	Created datetime NOT NULL,
	Updated datetime NOT NULL,
	ContratsBrokerID int NOT NULL,
	ProductName int NOT NULL,
	Value decimal(18, 2) NOT NULL,
	StartDate datetime NOT NULL,
	EndDate datetime NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.ContratsBrokerRemuneratedSettings ADD CONSTRAINT
	PK_ContratsBrokerRemuneratedSettings PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.ContratsBrokerRemuneratedSettings ADD CONSTRAINT
	FK_ContratsBrokerRemuneratedSettings_ContractsBroker FOREIGN KEY
	(
	ContratsBrokerID
	) REFERENCES dbo.ContractsBroker
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContratsBrokerRemuneratedSettings SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
GRANT SELECT, Update, delete , insert ON dbo.ContratsBrokerRemuneratedSettings TO Public 