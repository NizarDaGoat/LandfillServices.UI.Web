BEGIN TRANSACTION
GO
ALTER TABLE dbo.LogisticTurnCollect SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.LogisticPaymentCommissions
	(
	ID int NOT NULL IDENTITY (1, 1),
	Created datetime NOT NULL,
	Updated datetime NOT NULL,
	LogisticTurnCollectID int NOT NULL,
	Amount decimal(18, 2) NOT NULL,
	PaymentDate datetime NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.LogisticPaymentCommissions ADD CONSTRAINT
	PK_LogisticPaymentCommissions PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.LogisticPaymentCommissions ADD CONSTRAINT
	FK_LogisticPaymentCommissions_LogisticTurnCollect FOREIGN KEY
	(
	LogisticTurnCollectID
	) REFERENCES dbo.LogisticTurnCollect
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.LogisticPaymentCommissions SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
GRANT SELECT, Update, delete , insert ON dbo.LogisticPaymentCommissions TO Public 
