﻿/*
Deployment script for Feedback.SqlDatabase

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "Feedback.SqlDatabase"
:setvar DefaultFilePrefix "Feedback.SqlDatabase"
:setvar DefaultDataPath ""
:setvar DefaultLogPath ""

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating database $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)] COLLATE SQL_Latin1_General_CP1_CI_AS
GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET TEMPORAL_HISTORY_RETENTION ON 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Creating Table [dbo].[Likes]...';


GO
CREATE TABLE [dbo].[Likes] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [FeedbackId] INT           NOT NULL,
    [UserId]     INT           NOT NULL,
    [LikedAt]    DATETIME2 (7) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Feedback]...';


GO
CREATE TABLE [dbo].[Feedback] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [UserId]    INT            NOT NULL,
    [Content]   NVARCHAR (MAX) NOT NULL,
    [Rating]    INT            NULL,
    [CreatedAt] DATETIME2 (7)  NOT NULL,
    [UpdatedAt] DATETIME2 (7)  NULL,
    [EventId]   INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Likes_Feedback]...';


GO
ALTER TABLE [dbo].[Likes]
    ADD CONSTRAINT [FK_Likes_Feedback] FOREIGN KEY ([FeedbackId]) REFERENCES [dbo].[Feedback] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Creating Check Constraint unnamed constraint on [dbo].[Feedback]...';


GO
ALTER TABLE [dbo].[Feedback]
    ADD CHECK (Rating >= 1 AND Rating <= 5);


GO
PRINT N'Creating Procedure [dbo].[SP_UpdateRecord]...';


GO
CREATE PROCEDURE [dbo].[SP_UpdateRecord]
	-- Add the parameters for the stored procedure here
	@P_tableName nvarchar(50) = null,
	@P_columnsString nvarchar(MAX) = null,
	@P_Id nvarchar = null
AS
BEGIN
	SET NOCOUNT ON;
	
	declare @V_table nvarchar(50) = null
	if (@P_tableName is not null)
		select @V_table = QUOTENAME( TABLE_NAME )
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_NAME = @P_tableName

	declare @V_sql as nvarchar(MAX) = null
	if (@V_table is not null and @P_columnsString is not null and @P_Id is not null)
		SET @V_sql = 'UPDATE ' + @V_table + ' SET ' + @P_columnsString + ' WHERE Id = ' + @P_Id + ';'

	if(@V_sql is not null)
		SELECT(@V_sql)
	else
		SELECT -1;
END
GO
PRINT N'Creating Procedure [dbo].[SP_InsertRecord]...';


GO
CREATE PROCEDURE [dbo].[SP_InsertRecord]
	-- Add the parameters for the stored procedure here
	@P_tableName nvarchar(50) = null,
	@P_columnsString nvarchar(MAX) = null, 
	@P_propertiesString nvarchar(MAX) = null
AS
BEGIN
	SET NOCOUNT ON;
	
	declare @V_table nvarchar(50) = null
	if (@P_tableName is not null)
		select @V_table = QUOTENAME( TABLE_NAME )
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_NAME = @P_tableName

	declare @V_sql as nvarchar(MAX) = null
	if (@V_table is not null and @P_columnsString is not null and @P_propertiesString is not null)
		SET @V_sql = 'INSERT INTO ' + @V_table + ' (' + @P_columnsString + ') VALUES (' + @P_propertiesString + ');'
	
	if(@V_sql is not null)
		SELECT @V_sql;
	else
		SELECT -1;
END
GO
PRINT N'Creating Procedure [dbo].[SP_GetRecordById]...';


GO
CREATE PROCEDURE [dbo].[SP_GetRecordById]
	-- Add the parameters for the stored procedure here
	@P_tableName nvarchar(50) = null,
	@P_Id nvarchar = null
AS
BEGIN
	SET NOCOUNT ON;
	
	declare @V_table nvarchar(50) = null
	if (@P_tableName is not null)
		select @V_table = QUOTENAME( TABLE_NAME )
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_NAME = @P_tableName

	declare @V_sql as nvarchar(MAX) = null
	if (@V_table is not null and @P_Id is not null)
		select @V_sql = 'select * from ' + @V_table + ' where Id = ' + @P_Id + ';'

	if(@V_sql is not null)
		exec(@V_sql)
	else
		select -1;
END
GO
PRINT N'Creating Procedure [dbo].[SP_DeleteRecord]...';


GO
CREATE PROCEDURE [dbo].[SP_DeleteRecord]
	-- Add the parameters for the stored procedure here
	@P_tableName nvarchar(50) = null,
	@P_Id nvarchar = null
AS
BEGIN
	SET NOCOUNT ON;
	
	declare @V_table nvarchar(50) = null
	if (@P_tableName is not null)
		select @V_table = QUOTENAME( TABLE_NAME )
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_NAME = @P_tableName

	declare @V_sql as nvarchar(MAX) = null
	if (@V_table is not null and @P_Id is not null)
		SELECT @V_sql = 'DELETE FROM ' + @V_table + 'WHERE ID = ' + @P_Id + ';'

	if(@V_sql is not null)
		EXEC(@V_sql)
	else
		select 0;
END
GO
PRINT N'Creating Procedure [dbo].[SP_GetAllRecords]...';


GO
CREATE PROCEDURE [dbo].[SP_GetAllRecords]
	-- Add the parameters for the stored procedure here
	@P_tableName nvarchar(50) = null
AS
BEGIN
	SET NOCOUNT ON;
	
	declare @V_table nvarchar(50) = null
	if (@P_tableName is not null)
		select @V_table = QUOTENAME( TABLE_NAME )
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_NAME = @P_tableName

	declare @V_sql as nvarchar(MAX) = null
	if (@V_table is not null)
		select @V_sql = 'select * from ' + @V_table + ';'

	if(@V_sql is not null)
		exec(@V_sql)
	else
		select -1;
END
GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET MULTI_USER 
    WITH ROLLBACK IMMEDIATE;


GO
PRINT N'Update complete.';


GO