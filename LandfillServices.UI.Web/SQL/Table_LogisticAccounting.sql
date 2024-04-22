BEGIN TRANSACTION
GO
CREATE TABLE dbo.LogisticAccounting
	(
	ID int NOT NULL IDENTITY (1, 1),
	Created datetime NOT NULL,
	Updated datetime NOT NULL,
	LogisticID int NOT NULL,
	TransferDate datetime NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.LogisticAccounting ADD CONSTRAINT
	PK_LogisticAccounting PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.LogisticAccounting SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
GRANT SELECT, Update, delete , insert ON dbo.LogisticAccounting TO Public 

BEGIN TRANSACTION
GO
ALTER TABLE dbo.LogisticAccounting SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.LogisticPaymentCommissions ADD
	LogisticAccountingID int NULL
GO
ALTER TABLE dbo.LogisticPaymentCommissions ADD CONSTRAINT
	FK_LogisticPaymentCommissions_LogisticAccounting FOREIGN KEY
	(
	LogisticAccountingID
	) REFERENCES dbo.LogisticAccounting
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.LogisticPaymentCommissions SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
GRANT SELECT, Update, delete , insert ON dbo.LogisticPaymentCommissions TO Public 
