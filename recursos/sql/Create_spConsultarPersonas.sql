/****** Object:  StoredProcedure [DVP].[spConsultarPersonas]  ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

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


