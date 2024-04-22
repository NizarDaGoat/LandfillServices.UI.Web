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
ALTER TABLE dbo.ContractsLogistics SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.ContratsLogisticsRemuneratedSettings
	(
	ID int NOT NULL IDENTITY (1, 1),
	Created datetime NOT NULL,
	Updated datetime NOT NULL,
	ContratsLogisticsID int NOT NULL,
	KmInterval int NOT NULL,
	Value decimal(18, 2) NOT NULL,
	StartDate datetime NOT NULL,
	EndDate datetime NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.ContratsLogisticsRemuneratedSettings ADD CONSTRAINT
	PK_ContratsLogisticsRemuneratedSettings PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.ContratsLogisticsRemuneratedSettings ADD CONSTRAINT
	FK_ContratsLogisticsRemuneratedSettings_ContractsLogistics FOREIGN KEY
	(
	ContratsLogisticsID
	) REFERENCES dbo.ContractsLogistics
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContratsLogisticsRemuneratedSettings SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
GRANT SELECT, Update, delete , insert ON dbo.ContratsLogisticsRemuneratedSettings TO Public 