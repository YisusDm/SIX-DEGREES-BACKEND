USE [PruebaSD]
GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 4/09/2024 10:17:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIO](
	[UsuID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Apellido] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[UsuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_NombreApellido] UNIQUE NONCLUSTERED 
(
	[Nombre] ASC,
	[Apellido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[SP_AddUsuario]    Script Date: 4/09/2024 10:17:04 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AddUsuario]
    @Nombre NVARCHAR(100),
    @Apellido NVARCHAR(100)
AS
BEGIN
    INSERT INTO USUARIO (Nombre, Apellido)
    VALUES (@Nombre, @Apellido);
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_AlterUsuario]    Script Date: 4/09/2024 10:17:04 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AlterUsuario]
    @Id INT,
    @Nombre NVARCHAR(100),
    @Apellido NVARCHAR(100)
AS
BEGIN
    UPDATE USUARIO
    SET Nombre = @Nombre,
        Apellido = @Apellido
    WHERE UsuID = @Id;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteUsuario]    Script Date: 4/09/2024 10:17:04 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DeleteUsuario]
    @Id INT
AS
BEGIN
    DELETE FROM USUARIO WHERE UsuID = @Id;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_GetUsuario]    Script Date: 4/09/2024 10:17:04 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetUsuario]
AS
BEGIN
    SELECT * FROM USUARIO Order by UsuID asc;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_GetUsuarioId]    Script Date: 4/09/2024 10:17:04 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetUsuarioId]
    @Id INT
AS
BEGIN
    SELECT * FROM USUARIO WHERE UsuID = @Id;
END;
GO
