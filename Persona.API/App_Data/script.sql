IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Contacto] (
    [IdDoc] int NOT NULL,
    [IdTipoContacto] int NOT NULL,
    [Descripcion] nchar(200) NULL,
    CONSTRAINT [PK__Contacto__C92D3B36AD16FC3D] PRIMARY KEY ([IdDoc], [IdTipoContacto])
);

GO

CREATE TABLE [Persona] (
    [IdDoc] int NOT NULL,
    [IdTipoDoc] int NULL,
    [IdPais] int NULL,
    [Sexo] char(1) NULL,
    [Edad] int NULL,
    [Nombre] nchar(200) NULL,
    CONSTRAINT [PK__Persona__5EACE01C794D0B1D] PRIMARY KEY ([IdDoc])
);

GO

CREATE TABLE [Relacion] (
    [IdDoc1] int NOT NULL,
    [IdDoc2] int NOT NULL,
    [IdRelacion] int NOT NULL,
    CONSTRAINT [PK__Relacion__2E9D386BF7281ECC] PRIMARY KEY ([IdDoc1], [IdDoc2])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200506030642_InitialCreate', N'3.1.3');

GO

