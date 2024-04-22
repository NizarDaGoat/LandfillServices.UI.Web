/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
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
CREATE TABLE dbo.LandfillUser
	(
	ID int NOT NULL IDENTITY (1, 1),
	Created datetime NOT NULL,
	Updated datetime NOT NULL,
	CompanyCoperateName nvarchar(200) NULL,
	FirstName nvarchar(200) NULL,
	LastName nvarchar(200) NULL,
	Address nvarchar(500) NULL,
	City nvarchar(200) NULL,
	Email nvarchar(200) NULL,
	PhoneNumber nvarchar(50) NULL,
	Type int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.LandfillUser ADD CONSTRAINT
	PK_LandfillUser PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.LandfillUser SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

GRANT SELECT, Update, delete , insert ON dbo.LandfillUser TO Public 
 

 /* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
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
ALTER TABLE dbo.LandfillUser ADD
	Password nvarchar(200) NULL
GO
ALTER TABLE dbo.LandfillUser SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
