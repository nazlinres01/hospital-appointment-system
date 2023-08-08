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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230729175533_HastaneVeriTabani')
BEGIN
    CREATE TABLE [Hastaliks] (
        [Id] int NOT NULL IDENTITY,
        [Isim] nvarchar(max) NOT NULL,
        [Tanim] nvarchar(max) NOT NULL,
        [Belirti] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Hastaliks] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230729175533_HastaneVeriTabani')
BEGIN
    CREATE TABLE [Polikliniks] (
        [Id] int NOT NULL IDENTITY,
        [Isim] nvarchar(255) NOT NULL,
        CONSTRAINT [PK_Polikliniks] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230729175533_HastaneVeriTabani')
BEGIN
    CREATE TABLE [Hastas] (
        [Id] int NOT NULL IDENTITY,
        [Isim] nvarchar(255) NOT NULL,
        [SoyIsim] nvarchar(255) NOT NULL,
        [TelefonNumarasi] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [DateofBirth] datetime2 NOT NULL,
        [HastalikId] int NULL,
        CONSTRAINT [PK_Hastas] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Hastas_Hastaliks_HastalikId] FOREIGN KEY ([HastalikId]) REFERENCES [Hastaliks] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230729175533_HastaneVeriTabani')
BEGIN
    CREATE TABLE [Birims] (
        [Id] int NOT NULL IDENTITY,
        [Isim] nvarchar(255) NOT NULL,
        [PoliklinikId] int NULL,
        CONSTRAINT [PK_Birims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Birims_Polikliniks_PoliklinikId] FOREIGN KEY ([PoliklinikId]) REFERENCES [Polikliniks] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230729175533_HastaneVeriTabani')
BEGIN
    CREATE TABLE [Doktors] (
        [Id] int NOT NULL IDENTITY,
        [Isim] nvarchar(255) NOT NULL,
        [SoyIsim] nvarchar(255) NOT NULL,
        [BirimId] int NOT NULL,
        [PoliklinikId] int NOT NULL,
        [Poliklinik] nvarchar(255) NOT NULL,
        [RandevuId] int NULL,
        CONSTRAINT [PK_Doktors] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Doktors_Birims_BirimId] FOREIGN KEY ([BirimId]) REFERENCES [Birims] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230729175533_HastaneVeriTabani')
BEGIN
    CREATE TABLE [Randevus] (
        [Id] int NOT NULL IDENTITY,
        [Date] datetime2 NOT NULL,
        [HastaId] int NOT NULL,
        [DoktorId] int NOT NULL,
        CONSTRAINT [PK_Randevus] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Randevus_Doktors_DoktorId] FOREIGN KEY ([DoktorId]) REFERENCES [Doktors] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Randevus_Hastas_HastaId] FOREIGN KEY ([HastaId]) REFERENCES [Hastas] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230729175533_HastaneVeriTabani')
BEGIN
    CREATE INDEX [IX_Birims_PoliklinikId] ON [Birims] ([PoliklinikId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230729175533_HastaneVeriTabani')
BEGIN
    CREATE INDEX [IX_Doktors_BirimId] ON [Doktors] ([BirimId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230729175533_HastaneVeriTabani')
BEGIN
    CREATE INDEX [IX_Doktors_RandevuId] ON [Doktors] ([RandevuId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230729175533_HastaneVeriTabani')
BEGIN
    CREATE INDEX [IX_Hastas_HastalikId] ON [Hastas] ([HastalikId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230729175533_HastaneVeriTabani')
BEGIN
    CREATE INDEX [IX_Randevus_DoktorId] ON [Randevus] ([DoktorId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230729175533_HastaneVeriTabani')
BEGIN
    CREATE INDEX [IX_Randevus_HastaId] ON [Randevus] ([HastaId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230729175533_HastaneVeriTabani')
BEGIN
    ALTER TABLE [Doktors] ADD CONSTRAINT [FK_Doktors_Randevus_RandevuId] FOREIGN KEY ([RandevuId]) REFERENCES [Randevus] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230729175533_HastaneVeriTabani')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230729175533_HastaneVeriTabani', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230731143834_mssql.local_migration_452')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230731143834_mssql.local_migration_452', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230802205158_Hastane')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230802205158_Hastane', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230802233541_mssql.local_migration_160')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230802233541_mssql.local_migration_160', N'6.0.0');
END;
GO

COMMIT;
GO

