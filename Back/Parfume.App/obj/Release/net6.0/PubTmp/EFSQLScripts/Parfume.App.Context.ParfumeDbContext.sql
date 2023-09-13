IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230815193437_initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230815193437_initial', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230816095910_AppUser')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230816095910_AppUser')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Surname] nvarchar(max) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230816095910_AppUser')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230816095910_AppUser')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230816095910_AppUser')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230816095910_AppUser')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230816095910_AppUser')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230816095910_AppUser')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230816095910_AppUser')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230816095910_AppUser')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230816095910_AppUser')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230816095910_AppUser')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230816095910_AppUser')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230816095910_AppUser')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230816095910_AppUser')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230816095910_AppUser', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230817124945_FakeDatasTable')
BEGIN
    CREATE TABLE [FakeSlides] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Surname] nvarchar(max) NOT NULL,
        [City] nvarchar(max) NOT NULL,
        [Country] nvarchar(max) NOT NULL,
        [Thoughts] nvarchar(max) NOT NULL,
        [Image] nvarchar(max) NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_FakeSlides] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230817124945_FakeDatasTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230817124945_FakeDatasTable', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230818075337_SliderTable')
BEGIN
    CREATE TABLE [Slides] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NOT NULL,
        [Desc] nvarchar(max) NOT NULL,
        [Image] nvarchar(max) NOT NULL,
        [Chooice] nvarchar(max) NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Slides] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230818075337_SliderTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230818075337_SliderTable', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230818111103_GiftBoxTable')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Slides]') AND [c].[name] = N'Image');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Slides] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Slides] ALTER COLUMN [Image] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230818111103_GiftBoxTable')
BEGIN
    CREATE TABLE [GiftBoxes] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NOT NULL,
        [Desc] nvarchar(max) NOT NULL,
        [Image] nvarchar(max) NULL,
        [Price] int NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_GiftBoxes] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230818111103_GiftBoxTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230818111103_GiftBoxTable', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230818154820_PlaceTableDb')
BEGIN
    CREATE TABLE [Places] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NOT NULL,
        [Address] nvarchar(max) NOT NULL,
        [Phone1] nvarchar(max) NOT NULL,
        [Phone2] nvarchar(max) NOT NULL,
        [Location] nvarchar(max) NOT NULL,
        [Image] nvarchar(max) NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Places] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230818154820_PlaceTableDb')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230818154820_PlaceTableDb', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230818172337_SubscribeTable')
BEGIN
    CREATE TABLE [Subscribes] (
        [Id] int NOT NULL IDENTITY,
        [Email] nvarchar(max) NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Subscribes] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230818172337_SubscribeTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230818172337_SubscribeTable', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230818193323_SendMessageTable')
BEGIN
    CREATE TABLE [Messages] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [Subject] nvarchar(max) NOT NULL,
        [Message] nvarchar(max) NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Messages] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230818193323_SendMessageTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230818193323_SendMessageTable', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230819082553_Function')
BEGIN
    CREATE TABLE [Functions] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NOT NULL,
        [Desc] nvarchar(max) NOT NULL,
        [Icon] nvarchar(max) NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Functions] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230819082553_Function')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230819082553_Function', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230819092129_updateFunctions')
BEGIN
    EXEC sp_rename N'[Functions].[Icon]', N'Link', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230819092129_updateFunctions')
BEGIN
    ALTER TABLE [Functions] ADD [Image] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230819092129_updateFunctions')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230819092129_updateFunctions', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230819175301_SettingTable')
BEGIN
    CREATE TABLE [Settings] (
        [Id] int NOT NULL IDENTITY,
        [Key] nvarchar(max) NOT NULL,
        [Value] nvarchar(max) NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Settings] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230819175301_SettingTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230819175301_SettingTable', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230819192653_SettingContactTable')
BEGIN
    DROP TABLE [Settings];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230819192653_SettingContactTable')
BEGIN
    CREATE TABLE [SettingContact] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [Phone1] nvarchar(max) NOT NULL,
        [Phone2] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [Loc1] nvarchar(max) NOT NULL,
        [Loc2] nvarchar(max) NOT NULL,
        [ImageLoc] nvarchar(max) NOT NULL,
        [ImageTel] nvarchar(max) NOT NULL,
        [ImageEmail] nvarchar(max) NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_SettingContact] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230819192653_SettingContactTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230819192653_SettingContactTable', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230820102029_SettingFooterTable')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[SettingContact]') AND [c].[name] = N'ImageTel');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [SettingContact] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [SettingContact] ALTER COLUMN [ImageTel] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230820102029_SettingFooterTable')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[SettingContact]') AND [c].[name] = N'ImageLoc');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [SettingContact] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [SettingContact] ALTER COLUMN [ImageLoc] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230820102029_SettingFooterTable')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[SettingContact]') AND [c].[name] = N'ImageEmail');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [SettingContact] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [SettingContact] ALTER COLUMN [ImageEmail] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230820102029_SettingFooterTable')
BEGIN
    CREATE TABLE [SettingFooter] (
        [Id] int NOT NULL IDENTITY,
        [Title1] nvarchar(max) NOT NULL,
        [Title2] nvarchar(max) NOT NULL,
        [Title3] nvarchar(max) NOT NULL,
        [Title4] nvarchar(max) NOT NULL,
        [Title1Par1] nvarchar(max) NOT NULL,
        [Title1Par2] nvarchar(max) NOT NULL,
        [Title2Par1] nvarchar(max) NOT NULL,
        [Title2Par2] nvarchar(max) NOT NULL,
        [Title3Par1] nvarchar(max) NOT NULL,
        [Title3Par2] nvarchar(max) NOT NULL,
        [Title4Par1] nvarchar(max) NOT NULL,
        [Title4Par2] nvarchar(max) NOT NULL,
        [FootIcon1] nvarchar(max) NOT NULL,
        [FootIcon2] nvarchar(max) NOT NULL,
        [FootIcon3] nvarchar(max) NOT NULL,
        [FootIcon4] nvarchar(max) NOT NULL,
        [Link1] nvarchar(max) NOT NULL,
        [Link2] nvarchar(max) NOT NULL,
        [Link3] nvarchar(max) NOT NULL,
        [Link4] nvarchar(max) NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_SettingFooter] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230820102029_SettingFooterTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230820102029_SettingFooterTable', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230820115645_SettingFooterTableUpdate')
BEGIN
    ALTER TABLE [SettingFooter] ADD [Title1Link] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230820115645_SettingFooterTableUpdate')
BEGIN
    ALTER TABLE [SettingFooter] ADD [Title2Link] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230820115645_SettingFooterTableUpdate')
BEGIN
    ALTER TABLE [SettingFooter] ADD [Title3Link] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230820115645_SettingFooterTableUpdate')
BEGIN
    ALTER TABLE [SettingFooter] ADD [Title4Link] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230820115645_SettingFooterTableUpdate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230820115645_SettingFooterTableUpdate', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230820124436_SettingFooterTableUpdatesecond')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[SettingFooter]') AND [c].[name] = N'Title1Link');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [SettingFooter] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [SettingFooter] DROP COLUMN [Title1Link];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230820124436_SettingFooterTableUpdatesecond')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[SettingFooter]') AND [c].[name] = N'Title2Link');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [SettingFooter] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [SettingFooter] DROP COLUMN [Title2Link];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230820124436_SettingFooterTableUpdatesecond')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[SettingFooter]') AND [c].[name] = N'Title3Link');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [SettingFooter] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [SettingFooter] DROP COLUMN [Title3Link];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230820124436_SettingFooterTableUpdatesecond')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[SettingFooter]') AND [c].[name] = N'Title4Link');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [SettingFooter] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [SettingFooter] DROP COLUMN [Title4Link];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230820124436_SettingFooterTableUpdatesecond')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230820124436_SettingFooterTableUpdatesecond', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230820125802_SettingNavbar')
BEGIN
    CREATE TABLE [SettingNavbar] (
        [Id] int NOT NULL IDENTITY,
        [Logo] nvarchar(max) NULL,
        [Hamburger] nvarchar(max) NULL,
        [Delete] nvarchar(max) NULL,
        [Icon1] nvarchar(max) NOT NULL,
        [Icon2] nvarchar(max) NOT NULL,
        [Icon3] nvarchar(max) NOT NULL,
        [SiderbarP1] nvarchar(max) NOT NULL,
        [SiderbarP2] nvarchar(max) NOT NULL,
        [SiderbarP3] nvarchar(max) NOT NULL,
        [SiderbarP4] nvarchar(max) NOT NULL,
        [SiderbarP5] nvarchar(max) NOT NULL,
        [SiderbarP6] nvarchar(max) NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_SettingNavbar] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230820125802_SettingNavbar')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230820125802_SettingNavbar', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230820183854_HomePage')
BEGIN
    CREATE TABLE [SettingHomePage] (
        [Id] int NOT NULL IDENTITY,
        [TitleGift] nvarchar(max) NOT NULL,
        [DescriptionGift] nvarchar(max) NOT NULL,
        [ImageGift1] nvarchar(max) NOT NULL,
        [ImageGift2] nvarchar(max) NOT NULL,
        [DescTester] nvarchar(max) NOT NULL,
        [ImageTester] nvarchar(max) NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_SettingHomePage] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230820183854_HomePage')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230820183854_HomePage', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230820193527_About')
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[SettingHomePage]') AND [c].[name] = N'ImageTester');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [SettingHomePage] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [SettingHomePage] ALTER COLUMN [ImageTester] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230820193527_About')
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[SettingHomePage]') AND [c].[name] = N'ImageGift2');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [SettingHomePage] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [SettingHomePage] ALTER COLUMN [ImageGift2] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230820193527_About')
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[SettingHomePage]') AND [c].[name] = N'ImageGift1');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [SettingHomePage] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [SettingHomePage] ALTER COLUMN [ImageGift1] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230820193527_About')
BEGIN
    CREATE TABLE [SettingAbout] (
        [Id] int NOT NULL IDENTITY,
        [ImageWho1] nvarchar(max) NULL,
        [ImageWho2] nvarchar(max) NULL,
        [ImageWhy1] nvarchar(max) NULL,
        [ImageWhy2] nvarchar(max) NULL,
        [WhoTitle] nvarchar(max) NOT NULL,
        [WhoP1] nvarchar(max) NOT NULL,
        [WhoP2] nvarchar(max) NOT NULL,
        [WhoP3] nvarchar(max) NOT NULL,
        [WhyTitle] nvarchar(max) NOT NULL,
        [WhyP1] nvarchar(max) NOT NULL,
        [WhyP2] nvarchar(max) NOT NULL,
        [Icon1] nvarchar(max) NOT NULL,
        [Icon2] nvarchar(max) NOT NULL,
        [Icon3] nvarchar(max) NOT NULL,
        [Icon4] nvarchar(max) NOT NULL,
        [IconP1] nvarchar(max) NOT NULL,
        [IconP2] nvarchar(max) NOT NULL,
        [IconP3] nvarchar(max) NOT NULL,
        [IconP4] nvarchar(max) NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_SettingAbout] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230820193527_About')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230820193527_About', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821091431_BrandTesterTables')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230821091431_BrandTesterTables', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821091500_BrandTesterTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230821091500_BrandTesterTable', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821091822_BrandTesterTableUpdate')
BEGIN
    CREATE TABLE [Brands] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Brands] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821091822_BrandTesterTableUpdate')
BEGIN
    CREATE TABLE [Testers] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NOT NULL,
        [BuyPrice] nvarchar(max) NOT NULL,
        [SellPrice] nvarchar(max) NOT NULL,
        [CountSell] int NULL,
        [TimeSell] datetime2 NULL,
        [Image] nvarchar(max) NULL,
        [BrandId] int NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Testers] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Testers_Brands_BrandId] FOREIGN KEY ([BrandId]) REFERENCES [Brands] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821091822_BrandTesterTableUpdate')
BEGIN
    CREATE INDEX [IX_Testers_BrandId] ON [Testers] ([BrandId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821091822_BrandTesterTableUpdate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230821091822_BrandTesterTableUpdate', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821143943_ParfumTable')
BEGIN
    ALTER TABLE [Testers] DROP CONSTRAINT [FK_Testers_Brands_BrandId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821143943_ParfumTable')
BEGIN
    DECLARE @var11 sysname;
    SELECT @var11 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Testers]') AND [c].[name] = N'BrandId');
    IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [Testers] DROP CONSTRAINT [' + @var11 + '];');
    ALTER TABLE [Testers] ALTER COLUMN [BrandId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821143943_ParfumTable')
BEGIN
    CREATE TABLE [Parfums] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NOT NULL,
        [Desc] nvarchar(max) NOT NULL,
        [Info1] nvarchar(max) NOT NULL,
        [Info2] nvarchar(max) NOT NULL,
        [ProductCode] nvarchar(max) NOT NULL,
        [IsNew] bit NOT NULL,
        [IsTrend] bit NOT NULL,
        [IsDiscount] bit NOT NULL,
        [IsStock] bit NOT NULL,
        [DiscountPercentage] int NULL,
        [Image] nvarchar(max) NULL,
        [BuyPrice] nvarchar(max) NOT NULL,
        [SellPrice] nvarchar(max) NOT NULL,
        [CountSell] int NULL,
        [TimeSell] datetime2 NULL,
        [BrandId] int NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Parfums] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Parfums_Brands_BrandId] FOREIGN KEY ([BrandId]) REFERENCES [Brands] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821143943_ParfumTable')
BEGIN
    CREATE TABLE [Volume] (
        [Id] int NOT NULL IDENTITY,
        [MilliLiters] int NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Volume] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821143943_ParfumTable')
BEGIN
    CREATE TABLE [ParfumVolume] (
        [Id] int NOT NULL IDENTITY,
        [ParfumId] int NOT NULL,
        [VolumeId] int NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_ParfumVolume] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ParfumVolume_Parfums_ParfumId] FOREIGN KEY ([ParfumId]) REFERENCES [Parfums] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ParfumVolume_Volume_VolumeId] FOREIGN KEY ([VolumeId]) REFERENCES [Volume] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821143943_ParfumTable')
BEGIN
    CREATE INDEX [IX_Parfums_BrandId] ON [Parfums] ([BrandId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821143943_ParfumTable')
BEGIN
    CREATE INDEX [IX_ParfumVolume_ParfumId] ON [ParfumVolume] ([ParfumId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821143943_ParfumTable')
BEGIN
    CREATE INDEX [IX_ParfumVolume_VolumeId] ON [ParfumVolume] ([VolumeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821143943_ParfumTable')
BEGIN
    ALTER TABLE [Testers] ADD CONSTRAINT [FK_Testers_Brands_BrandId] FOREIGN KEY ([BrandId]) REFERENCES [Brands] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821143943_ParfumTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230821143943_ParfumTable', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821145158_VolumeTable')
BEGIN
    ALTER TABLE [ParfumVolume] DROP CONSTRAINT [FK_ParfumVolume_Volume_VolumeId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821145158_VolumeTable')
BEGIN
    ALTER TABLE [Volume] DROP CONSTRAINT [PK_Volume];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821145158_VolumeTable')
BEGIN
    EXEC sp_rename N'[Volume]', N'Volumes';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821145158_VolumeTable')
BEGIN
    ALTER TABLE [Volumes] ADD CONSTRAINT [PK_Volumes] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821145158_VolumeTable')
BEGIN
    ALTER TABLE [ParfumVolume] ADD CONSTRAINT [FK_ParfumVolume_Volumes_VolumeId] FOREIGN KEY ([VolumeId]) REFERENCES [Volumes] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821145158_VolumeTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230821145158_VolumeTable', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821192806_ParfumeVolumeTable')
BEGIN
    ALTER TABLE [Parfums] DROP CONSTRAINT [FK_Parfums_Brands_BrandId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821192806_ParfumeVolumeTable')
BEGIN
    ALTER TABLE [ParfumVolume] DROP CONSTRAINT [FK_ParfumVolume_Parfums_ParfumId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821192806_ParfumeVolumeTable')
BEGIN
    ALTER TABLE [ParfumVolume] DROP CONSTRAINT [FK_ParfumVolume_Volumes_VolumeId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821192806_ParfumeVolumeTable')
BEGIN
    ALTER TABLE [ParfumVolume] DROP CONSTRAINT [PK_ParfumVolume];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821192806_ParfumeVolumeTable')
BEGIN
    EXEC sp_rename N'[ParfumVolume]', N'ParfumeVolumes';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821192806_ParfumeVolumeTable')
BEGIN
    EXEC sp_rename N'[ParfumeVolumes].[IX_ParfumVolume_VolumeId]', N'IX_ParfumeVolumes_VolumeId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821192806_ParfumeVolumeTable')
BEGIN
    EXEC sp_rename N'[ParfumeVolumes].[IX_ParfumVolume_ParfumId]', N'IX_ParfumeVolumes_ParfumId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821192806_ParfumeVolumeTable')
BEGIN
    DECLARE @var12 sysname;
    SELECT @var12 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Parfums]') AND [c].[name] = N'BrandId');
    IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [Parfums] DROP CONSTRAINT [' + @var12 + '];');
    ALTER TABLE [Parfums] ALTER COLUMN [BrandId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821192806_ParfumeVolumeTable')
BEGIN
    ALTER TABLE [ParfumeVolumes] ADD CONSTRAINT [PK_ParfumeVolumes] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821192806_ParfumeVolumeTable')
BEGIN
    ALTER TABLE [ParfumeVolumes] ADD CONSTRAINT [FK_ParfumeVolumes_Parfums_ParfumId] FOREIGN KEY ([ParfumId]) REFERENCES [Parfums] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821192806_ParfumeVolumeTable')
BEGIN
    ALTER TABLE [ParfumeVolumes] ADD CONSTRAINT [FK_ParfumeVolumes_Volumes_VolumeId] FOREIGN KEY ([VolumeId]) REFERENCES [Volumes] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821192806_ParfumeVolumeTable')
BEGIN
    ALTER TABLE [Parfums] ADD CONSTRAINT [FK_Parfums_Brands_BrandId] FOREIGN KEY ([BrandId]) REFERENCES [Brands] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821192806_ParfumeVolumeTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230821192806_ParfumeVolumeTable', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230822134326_CommentRatingLikeDislikeParfumTable')
BEGIN
    CREATE TABLE [CommentPs] (
        [Id] int NOT NULL IDENTITY,
        [ParfumId] int NULL,
        [AppUserId] nvarchar(450) NULL,
        [Title] nvarchar(max) NOT NULL,
        [Desc] nvarchar(max) NOT NULL,
        [RatingId] nvarchar(max) NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_CommentPs] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_CommentPs_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]),
        CONSTRAINT [FK_CommentPs_Parfums_ParfumId] FOREIGN KEY ([ParfumId]) REFERENCES [Parfums] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230822134326_CommentRatingLikeDislikeParfumTable')
BEGIN
    CREATE TABLE [DislikePs] (
        [Id] int NOT NULL IDENTITY,
        [CommentPId] int NULL,
        [CountDislike] int NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_DislikePs] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_DislikePs_CommentPs_CommentPId] FOREIGN KEY ([CommentPId]) REFERENCES [CommentPs] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230822134326_CommentRatingLikeDislikeParfumTable')
BEGIN
    CREATE TABLE [LikePs] (
        [Id] int NOT NULL IDENTITY,
        [CommentPId] int NULL,
        [CountLike] int NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_LikePs] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_LikePs_CommentPs_CommentPId] FOREIGN KEY ([CommentPId]) REFERENCES [CommentPs] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230822134326_CommentRatingLikeDislikeParfumTable')
BEGIN
    CREATE TABLE [RatingPs] (
        [Id] int NOT NULL IDENTITY,
        [AvarageRating] float NOT NULL,
        [RatingCount] float NOT NULL,
        [ParfumId] int NULL,
        [CommentPId] int NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_RatingPs] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_RatingPs_CommentPs_CommentPId] FOREIGN KEY ([CommentPId]) REFERENCES [CommentPs] ([Id]),
        CONSTRAINT [FK_RatingPs_Parfums_ParfumId] FOREIGN KEY ([ParfumId]) REFERENCES [Parfums] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230822134326_CommentRatingLikeDislikeParfumTable')
BEGIN
    CREATE INDEX [IX_CommentPs_AppUserId] ON [CommentPs] ([AppUserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230822134326_CommentRatingLikeDislikeParfumTable')
BEGIN
    CREATE INDEX [IX_CommentPs_ParfumId] ON [CommentPs] ([ParfumId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230822134326_CommentRatingLikeDislikeParfumTable')
BEGIN
    CREATE INDEX [IX_DislikePs_CommentPId] ON [DislikePs] ([CommentPId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230822134326_CommentRatingLikeDislikeParfumTable')
BEGIN
    CREATE INDEX [IX_LikePs_CommentPId] ON [LikePs] ([CommentPId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230822134326_CommentRatingLikeDislikeParfumTable')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [IX_RatingPs_CommentPId] ON [RatingPs] ([CommentPId]) WHERE [CommentPId] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230822134326_CommentRatingLikeDislikeParfumTable')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [IX_RatingPs_ParfumId] ON [RatingPs] ([ParfumId]) WHERE [ParfumId] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230822134326_CommentRatingLikeDislikeParfumTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230822134326_CommentRatingLikeDislikeParfumTable', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230822190220_UpdateComment')
BEGIN
    ALTER TABLE [CommentPs] ADD [star1] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230822190220_UpdateComment')
BEGIN
    ALTER TABLE [CommentPs] ADD [star2] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230822190220_UpdateComment')
BEGIN
    ALTER TABLE [CommentPs] ADD [star3] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230822190220_UpdateComment')
BEGIN
    ALTER TABLE [CommentPs] ADD [star4] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230822190220_UpdateComment')
BEGIN
    ALTER TABLE [CommentPs] ADD [star5] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230822190220_UpdateComment')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230822190220_UpdateComment', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    ALTER TABLE [CommentPs] DROP CONSTRAINT [FK_CommentPs_AspNetUsers_AppUserId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    ALTER TABLE [CommentPs] DROP CONSTRAINT [FK_CommentPs_Parfums_ParfumId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    ALTER TABLE [DislikePs] DROP CONSTRAINT [FK_DislikePs_CommentPs_CommentPId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    ALTER TABLE [LikePs] DROP CONSTRAINT [FK_LikePs_CommentPs_CommentPId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    ALTER TABLE [RatingPs] DROP CONSTRAINT [FK_RatingPs_CommentPs_CommentPId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    ALTER TABLE [RatingPs] DROP CONSTRAINT [FK_RatingPs_Parfums_ParfumId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    ALTER TABLE [RatingPs] DROP CONSTRAINT [PK_RatingPs];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    ALTER TABLE [LikePs] DROP CONSTRAINT [PK_LikePs];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    ALTER TABLE [DislikePs] DROP CONSTRAINT [PK_DislikePs];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    ALTER TABLE [CommentPs] DROP CONSTRAINT [PK_CommentPs];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    DECLARE @var13 sysname;
    SELECT @var13 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CommentPs]') AND [c].[name] = N'star1');
    IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [CommentPs] DROP CONSTRAINT [' + @var13 + '];');
    ALTER TABLE [CommentPs] DROP COLUMN [star1];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    DECLARE @var14 sysname;
    SELECT @var14 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CommentPs]') AND [c].[name] = N'star2');
    IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [CommentPs] DROP CONSTRAINT [' + @var14 + '];');
    ALTER TABLE [CommentPs] DROP COLUMN [star2];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    DECLARE @var15 sysname;
    SELECT @var15 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CommentPs]') AND [c].[name] = N'star3');
    IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [CommentPs] DROP CONSTRAINT [' + @var15 + '];');
    ALTER TABLE [CommentPs] DROP COLUMN [star3];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    DECLARE @var16 sysname;
    SELECT @var16 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CommentPs]') AND [c].[name] = N'star4');
    IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [CommentPs] DROP CONSTRAINT [' + @var16 + '];');
    ALTER TABLE [CommentPs] DROP COLUMN [star4];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    DECLARE @var17 sysname;
    SELECT @var17 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CommentPs]') AND [c].[name] = N'star5');
    IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [CommentPs] DROP CONSTRAINT [' + @var17 + '];');
    ALTER TABLE [CommentPs] DROP COLUMN [star5];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    EXEC sp_rename N'[RatingPs]', N'Rating';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    EXEC sp_rename N'[LikePs]', N'LikeP';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    EXEC sp_rename N'[DislikePs]', N'DislikeP';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    EXEC sp_rename N'[CommentPs]', N'CommentP';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    EXEC sp_rename N'[Rating].[IX_RatingPs_ParfumId]', N'IX_Rating_ParfumId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    EXEC sp_rename N'[Rating].[IX_RatingPs_CommentPId]', N'IX_Rating_CommentPId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    EXEC sp_rename N'[LikeP].[IX_LikePs_CommentPId]', N'IX_LikeP_CommentPId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    EXEC sp_rename N'[DislikeP].[IX_DislikePs_CommentPId]', N'IX_DislikeP_CommentPId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    EXEC sp_rename N'[CommentP].[IX_CommentPs_ParfumId]', N'IX_CommentP_ParfumId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    EXEC sp_rename N'[CommentP].[IX_CommentPs_AppUserId]', N'IX_CommentP_AppUserId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    ALTER TABLE [SettingHomePage] ADD [DescSmoke] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    ALTER TABLE [SettingHomePage] ADD [ImageSmoke] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    ALTER TABLE [Rating] ADD CONSTRAINT [PK_Rating] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    ALTER TABLE [LikeP] ADD CONSTRAINT [PK_LikeP] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    ALTER TABLE [DislikeP] ADD CONSTRAINT [PK_DislikeP] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    ALTER TABLE [CommentP] ADD CONSTRAINT [PK_CommentP] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    ALTER TABLE [CommentP] ADD CONSTRAINT [FK_CommentP_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    ALTER TABLE [CommentP] ADD CONSTRAINT [FK_CommentP_Parfums_ParfumId] FOREIGN KEY ([ParfumId]) REFERENCES [Parfums] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    ALTER TABLE [DislikeP] ADD CONSTRAINT [FK_DislikeP_CommentP_CommentPId] FOREIGN KEY ([CommentPId]) REFERENCES [CommentP] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    ALTER TABLE [LikeP] ADD CONSTRAINT [FK_LikeP_CommentP_CommentPId] FOREIGN KEY ([CommentPId]) REFERENCES [CommentP] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    ALTER TABLE [Rating] ADD CONSTRAINT [FK_Rating_CommentP_CommentPId] FOREIGN KEY ([CommentPId]) REFERENCES [CommentP] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    ALTER TABLE [Rating] ADD CONSTRAINT [FK_Rating_Parfums_ParfumId] FOREIGN KEY ([ParfumId]) REFERENCES [Parfums] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823113527_UpdateSettinHomePageTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230823113527_UpdateSettinHomePageTable', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823114509_UpdateSettinHomePageTabl')
BEGIN
    DROP TABLE [DislikeP];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823114509_UpdateSettinHomePageTabl')
BEGIN
    DROP TABLE [LikeP];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823114509_UpdateSettinHomePageTabl')
BEGIN
    DROP TABLE [Rating];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823114509_UpdateSettinHomePageTabl')
BEGIN
    DROP TABLE [CommentP];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823114509_UpdateSettinHomePageTabl')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230823114509_UpdateSettinHomePageTabl', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823120452_SmokeTable')
BEGIN
    CREATE TABLE [Smokes] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NOT NULL,
        [Desc] nvarchar(max) NOT NULL,
        [Info1] nvarchar(max) NOT NULL,
        [Info2] nvarchar(max) NOT NULL,
        [ProductCode] nvarchar(max) NOT NULL,
        [IsDiscount] bit NOT NULL,
        [IsStock] bit NOT NULL,
        [DiscountPercentage] int NULL,
        [Image] nvarchar(max) NULL,
        [BuyPrice] nvarchar(max) NOT NULL,
        [SellPrice] nvarchar(max) NOT NULL,
        [CountSell] int NULL,
        [TimeSell] datetime2 NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Smokes] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230823120452_SmokeTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230823120452_SmokeTable', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230824090532_BasketAndBasketItemTables')
BEGIN
    CREATE TABLE [Baskets] (
        [Id] int NOT NULL IDENTITY,
        [AppUserId] nvarchar(450) NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Baskets] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Baskets_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230824090532_BasketAndBasketItemTables')
BEGIN
    CREATE TABLE [BasketItems] (
        [Id] int NOT NULL IDENTITY,
        [BasketId] int NOT NULL,
        [ParfumId] int NOT NULL,
        [ParfumCount] int NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_BasketItems] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_BasketItems_Baskets_BasketId] FOREIGN KEY ([BasketId]) REFERENCES [Baskets] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_BasketItems_Parfums_ParfumId] FOREIGN KEY ([ParfumId]) REFERENCES [Parfums] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230824090532_BasketAndBasketItemTables')
BEGIN
    CREATE INDEX [IX_BasketItems_BasketId] ON [BasketItems] ([BasketId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230824090532_BasketAndBasketItemTables')
BEGIN
    CREATE INDEX [IX_BasketItems_ParfumId] ON [BasketItems] ([ParfumId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230824090532_BasketAndBasketItemTables')
BEGIN
    CREATE INDEX [IX_Baskets_AppUserId] ON [Baskets] ([AppUserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230824090532_BasketAndBasketItemTables')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230824090532_BasketAndBasketItemTables', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230829113309_update')
BEGIN
    ALTER TABLE [BasketItems] DROP CONSTRAINT [FK_BasketItems_Baskets_BasketId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230829113309_update')
BEGIN
    ALTER TABLE [BasketItems] DROP CONSTRAINT [FK_BasketItems_Parfums_ParfumId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230829113309_update')
BEGIN
    ALTER TABLE [Baskets] DROP CONSTRAINT [FK_Baskets_AspNetUsers_AppUserId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230829113309_update')
BEGIN
    DROP TABLE [ParfumeVolumes];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230829113309_update')
BEGIN
    ALTER TABLE [Baskets] DROP CONSTRAINT [PK_Baskets];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230829113309_update')
BEGIN
    ALTER TABLE [BasketItems] DROP CONSTRAINT [PK_BasketItems];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230829113309_update')
BEGIN
    EXEC sp_rename N'[Baskets]', N'Basket';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230829113309_update')
BEGIN
    EXEC sp_rename N'[BasketItems]', N'BasketItem';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230829113309_update')
BEGIN
    EXEC sp_rename N'[Basket].[IX_Baskets_AppUserId]', N'IX_Basket_AppUserId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230829113309_update')
BEGIN
    EXEC sp_rename N'[BasketItem].[IX_BasketItems_ParfumId]', N'IX_BasketItem_ParfumId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230829113309_update')
BEGIN
    EXEC sp_rename N'[BasketItem].[IX_BasketItems_BasketId]', N'IX_BasketItem_BasketId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230829113309_update')
BEGIN
    ALTER TABLE [Parfums] ADD [VolumeId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230829113309_update')
BEGIN
    ALTER TABLE [BasketItem] ADD [ParfumVolume] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230829113309_update')
BEGIN
    ALTER TABLE [Basket] ADD CONSTRAINT [PK_Basket] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230829113309_update')
BEGIN
    ALTER TABLE [BasketItem] ADD CONSTRAINT [PK_BasketItem] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230829113309_update')
BEGIN
    CREATE INDEX [IX_Parfums_VolumeId] ON [Parfums] ([VolumeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230829113309_update')
BEGIN
    ALTER TABLE [Basket] ADD CONSTRAINT [FK_Basket_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230829113309_update')
BEGIN
    ALTER TABLE [BasketItem] ADD CONSTRAINT [FK_BasketItem_Basket_BasketId] FOREIGN KEY ([BasketId]) REFERENCES [Basket] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230829113309_update')
BEGIN
    ALTER TABLE [BasketItem] ADD CONSTRAINT [FK_BasketItem_Parfums_ParfumId] FOREIGN KEY ([ParfumId]) REFERENCES [Parfums] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230829113309_update')
BEGIN
    ALTER TABLE [Parfums] ADD CONSTRAINT [FK_Parfums_Volumes_VolumeId] FOREIGN KEY ([VolumeId]) REFERENCES [Volumes] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230829113309_update')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230829113309_update', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230829120325_basketpart')
BEGIN
    ALTER TABLE [Basket] DROP CONSTRAINT [FK_Basket_AspNetUsers_AppUserId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230829120325_basketpart')
BEGIN
    ALTER TABLE [BasketItem] DROP CONSTRAINT [FK_BasketItem_Basket_BasketId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230829120325_basketpart')
BEGIN
    ALTER TABLE [BasketItem] DROP CONSTRAINT [FK_BasketItem_Parfums_ParfumId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230829120325_basketpart')
BEGIN
    ALTER TABLE [BasketItem] DROP CONSTRAINT [PK_BasketItem];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230829120325_basketpart')
BEGIN
    ALTER TABLE [Basket] DROP CONSTRAINT [PK_Basket];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230829120325_basketpart')
BEGIN
    EXEC sp_rename N'[BasketItem]', N'BasketItems';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230829120325_basketpart')
BEGIN
    EXEC sp_rename N'[Basket]', N'Baskets';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230829120325_basketpart')
BEGIN
    EXEC sp_rename N'[BasketItems].[IX_BasketItem_ParfumId]', N'IX_BasketItems_ParfumId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230829120325_basketpart')
BEGIN
    EXEC sp_rename N'[BasketItems].[IX_BasketItem_BasketId]', N'IX_BasketItems_BasketId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230829120325_basketpart')
BEGIN
    EXEC sp_rename N'[Baskets].[IX_Basket_AppUserId]', N'IX_Baskets_AppUserId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230829120325_basketpart')
BEGIN
    ALTER TABLE [BasketItems] ADD CONSTRAINT [PK_BasketItems] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230829120325_basketpart')
BEGIN
    ALTER TABLE [Baskets] ADD CONSTRAINT [PK_Baskets] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230829120325_basketpart')
BEGIN
    ALTER TABLE [BasketItems] ADD CONSTRAINT [FK_BasketItems_Baskets_BasketId] FOREIGN KEY ([BasketId]) REFERENCES [Baskets] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230829120325_basketpart')
BEGIN
    ALTER TABLE [BasketItems] ADD CONSTRAINT [FK_BasketItems_Parfums_ParfumId] FOREIGN KEY ([ParfumId]) REFERENCES [Parfums] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230829120325_basketpart')
BEGIN
    ALTER TABLE [Baskets] ADD CONSTRAINT [FK_Baskets_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230829120325_basketpart')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230829120325_basketpart', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230830050601_updatebasket')
BEGIN
    EXEC sp_rename N'[BasketItems].[ParfumVolume]', N'TesterId', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230830050601_updatebasket')
BEGIN
    ALTER TABLE [BasketItems] ADD [GiftBoxCount] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230830050601_updatebasket')
BEGIN
    ALTER TABLE [BasketItems] ADD [GiftBoxId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230830050601_updatebasket')
BEGIN
    ALTER TABLE [BasketItems] ADD [SmokeCount] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230830050601_updatebasket')
BEGIN
    ALTER TABLE [BasketItems] ADD [SmokeId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230830050601_updatebasket')
BEGIN
    ALTER TABLE [BasketItems] ADD [TesterCount] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230830050601_updatebasket')
BEGIN
    CREATE INDEX [IX_BasketItems_GiftBoxId] ON [BasketItems] ([GiftBoxId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230830050601_updatebasket')
BEGIN
    CREATE INDEX [IX_BasketItems_SmokeId] ON [BasketItems] ([SmokeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230830050601_updatebasket')
BEGIN
    CREATE INDEX [IX_BasketItems_TesterId] ON [BasketItems] ([TesterId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230830050601_updatebasket')
BEGIN
    ALTER TABLE [BasketItems] ADD CONSTRAINT [FK_BasketItems_GiftBoxes_GiftBoxId] FOREIGN KEY ([GiftBoxId]) REFERENCES [GiftBoxes] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230830050601_updatebasket')
BEGIN
    ALTER TABLE [BasketItems] ADD CONSTRAINT [FK_BasketItems_Smokes_SmokeId] FOREIGN KEY ([SmokeId]) REFERENCES [Smokes] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230830050601_updatebasket')
BEGIN
    ALTER TABLE [BasketItems] ADD CONSTRAINT [FK_BasketItems_Testers_TesterId] FOREIGN KEY ([TesterId]) REFERENCES [Testers] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230830050601_updatebasket')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230830050601_updatebasket', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230830091202_updateProductType')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230830091202_updateProductType', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230830091626_updateProductTypeGet')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230830091626_updateProductTypeGet', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230830112341_addproduct')
BEGIN
    ALTER TABLE [BasketItems] DROP CONSTRAINT [FK_BasketItems_GiftBoxes_GiftBoxId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230830112341_addproduct')
BEGIN
    ALTER TABLE [BasketItems] DROP CONSTRAINT [FK_BasketItems_Smokes_SmokeId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230830112341_addproduct')
BEGIN
    ALTER TABLE [BasketItems] DROP CONSTRAINT [FK_BasketItems_Testers_TesterId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230830112341_addproduct')
BEGIN
    DROP INDEX [IX_BasketItems_GiftBoxId] ON [BasketItems];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230830112341_addproduct')
BEGIN
    DROP INDEX [IX_BasketItems_SmokeId] ON [BasketItems];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230830112341_addproduct')
BEGIN
    DROP INDEX [IX_BasketItems_TesterId] ON [BasketItems];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230830112341_addproduct')
BEGIN
    DECLARE @var18 sysname;
    SELECT @var18 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[BasketItems]') AND [c].[name] = N'GiftBoxCount');
    IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [BasketItems] DROP CONSTRAINT [' + @var18 + '];');
    ALTER TABLE [BasketItems] DROP COLUMN [GiftBoxCount];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230830112341_addproduct')
BEGIN
    DECLARE @var19 sysname;
    SELECT @var19 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[BasketItems]') AND [c].[name] = N'GiftBoxId');
    IF @var19 IS NOT NULL EXEC(N'ALTER TABLE [BasketItems] DROP CONSTRAINT [' + @var19 + '];');
    ALTER TABLE [BasketItems] DROP COLUMN [GiftBoxId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230830112341_addproduct')
BEGIN
    DECLARE @var20 sysname;
    SELECT @var20 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[BasketItems]') AND [c].[name] = N'SmokeCount');
    IF @var20 IS NOT NULL EXEC(N'ALTER TABLE [BasketItems] DROP CONSTRAINT [' + @var20 + '];');
    ALTER TABLE [BasketItems] DROP COLUMN [SmokeCount];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230830112341_addproduct')
BEGIN
    DECLARE @var21 sysname;
    SELECT @var21 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[BasketItems]') AND [c].[name] = N'SmokeId');
    IF @var21 IS NOT NULL EXEC(N'ALTER TABLE [BasketItems] DROP CONSTRAINT [' + @var21 + '];');
    ALTER TABLE [BasketItems] DROP COLUMN [SmokeId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230830112341_addproduct')
BEGIN
    DECLARE @var22 sysname;
    SELECT @var22 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[BasketItems]') AND [c].[name] = N'TesterCount');
    IF @var22 IS NOT NULL EXEC(N'ALTER TABLE [BasketItems] DROP CONSTRAINT [' + @var22 + '];');
    ALTER TABLE [BasketItems] DROP COLUMN [TesterCount];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230830112341_addproduct')
BEGIN
    DECLARE @var23 sysname;
    SELECT @var23 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[BasketItems]') AND [c].[name] = N'TesterId');
    IF @var23 IS NOT NULL EXEC(N'ALTER TABLE [BasketItems] DROP CONSTRAINT [' + @var23 + '];');
    ALTER TABLE [BasketItems] DROP COLUMN [TesterId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230830112341_addproduct')
BEGIN
    CREATE TABLE [Category] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230830112341_addproduct')
BEGIN
    CREATE TABLE [Products] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NOT NULL,
        [Desc] nvarchar(max) NOT NULL,
        [Info1] nvarchar(max) NULL,
        [Info2] nvarchar(max) NULL,
        [ProductCode] nvarchar(max) NOT NULL,
        [IsNew] bit NOT NULL,
        [IsTrend] bit NOT NULL,
        [IsDiscount] bit NOT NULL,
        [IsStock] bit NOT NULL,
        [DiscountPercentage] int NULL,
        [Image] nvarchar(max) NULL,
        [BuyPrice] nvarchar(max) NOT NULL,
        [SellPrice] nvarchar(max) NOT NULL,
        [CountSell] int NULL,
        [TimeSell] datetime2 NULL,
        [ProductCategoryId] int NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Products_Category_ProductCategoryId] FOREIGN KEY ([ProductCategoryId]) REFERENCES [Category] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230830112341_addproduct')
BEGIN
    CREATE TABLE [ProductProperties] (
        [ProductId] int NOT NULL,
        [PropertyKey] nvarchar(max) NULL,
        [PropertyValue] nvarchar(max) NULL,
        CONSTRAINT [PK_ProductProperties] PRIMARY KEY ([ProductId]),
        CONSTRAINT [FK_ProductProperties_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230830112341_addproduct')
BEGIN
    CREATE INDEX [IX_Products_ProductCategoryId] ON [Products] ([ProductCategoryId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230830112341_addproduct')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230830112341_addproduct', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901101349_newdbdesign')
BEGIN
    ALTER TABLE [Products] DROP CONSTRAINT [FK_Products_Category_ProductCategoryId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901101349_newdbdesign')
BEGIN
    DROP TABLE [BasketItems];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901101349_newdbdesign')
BEGIN
    DROP TABLE [GiftBoxes];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901101349_newdbdesign')
BEGIN
    DROP TABLE [Smokes];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901101349_newdbdesign')
BEGIN
    DROP TABLE [Testers];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901101349_newdbdesign')
BEGIN
    DROP TABLE [Baskets];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901101349_newdbdesign')
BEGIN
    DROP TABLE [Parfums];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901101349_newdbdesign')
BEGIN
    DROP TABLE [Brands];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901101349_newdbdesign')
BEGIN
    DROP TABLE [Volumes];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901101349_newdbdesign')
BEGIN
    DECLARE @var24 sysname;
    SELECT @var24 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Products]') AND [c].[name] = N'ProductCategoryId');
    IF @var24 IS NOT NULL EXEC(N'ALTER TABLE [Products] DROP CONSTRAINT [' + @var24 + '];');
    ALTER TABLE [Products] ALTER COLUMN [ProductCategoryId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901101349_newdbdesign')
BEGIN
    ALTER TABLE [Products] ADD CONSTRAINT [FK_Products_Category_ProductCategoryId] FOREIGN KEY ([ProductCategoryId]) REFERENCES [Category] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901101349_newdbdesign')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230901101349_newdbdesign', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901102419_newdbdesignup')
BEGIN
    ALTER TABLE [ProductProperties] DROP CONSTRAINT [FK_ProductProperties_Products_ProductId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901102419_newdbdesignup')
BEGIN
    ALTER TABLE [Products] DROP CONSTRAINT [FK_Products_Category_ProductCategoryId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901102419_newdbdesignup')
BEGIN
    ALTER TABLE [Products] DROP CONSTRAINT [PK_Products];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901102419_newdbdesignup')
BEGIN
    ALTER TABLE [Category] DROP CONSTRAINT [PK_Category];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901102419_newdbdesignup')
BEGIN
    EXEC sp_rename N'[Products]', N'Product';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901102419_newdbdesignup')
BEGIN
    EXEC sp_rename N'[Category]', N'ProductCategory';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901102419_newdbdesignup')
BEGIN
    EXEC sp_rename N'[Product].[IX_Products_ProductCategoryId]', N'IX_Product_ProductCategoryId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901102419_newdbdesignup')
BEGIN
    ALTER TABLE [Product] ADD CONSTRAINT [PK_Product] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901102419_newdbdesignup')
BEGIN
    ALTER TABLE [ProductCategory] ADD CONSTRAINT [PK_ProductCategory] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901102419_newdbdesignup')
BEGIN
    ALTER TABLE [Product] ADD CONSTRAINT [FK_Product_ProductCategory_ProductCategoryId] FOREIGN KEY ([ProductCategoryId]) REFERENCES [ProductCategory] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901102419_newdbdesignup')
BEGIN
    ALTER TABLE [ProductProperties] ADD CONSTRAINT [FK_ProductProperties_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901102419_newdbdesignup')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230901102419_newdbdesignup', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901102753_Withoutproductbasket')
BEGIN
    DROP TABLE [ProductProperties];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901102753_Withoutproductbasket')
BEGIN
    DROP TABLE [Product];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901102753_Withoutproductbasket')
BEGIN
    DROP TABLE [ProductCategory];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901102753_Withoutproductbasket')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230901102753_Withoutproductbasket', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901124039_productbrandbasketvolumecategory')
BEGIN
    CREATE TABLE [Baskets] (
        [Id] int NOT NULL IDENTITY,
        [AppUserId] nvarchar(450) NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Baskets] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Baskets_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901124039_productbrandbasketvolumecategory')
BEGIN
    CREATE TABLE [Brands] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Brands] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901124039_productbrandbasketvolumecategory')
BEGIN
    CREATE TABLE [Category] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901124039_productbrandbasketvolumecategory')
BEGIN
    CREATE TABLE [Volumes] (
        [Id] int NOT NULL IDENTITY,
        [MilliLiters] int NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Volumes] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901124039_productbrandbasketvolumecategory')
BEGIN
    CREATE TABLE [Products] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NOT NULL,
        [Desc] nvarchar(max) NOT NULL,
        [Info1] nvarchar(max) NULL,
        [Info2] nvarchar(max) NULL,
        [ProductCode] nvarchar(max) NOT NULL,
        [IsNew] bit NOT NULL,
        [IsTrend] bit NOT NULL,
        [IsDiscount] bit NOT NULL,
        [IsStock] bit NOT NULL,
        [DiscountPercentage] int NULL,
        [Image] nvarchar(max) NULL,
        [BuyPrice] nvarchar(max) NOT NULL,
        [SellPrice] nvarchar(max) NOT NULL,
        [CountSell] int NULL,
        [TimeSell] datetime2 NULL,
        [ProductCategoryId] int NULL,
        [BrandId] int NULL,
        [VolumeId] int NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Products_Brands_BrandId] FOREIGN KEY ([BrandId]) REFERENCES [Brands] ([Id]),
        CONSTRAINT [FK_Products_Category_ProductCategoryId] FOREIGN KEY ([ProductCategoryId]) REFERENCES [Category] ([Id]),
        CONSTRAINT [FK_Products_Volumes_VolumeId] FOREIGN KEY ([VolumeId]) REFERENCES [Volumes] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901124039_productbrandbasketvolumecategory')
BEGIN
    CREATE TABLE [BasketItems] (
        [Id] int NOT NULL IDENTITY,
        [ProductId] int NOT NULL,
        [BasketId] int NOT NULL,
        [ProductCount] int NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_BasketItems] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_BasketItems_Baskets_BasketId] FOREIGN KEY ([BasketId]) REFERENCES [Baskets] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_BasketItems_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901124039_productbrandbasketvolumecategory')
BEGIN
    CREATE INDEX [IX_BasketItems_BasketId] ON [BasketItems] ([BasketId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901124039_productbrandbasketvolumecategory')
BEGIN
    CREATE INDEX [IX_BasketItems_ProductId] ON [BasketItems] ([ProductId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901124039_productbrandbasketvolumecategory')
BEGIN
    CREATE INDEX [IX_Baskets_AppUserId] ON [Baskets] ([AppUserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901124039_productbrandbasketvolumecategory')
BEGIN
    CREATE INDEX [IX_Products_BrandId] ON [Products] ([BrandId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901124039_productbrandbasketvolumecategory')
BEGIN
    CREATE INDEX [IX_Products_ProductCategoryId] ON [Products] ([ProductCategoryId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901124039_productbrandbasketvolumecategory')
BEGIN
    CREATE INDEX [IX_Products_VolumeId] ON [Products] ([VolumeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901124039_productbrandbasketvolumecategory')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230901124039_productbrandbasketvolumecategory', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230902102057_ProductBasketOrder')
BEGIN
    ALTER TABLE [BasketItems] DROP CONSTRAINT [FK_BasketItems_Baskets_BasketId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230902102057_ProductBasketOrder')
BEGIN
    ALTER TABLE [BasketItems] DROP CONSTRAINT [FK_BasketItems_Products_ProductId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230902102057_ProductBasketOrder')
BEGIN
    ALTER TABLE [Products] DROP CONSTRAINT [FK_Products_Volumes_VolumeId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230902102057_ProductBasketOrder')
BEGIN
    DROP TABLE [Volumes];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230902102057_ProductBasketOrder')
BEGIN
    DROP INDEX [IX_Products_VolumeId] ON [Products];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230902102057_ProductBasketOrder')
BEGIN
    ALTER TABLE [BasketItems] DROP CONSTRAINT [PK_BasketItems];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230902102057_ProductBasketOrder')
BEGIN
    DECLARE @var25 sysname;
    SELECT @var25 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Products]') AND [c].[name] = N'VolumeId');
    IF @var25 IS NOT NULL EXEC(N'ALTER TABLE [Products] DROP CONSTRAINT [' + @var25 + '];');
    ALTER TABLE [Products] DROP COLUMN [VolumeId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230902102057_ProductBasketOrder')
BEGIN
    EXEC sp_rename N'[BasketItems]', N'BasketItem';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230902102057_ProductBasketOrder')
BEGIN
    EXEC sp_rename N'[BasketItem].[IX_BasketItems_ProductId]', N'IX_BasketItem_ProductId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230902102057_ProductBasketOrder')
BEGIN
    EXEC sp_rename N'[BasketItem].[IX_BasketItems_BasketId]', N'IX_BasketItem_BasketId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230902102057_ProductBasketOrder')
BEGIN
    ALTER TABLE [Products] ADD [Volume] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230902102057_ProductBasketOrder')
BEGIN
    ALTER TABLE [Brands] ADD [Image] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230902102057_ProductBasketOrder')
BEGIN
    ALTER TABLE [BasketItem] ADD CONSTRAINT [PK_BasketItem] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230902102057_ProductBasketOrder')
BEGIN
    CREATE TABLE [Orders] (
        [Id] int NOT NULL IDENTITY,
        [AppUserId] nvarchar(450) NOT NULL,
        [TotalPrice] decimal(18,2) NOT NULL,
        [isAccepted] bit NOT NULL,
        [isCompleted] bit NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Orders] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Orders_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230902102057_ProductBasketOrder')
BEGIN
    CREATE TABLE [OrderItems] (
        [Id] int NOT NULL IDENTITY,
        [OrderId] int NOT NULL,
        [ProductId] int NOT NULL,
        [ProductCount] int NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_OrderItems] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_OrderItems_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_OrderItems_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230902102057_ProductBasketOrder')
BEGIN
    CREATE INDEX [IX_OrderItems_OrderId] ON [OrderItems] ([OrderId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230902102057_ProductBasketOrder')
BEGIN
    CREATE INDEX [IX_OrderItems_ProductId] ON [OrderItems] ([ProductId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230902102057_ProductBasketOrder')
BEGIN
    CREATE INDEX [IX_Orders_AppUserId] ON [Orders] ([AppUserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230902102057_ProductBasketOrder')
BEGIN
    ALTER TABLE [BasketItem] ADD CONSTRAINT [FK_BasketItem_Baskets_BasketId] FOREIGN KEY ([BasketId]) REFERENCES [Baskets] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230902102057_ProductBasketOrder')
BEGIN
    ALTER TABLE [BasketItem] ADD CONSTRAINT [FK_BasketItem_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230902102057_ProductBasketOrder')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230902102057_ProductBasketOrder', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230903085939_ProductBasketItem')
BEGIN
    ALTER TABLE [BasketItem] DROP CONSTRAINT [FK_BasketItem_Baskets_BasketId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230903085939_ProductBasketItem')
BEGIN
    ALTER TABLE [BasketItem] DROP CONSTRAINT [FK_BasketItem_Products_ProductId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230903085939_ProductBasketItem')
BEGIN
    ALTER TABLE [BasketItem] DROP CONSTRAINT [PK_BasketItem];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230903085939_ProductBasketItem')
BEGIN
    EXEC sp_rename N'[BasketItem]', N'BasketItems';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230903085939_ProductBasketItem')
BEGIN
    EXEC sp_rename N'[BasketItems].[IX_BasketItem_ProductId]', N'IX_BasketItems_ProductId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230903085939_ProductBasketItem')
BEGIN
    EXEC sp_rename N'[BasketItems].[IX_BasketItem_BasketId]', N'IX_BasketItems_BasketId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230903085939_ProductBasketItem')
BEGIN
    ALTER TABLE [BasketItems] ADD CONSTRAINT [PK_BasketItems] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230903085939_ProductBasketItem')
BEGIN
    ALTER TABLE [BasketItems] ADD CONSTRAINT [FK_BasketItems_Baskets_BasketId] FOREIGN KEY ([BasketId]) REFERENCES [Baskets] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230903085939_ProductBasketItem')
BEGIN
    ALTER TABLE [BasketItems] ADD CONSTRAINT [FK_BasketItems_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230903085939_ProductBasketItem')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230903085939_ProductBasketItem', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230904101347_adddatas')
BEGIN
    DECLARE @var26 sysname;
    SELECT @var26 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Orders]') AND [c].[name] = N'TotalPrice');
    IF @var26 IS NOT NULL EXEC(N'ALTER TABLE [Orders] DROP CONSTRAINT [' + @var26 + '];');
    ALTER TABLE [Orders] ALTER COLUMN [TotalPrice] int NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230904101347_adddatas')
BEGIN
    ALTER TABLE [Orders] ADD [CardNumbers] bigint NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230904101347_adddatas')
BEGIN
    ALTER TABLE [Orders] ADD [Cvv] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230904101347_adddatas')
BEGIN
    ALTER TABLE [Orders] ADD [Email] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230904101347_adddatas')
BEGIN
    ALTER TABLE [Orders] ADD [Info] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230904101347_adddatas')
BEGIN
    ALTER TABLE [Orders] ADD [Loc] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230904101347_adddatas')
BEGIN
    ALTER TABLE [Orders] ADD [Name] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230904101347_adddatas')
BEGIN
    ALTER TABLE [Orders] ADD [Number] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230904101347_adddatas')
BEGIN
    ALTER TABLE [Orders] ADD [PayinHomewhithCard] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230904101347_adddatas')
BEGIN
    ALTER TABLE [Orders] ADD [SurName] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230904101347_adddatas')
BEGIN
    ALTER TABLE [Orders] ADD [Tarix] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230904101347_adddatas')
BEGIN
    ALTER TABLE [Orders] ADD [inHome] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230904101347_adddatas')
BEGIN
    ALTER TABLE [Orders] ADD [inMarket] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230904101347_adddatas')
BEGIN
    ALTER TABLE [Orders] ADD [isCash] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230904101347_adddatas')
BEGIN
    ALTER TABLE [Orders] ADD [withCard] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230904101347_adddatas')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230904101347_adddatas', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230904112743_updateOrderValues')
BEGIN
    DECLARE @var27 sysname;
    SELECT @var27 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Orders]') AND [c].[name] = N'PayinHomewhithCard');
    IF @var27 IS NOT NULL EXEC(N'ALTER TABLE [Orders] DROP CONSTRAINT [' + @var27 + '];');
    ALTER TABLE [Orders] DROP COLUMN [PayinHomewhithCard];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230904112743_updateOrderValues')
BEGIN
    DECLARE @var28 sysname;
    SELECT @var28 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Orders]') AND [c].[name] = N'inHome');
    IF @var28 IS NOT NULL EXEC(N'ALTER TABLE [Orders] DROP CONSTRAINT [' + @var28 + '];');
    ALTER TABLE [Orders] DROP COLUMN [inHome];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230904112743_updateOrderValues')
BEGIN
    DECLARE @var29 sysname;
    SELECT @var29 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Orders]') AND [c].[name] = N'inMarket');
    IF @var29 IS NOT NULL EXEC(N'ALTER TABLE [Orders] DROP CONSTRAINT [' + @var29 + '];');
    ALTER TABLE [Orders] DROP COLUMN [inMarket];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230904112743_updateOrderValues')
BEGIN
    DECLARE @var30 sysname;
    SELECT @var30 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Orders]') AND [c].[name] = N'isCash');
    IF @var30 IS NOT NULL EXEC(N'ALTER TABLE [Orders] DROP CONSTRAINT [' + @var30 + '];');
    ALTER TABLE [Orders] DROP COLUMN [isCash];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230904112743_updateOrderValues')
BEGIN
    DECLARE @var31 sysname;
    SELECT @var31 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Orders]') AND [c].[name] = N'withCard');
    IF @var31 IS NOT NULL EXEC(N'ALTER TABLE [Orders] DROP CONSTRAINT [' + @var31 + '];');
    ALTER TABLE [Orders] DROP COLUMN [withCard];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230904112743_updateOrderValues')
BEGIN
    ALTER TABLE [Orders] ADD [What] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230904112743_updateOrderValues')
BEGIN
    ALTER TABLE [Orders] ADD [Where] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230904112743_updateOrderValues')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230904112743_updateOrderValues', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230904114500_nullablevalue')
BEGIN
    DECLARE @var32 sysname;
    SELECT @var32 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Orders]') AND [c].[name] = N'Where');
    IF @var32 IS NOT NULL EXEC(N'ALTER TABLE [Orders] DROP CONSTRAINT [' + @var32 + '];');
    ALTER TABLE [Orders] ALTER COLUMN [Where] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230904114500_nullablevalue')
BEGIN
    DECLARE @var33 sysname;
    SELECT @var33 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Orders]') AND [c].[name] = N'What');
    IF @var33 IS NOT NULL EXEC(N'ALTER TABLE [Orders] DROP CONSTRAINT [' + @var33 + '];');
    ALTER TABLE [Orders] ALTER COLUMN [What] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230904114500_nullablevalue')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230904114500_nullablevalue', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230905153102_comment')
BEGIN
    CREATE TABLE [Comments] (
        [Id] int NOT NULL IDENTITY,
        [ProductId] int NULL,
        [AppUserId] nvarchar(450) NULL,
        [Title] nvarchar(max) NOT NULL,
        [Desc] nvarchar(max) NOT NULL,
        [Rating] int NOT NULL,
        [isVisible] bit NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Comments] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Comments_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]),
        CONSTRAINT [FK_Comments_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230905153102_comment')
BEGIN
    CREATE INDEX [IX_Comments_AppUserId] ON [Comments] ([AppUserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230905153102_comment')
BEGIN
    CREATE INDEX [IX_Comments_ProductId] ON [Comments] ([ProductId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230905153102_comment')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230905153102_comment', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230906120005_commentUpdat')
BEGIN
    ALTER TABLE [Comments] DROP CONSTRAINT [FK_Comments_AspNetUsers_AppUserId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230906120005_commentUpdat')
BEGIN
    ALTER TABLE [Comments] DROP CONSTRAINT [FK_Comments_Products_ProductId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230906120005_commentUpdat')
BEGIN
    DROP INDEX [IX_Comments_ProductId] ON [Comments];
    DECLARE @var34 sysname;
    SELECT @var34 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Comments]') AND [c].[name] = N'ProductId');
    IF @var34 IS NOT NULL EXEC(N'ALTER TABLE [Comments] DROP CONSTRAINT [' + @var34 + '];');
    ALTER TABLE [Comments] ALTER COLUMN [ProductId] int NOT NULL;
    ALTER TABLE [Comments] ADD DEFAULT 0 FOR [ProductId];
    CREATE INDEX [IX_Comments_ProductId] ON [Comments] ([ProductId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230906120005_commentUpdat')
BEGIN
    DROP INDEX [IX_Comments_AppUserId] ON [Comments];
    DECLARE @var35 sysname;
    SELECT @var35 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Comments]') AND [c].[name] = N'AppUserId');
    IF @var35 IS NOT NULL EXEC(N'ALTER TABLE [Comments] DROP CONSTRAINT [' + @var35 + '];');
    ALTER TABLE [Comments] ALTER COLUMN [AppUserId] nvarchar(450) NOT NULL;
    ALTER TABLE [Comments] ADD DEFAULT N'' FOR [AppUserId];
    CREATE INDEX [IX_Comments_AppUserId] ON [Comments] ([AppUserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230906120005_commentUpdat')
BEGIN
    ALTER TABLE [Comments] ADD CONSTRAINT [FK_Comments_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230906120005_commentUpdat')
BEGIN
    ALTER TABLE [Comments] ADD CONSTRAINT [FK_Comments_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230906120005_commentUpdat')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230906120005_commentUpdat', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230908171332_log')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230908171332_log', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230908171623_logg')
BEGIN
    CREATE TABLE [Logs] (
        [Id] int NOT NULL IDENTITY,
        [AppUserId] nvarchar(max) NOT NULL,
        [Action] nvarchar(max) NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Logs] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230908171623_logg')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230908171623_logg', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909100111_updateordertable')
BEGIN
    ALTER TABLE [Orders] ADD [TotalBenefit] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909100111_updateordertable')
BEGIN
    ALTER TABLE [Orders] ADD [TotalBuyPrice] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230909100111_updateordertable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230909100111_updateordertable', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230911065143_updateappuser')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [ConnectionId] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230911065143_updateappuser')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230911065143_updateappuser', N'6.0.16');
END;
GO

COMMIT;
GO

