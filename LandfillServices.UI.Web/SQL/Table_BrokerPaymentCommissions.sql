BEGIN TRANSACTION
GO
ALTER TABLE dbo.BrokerPassageProduct SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.BrokerPaymentCommissions
	(
	ID int NOT NULL IDENTITY (1, 1),
	Created datetime NOT NULL,
	Updated datetime NOT NULL,
	BrokerPassageProductID int NOT NULL,
	Amount decimal(18, 2) NOT NULL,
	PaymentDate datetime NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.BrokerPaymentCommissions ADD CONSTRAINT
	PK_BrokerPaymentCommissions PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.BrokerPaymentCommissions ADD CONSTRAINT
	FK_BrokerPaymentCommissions_BrokerPassageProduct FOREIGN KEY
	(
	BrokerPassageProductID
	) REFERENCES dbo.BrokerPassageProduct
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.BrokerPaymentCommissions SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
GRANT SELECT, Update, delete , insert ON dbo.BrokerPaymentCommissions TO Public 
