 

BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContractsLogistics SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.LogisticTurnCollect
	(
	ID int NOT NULL IDENTITY (1, 1),
	Created datetime NOT NULL,
	Updated datetime NOT NULL,
	ContractsLogisticsID int NOT NULL,
	Distance decimal(18, 2) NOT NULL,
	Date datetime NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.LogisticTurnCollect ADD CONSTRAINT
	PK_LogisticTurnCollect PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.LogisticTurnCollect ADD CONSTRAINT
	FK_LogisticTurnCollect_ContractsLogistics FOREIGN KEY
	(
	ContractsLogisticsID
	) REFERENCES dbo.ContractsLogistics
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.LogisticTurnCollect SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
GRANT SELECT, Update, delete , insert ON dbo.LogisticTurnCollect TO Public
