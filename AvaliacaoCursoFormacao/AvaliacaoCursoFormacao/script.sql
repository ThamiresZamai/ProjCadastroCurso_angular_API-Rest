IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [dbo].[Categorias] (
    [id] int NOT NULL IDENTITY,
    [descricao] nvarchar(max) NULL,
    CONSTRAINT [PK_Categorias] PRIMARY KEY ([id])
);

GO

CREATE TABLE [dbo].[Cursos] (
    [id] int NOT NULL IDENTITY,
    [descricao] nvarchar(max) NULL,
    [dataInicio] datetime2 NOT NULL,
    [dataFim] datetime2 NOT NULL,
    [qtdAluno] int NOT NULL,
    [categoriaid] int NOT NULL,
    CONSTRAINT [PK_Cursos] PRIMARY KEY ([id]),
    CONSTRAINT [FK_Cursos_Categorias_categoriaid] FOREIGN KEY ([categoriaid]) REFERENCES [dbo].[Categorias] ([id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Cursos_categoriaid] ON [dbo].[Cursos] ([categoriaid]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200718195641_init', N'2.1.14-servicing-32113');

GO

insert into Categorias values ('comportamental'), ('Programação'), ('Qualidade'), ('Processos')