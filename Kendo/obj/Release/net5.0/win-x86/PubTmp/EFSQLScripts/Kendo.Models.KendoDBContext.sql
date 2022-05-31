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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220525130814_TEST')
BEGIN
    CREATE TABLE [Users] (
        [Id] int NOT NULL IDENTITY,
        [Username] nvarchar(max) NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220525130814_TEST')
BEGIN
    CREATE TABLE [BattleStatistics] (
        [Id] int NOT NULL IDENTITY,
        [UserId] int NOT NULL,
        [Won] bit NOT NULL,
        [AllHits] int NOT NULL,
        [Timespan] time NOT NULL,
        [hits] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_BattleStatistics] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_BattleStatistics_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220525130814_TEST')
BEGIN
    CREATE TABLE [UserStatistics] (
        [Id] int NOT NULL IDENTITY,
        [userId] int NOT NULL,
        [CorrectHits] int NOT NULL,
        [AllHits] int NOT NULL,
        [Wins] int NOT NULL,
        [Loses] int NOT NULL,
        CONSTRAINT [PK_UserStatistics] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_UserStatistics_Users_userId] FOREIGN KEY ([userId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220525130814_TEST')
BEGIN
    CREATE INDEX [IX_BattleStatistics_UserId] ON [BattleStatistics] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220525130814_TEST')
BEGIN
    CREATE UNIQUE INDEX [IX_UserStatistics_userId] ON [UserStatistics] ([userId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220525130814_TEST')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220525130814_TEST', N'5.0.16');
END;
GO

COMMIT;
GO

