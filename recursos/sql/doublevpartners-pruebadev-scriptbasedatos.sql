CREATE SCHEMA DVP

CREATE TABLE [DVP].[Personas] (
    Identificador UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID() PRIMARY KEY,
    Nombres NVARCHAR(100) NOT NULL,
    Apellidos NVARCHAR(100) NOT NULL,
    NumeroDeIdentificacion NVARCHAR(20) NOT NULL,
    Email NVARCHAR(200) NOT NULL,
    TipoIdentificacion NVARCHAR(20) NOT NULL CHECK (TipoIdentificacion IN ('CC', 'TI', 'CE')),
    FechaDeCreacion DATETIME NOT NULL DEFAULT GETDATE(),
    IdentificacionTipo AS (TipoIdentificacion + '-' + NumeroDeIdentificacion),
	NombresCompletos AS (Nombres + ' ' + Apellidos)
);	

CREATE TABLE [DVP].[Usuario] (
    Identificador UNIQUEIDENTIFIER DEFAULT NEWSEQUENTIALID() PRIMARY KEY,
    Usuario NVARCHAR(200) NOT NULL,
    Pass NVARCHAR(100) NOT NULL,
    FechaDeCreacion DATETIME NOT NULL DEFAULT GETDATE()
);

-- =============================================
-- Author:      alejoagu26@gmail.com
-- Create Date: 2024-07-17
-- Description: Procedimiento para consultar personas
-- =============================================
CREATE PROCEDURE [DVP].[spConsultarPersonas]
AS
BEGIN
    SET NOCOUNT ON

    -- Consulta de personas
	SELECT [Identificador]
		  ,[Nombres]
		  ,[Apellidos]
		  ,[NumeroDeIdentificacion]
		  ,[Email]
		  ,[TipoIdentificacion]
		  ,[FechaDeCreacion]
		  ,[IdentificacionTipo]
		  ,[NombresCompletos]
	FROM [DVP].[Personas]
END
GO
