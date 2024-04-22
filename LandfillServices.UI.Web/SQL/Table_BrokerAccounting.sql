BEGIN TRANSACTION
GO
CREATE TABLE dbo.BrokerAccounting
	(
	ID int NOT NULL IDENTITY (1, 1),
	Created datetime NOT NULL,
	Updated datetime NOT NULL,
	BrokerID int NOT NULL,
	TransferDate datetime NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.BrokerAccounting ADD CONSTRAINT
	PK_BrokerAccounting PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.BrokerAccounting SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
GRANT SELECT, Update, delete , insert ON dbo.BrokerAccounting TO Public 

BEGIN TRANSACTION
GO
ALTER TABLE dbo.BrokerAccounting SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.BrokerPaymentCommissions ADD
	BrokerAccountingID int NULL
GO
ALTER TABLE dbo.BrokerPaymentCommissions ADD CONSTRAINT
	FK_BrokerPaymentCommissions_BrokerAccounting FOREIGN KEY
	(
	BrokerAccountingID
	) REFERENCES dbo.BrokerAccounting
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.BrokerPaymentCommissions SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
GRANT SELECT, Update, delete , insert ON dbo.BrokerPaymentCommissions TO Public 
