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
CREATE TABLE dbo.Products
	(
	ID int NOT NULL IDENTITY (1, 1),
	Created datetime NOT NULL,
	Updated datetime NOT NULL,
	Name nvarchar(200) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Products ADD CONSTRAINT
	PK_Products PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Products SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
GRANT SELECT, Update, delete , insert ON dbo.Products TO Public 