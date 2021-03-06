USE [facturacion_dev]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 8/08/2020 11:38:58 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](max) NOT NULL,
	[Apellidos] [varchar](max) NOT NULL,
	[Direccion] [varchar](max) NOT NULL,
	[Telefono] [int] NOT NULL,
	[Edad] [int] NOT NULL,
	[Borrado] [int] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalle]    Script Date: 8/08/2020 11:38:58 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FacturaId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Borrado] [int] NOT NULL,
 CONSTRAINT [PK_Detalle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 8/08/2020 11:38:58 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClienteId] [int] NOT NULL,
	[Total] [decimal](18, 0) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Borrado] [int] NOT NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 8/08/2020 11:38:58 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](max) NOT NULL,
	[Descripcion] [varchar](max) NOT NULL,
	[Precio] [decimal](18, 0) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Borrado] [int] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Cliente_Delete]    Script Date: 8/08/2020 11:38:58 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[Cliente_Delete] (
	@Id INT
)

AS

BEGIN

	SET NOCOUNT OFF;
	SET XACT_ABORT ON;

	BEGIN TRY

		BEGIN TRANSACTION

		UPDATE dbo.Cliente 
		SET    Borrado = 1        
		WHERE  Id = @Id
		  

		COMMIT

	END TRY
	BEGIN CATCH
    
		ROLLBACK;
            
		DECLARE @ErrorMessage NVARCHAR(4000);  
		DECLARE @ErrorSeverity INT;  
		DECLARE @ErrorState INT;  

		SELECT   
			@ErrorMessage = ERROR_MESSAGE(),  
			@ErrorSeverity = ERROR_SEVERITY(),  
			@ErrorState = ERROR_STATE();  

		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);  
	END CATCH
END



-- EXEC [dbo].[Cliente_Select]

 -- SELECT * FROM  dbo.Cliente
GO
/****** Object:  StoredProcedure [dbo].[Cliente_Save]    Script Date: 8/08/2020 11:38:58 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[Cliente_Save] (
	  @Id INT = NULL
	, @Nombre VARCHAR(450)
	, @Apellidos VARCHAR(250)
	, @Direccion VARCHAR(450)
	, @Telefono INT
	, @Edad INT
)

AS

BEGIN

	SET NOCOUNT OFF;
	SET XACT_ABORT ON;

	BEGIN TRY

		BEGIN TRANSACTION

		IF @Id IS NULL
		BEGIN
			INSERT INTO dbo.Cliente (Nombre, Apellidos,Direccion,Telefono,Edad,Borrado)
			VALUES (@Nombre, @Apellidos,@Direccion,@Telefono,@Edad,0)
		END
		ELSE
		BEGIN
			UPDATE dbo.Cliente
			SET    Nombre    = @Nombre
                 , Apellidos = @Apellidos
				 , Direccion = @Direccion
				 , Telefono  = @Telefono
				 , Edad      = @Edad
			WHERE Id = @Id
		END

		COMMIT

	END TRY
	BEGIN CATCH
    
		ROLLBACK;
            
		DECLARE @ErrorMessage NVARCHAR(4000);  
		DECLARE @ErrorSeverity INT;  
		DECLARE @ErrorState INT;  

		SELECT   
			@ErrorMessage = ERROR_MESSAGE(),  
			@ErrorSeverity = ERROR_SEVERITY(),  
			@ErrorState = ERROR_STATE();  

		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);  
	END CATCH
END


-- EXEC [dbo].[Cliente_Select]
GO
/****** Object:  StoredProcedure [dbo].[Cliente_Select]    Script Date: 8/08/2020 11:38:58 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     PROCEDURE [dbo].[Cliente_Select] (
	@Filter NVARCHAR(50) = NULL,
	@SortColumn NVARCHAR(20) = '',
	@SortOrder NVARCHAR(20) = ''	
)

AS

BEGIN
	BEGIN

			WITH items_Cliente AS (
			SELECT
					C.Id
				  , C.Nombre
				  , C.Apellidos
				  , C.Direccion
				  , C.Edad
				  , C.Telefono
			FROM  dbo.Cliente C WITH (NOLOCK)
			WHERE C.Borrado = 0
         ),
        CTE_TotalRows AS (
			SELECT count(ip.Id) as MaxRows from items_Cliente ip
        )
		Select MaxRows, t.* from items_Cliente  as t, CTE_TotalRows 
        OPTION (RECOMPILE)

	END
END

GO
/****** Object:  StoredProcedure [dbo].[ClienteById_Select]    Script Date: 8/08/2020 11:38:58 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE     PROCEDURE [dbo].[ClienteById_Select] (
	@Id INT
)

AS

BEGIN
	SELECT
			  C.Id
			, C.Nombre
			, C.Apellidos
			, C.Direccion
			, C.Telefono
			, C.Edad
	FROM	dbo.Cliente C WITH (NOLOCK)
	WHERE	C.Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[Detalle_Delete]    Script Date: 8/08/2020 11:38:58 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[Detalle_Delete] (
	@Id INT
)

AS

BEGIN

	SET NOCOUNT OFF;
	SET XACT_ABORT ON;

	BEGIN TRY

		BEGIN TRANSACTION

		UPDATE dbo.Detalle
		SET    Borrado = 1        
		WHERE  Id = @Id
		  

		COMMIT

	END TRY
	BEGIN CATCH
    
		ROLLBACK;
            
		DECLARE @ErrorMessage NVARCHAR(4000);  
		DECLARE @ErrorSeverity INT;  
		DECLARE @ErrorState INT;  

		SELECT   
			@ErrorMessage = ERROR_MESSAGE(),  
			@ErrorSeverity = ERROR_SEVERITY(),  
			@ErrorState = ERROR_STATE();  

		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);  
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[Detalle_Save]    Script Date: 8/08/2020 11:38:58 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[Detalle_Save] (
	  @Id INT = NULL
	, @FacturaId VARCHAR(450)
	, @ProductoId VARCHAR(250)
	, @Cantidad INT

)

AS

BEGIN

	SET NOCOUNT OFF;
	SET XACT_ABORT ON;

	BEGIN TRY

		BEGIN TRANSACTION

		IF @Id IS NULL
		BEGIN
			INSERT INTO dbo.Detalle (FacturaId, ProductoId,Cantidad,Borrado)
			VALUES (@FacturaId, @ProductoId,@Cantidad,0)
		END
		ELSE
		BEGIN
			UPDATE dbo.Detalle
			SET    FacturaId   = @FacturaId
                 , ProductoId  = @ProductoId
				 , Cantidad    = @Cantidad
			WHERE Id = @Id
		END

		COMMIT

	END TRY
	BEGIN CATCH
    
		ROLLBACK;
            
		DECLARE @ErrorMessage NVARCHAR(4000);  
		DECLARE @ErrorSeverity INT;  
		DECLARE @ErrorState INT;  

		SELECT   
			@ErrorMessage = ERROR_MESSAGE(),  
			@ErrorSeverity = ERROR_SEVERITY(),  
			@ErrorState = ERROR_STATE();  

		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);  
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[Detalle_Select]    Script Date: 8/08/2020 11:38:58 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE    PROCEDURE [dbo].[Detalle_Select] (
	@Filter NVARCHAR(50) = NULL,
	@SortColumn NVARCHAR(20) = '',
	@SortOrder NVARCHAR(20) = ''	
)

AS

BEGIN
	BEGIN

			WITH items_Detalle AS (
			SELECT
					D.Id
				  , D.FacturaId
				  , D.ProductoId
				  , P.Nombre AS producto
				  , D.Cantidad
			FROM  dbo.Detalle D WITH (NOLOCK)
			INNER JOIN dbo.Producto P ON P.Id = D.ProductoId AND P.Borrado = 0
			WHERE D.Borrado = 0
         ),
        CTE_TotalRows AS (
			SELECT count(ip.Id) as MaxRows from items_Detalle ip
        )
		Select MaxRows, t.* from items_Detalle  as t, CTE_TotalRows 
        OPTION (RECOMPILE)

	END
END

GO
/****** Object:  StoredProcedure [dbo].[DetalleById_Select]    Script Date: 8/08/2020 11:38:58 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE     PROCEDURE [dbo].[DetalleById_Select] (
	@Id INT
)

AS

BEGIN
	SELECT
			  D.Id
			, D.FacturaId
			, D.ProductoId
			, D.Cantidad
	FROM	  dbo.Detalle D WITH (NOLOCK)
	WHERE	  D.Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[Factura_Delete]    Script Date: 8/08/2020 11:38:58 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[Factura_Delete] (
	@Id INT
)

AS

BEGIN

	SET NOCOUNT OFF;
	SET XACT_ABORT ON;

	BEGIN TRY

		BEGIN TRANSACTION

		UPDATE dbo.Factura
		SET    Borrado = 1        
		WHERE  Id = @Id
		  

		COMMIT

	END TRY
	BEGIN CATCH
    
		ROLLBACK;
            
		DECLARE @ErrorMessage NVARCHAR(4000);  
		DECLARE @ErrorSeverity INT;  
		DECLARE @ErrorState INT;  

		SELECT   
			@ErrorMessage = ERROR_MESSAGE(),  
			@ErrorSeverity = ERROR_SEVERITY(),  
			@ErrorState = ERROR_STATE();  

		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);  
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[Factura_Save]    Script Date: 8/08/2020 11:38:58 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE     PROCEDURE [dbo].[Factura_Save] (
	  @Id INT = NULL
	, @ClienteId INT
	, @Total DECIMAL(18,0)
	, @Fecha DATETIME

)

AS

BEGIN

	SET NOCOUNT OFF;
	SET XACT_ABORT ON;

	BEGIN TRY

		BEGIN TRANSACTION

		IF @Id IS NULL
		BEGIN
			INSERT INTO dbo.Factura (ClienteId, Total,Fecha,Borrado)
			VALUES (@ClienteId, @Total,@Fecha,0)
		END
		ELSE
		BEGIN
			UPDATE dbo.Factura
			SET    ClienteId   = @ClienteId
                 , Total  = @Total
				 , Fecha    = @Fecha
			WHERE Id = @Id
		END

		COMMIT

	END TRY
	BEGIN CATCH
    
		ROLLBACK;
            
		DECLARE @ErrorMessage NVARCHAR(4000);  
		DECLARE @ErrorSeverity INT;  
		DECLARE @ErrorState INT;  

		SELECT   
			@ErrorMessage = ERROR_MESSAGE(),  
			@ErrorSeverity = ERROR_SEVERITY(),  
			@ErrorState = ERROR_STATE();  

		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);  
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[Factura_Select]    Script Date: 8/08/2020 11:38:58 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE    PROCEDURE [dbo].[Factura_Select] (
	@Filter NVARCHAR(50) = NULL,
	@SortColumn NVARCHAR(20) = '',
	@SortOrder NVARCHAR(20) = ''	
)

AS

BEGIN
	BEGIN

			WITH items_Factura AS (
			SELECT
					F.Id
				  , F.ClienteId
				  , C.Nombre AS cliente
				  , F.Total
				  , F.Fecha
			FROM  dbo.Factura F WITH (NOLOCK)
			INNER JOIN dbo.Cliente C ON C.Id = F.ClienteId AND C.Borrado = 0
			WHERE F.Borrado = 0
         ),
        CTE_TotalRows AS (
			SELECT count(ip.Id) as MaxRows from items_Factura ip
        )
		Select MaxRows, t.* from items_Factura  as t, CTE_TotalRows 
        OPTION (RECOMPILE)

	END
END

GO
/****** Object:  StoredProcedure [dbo].[FacturaById_Select]    Script Date: 8/08/2020 11:38:58 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE     PROCEDURE [dbo].[FacturaById_Select] (
	@Id INT
)

AS

BEGIN
	SELECT
			  F.Id
			, F.ClienteId
			, F.Total
			, F.Fecha
	FROM	  dbo.Factura F WITH (NOLOCK)
	WHERE	  F.Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[Lista_Clientes_NO_Mayores]    Script Date: 8/08/2020 11:38:58 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE    PROCEDURE [dbo].[Lista_Clientes_NO_Mayores] (
	@Filter NVARCHAR(50) = NULL	
)

AS

BEGIN
	BEGIN

			WITH items_Cliente AS (
			
			SELECT  DISTINCT
					C.Id,
					C.Nombre,
					C.Edad
			FROM    dbo.Factura F
					INNER JOIN dbo.Cliente C ON C.Id = F.ClienteId
			WHERE   F.Borrado = 0 AND C.Edad <=35
					AND  CAST( F.Fecha AS DATE) BETWEEN '2000-02-02' AND '2000-05-15'

         ),
        CTE_TotalRows AS (
			SELECT count(ip.Id) as MaxRows from items_Cliente ip
        )
		Select MaxRows, t.* from items_Cliente  as t, CTE_TotalRows 
        OPTION (RECOMPILE)

	END
END

GO
/****** Object:  StoredProcedure [dbo].[Lista_Clientes_Ultima_Compra]    Script Date: 8/08/2020 11:38:58 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE    PROCEDURE [dbo].[Lista_Clientes_Ultima_Compra] (
	@Filter NVARCHAR(50) = NULL	
)

AS

BEGIN
	BEGIN

			WITH items_Cliente AS (
			
			SELECT 
			        C.Id,
					C.Nombre,
					C.Edad,
					CAST( MIN(F.Fecha) AS DATE) AS primera_compra,
					CAST( MAX(F.Fecha) AS DATE) AS ultima_compra,
					DATEDIFF(DAY,MIN(F.Fecha),MAX(F.Fecha)) AS Rango,
					COUNT(F.ClienteId) AS numero_compras,
					(DATEDIFF(DAY,MIN(F.Fecha),MAX(F.Fecha)) / COUNT(F.ClienteId)) AS COMPRA_CADA_TANTOS_DIAS,
					CAST( DATEADD(DAY,(DATEDIFF(DAY,MIN(F.Fecha),MAX(F.Fecha)) / COUNT(F.ClienteId)), MAX(F.Fecha)) AS DATE) AS ProximaCompra
					FROM    dbo.Factura F
					INNER JOIN dbo.Cliente C ON C.Id = F.ClienteId
			WHERE   F.Borrado = 0
			GROUP BY C.Nombre,
					 C.Edad,
					 C.Id

         ),
        CTE_TotalRows AS (
			SELECT count(ip.Id) as MaxRows from items_Cliente ip
        )
		Select MaxRows, t.* from items_Cliente  as t, CTE_TotalRows 
        OPTION (RECOMPILE)

	END
END

GO
/****** Object:  StoredProcedure [dbo].[Producto_Delete]    Script Date: 8/08/2020 11:38:58 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[Producto_Delete] (
	@Id INT
)

AS

BEGIN

	SET NOCOUNT OFF;
	SET XACT_ABORT ON;

	BEGIN TRY

		BEGIN TRANSACTION

		UPDATE dbo.Producto 
		SET    Borrado = 1        
		WHERE  Id = @Id
		  

		COMMIT

	END TRY
	BEGIN CATCH
    
		ROLLBACK;
            
		DECLARE @ErrorMessage NVARCHAR(4000);  
		DECLARE @ErrorSeverity INT;  
		DECLARE @ErrorState INT;  

		SELECT   
			@ErrorMessage = ERROR_MESSAGE(),  
			@ErrorSeverity = ERROR_SEVERITY(),  
			@ErrorState = ERROR_STATE();  

		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);  
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[Producto_Lista_minimo_cinco]    Script Date: 8/08/2020 11:38:58 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE    PROCEDURE [dbo].[Producto_Lista_minimo_cinco] (
	@Filter NVARCHAR(50) = NULL	
)

AS

BEGIN
	BEGIN

			WITH items_Producto AS (
			
			SELECT    T.Id
					, T.Nombre
					, T.Cantidad
					, T.Inventario
			FROM (
					SELECT
							P.Id, 
							P.Nombre, 
							P.Cantidad, 
							COALESCE( P.Cantidad - SUM(D.Cantidad) ,P.Cantidad ) AS Inventario
					FROM    dbo.Producto P
							LEFT JOIN dbo.Detalle D WITH (NOLOCK) ON D.ProductoId = P.Id AND D.Borrado = 0
							WHERE P.Borrado = 0
					GROUP BY 
							P.Id, 
							P.Nombre,
							P.Cantidad
				) T
					WHERE T.Inventario <= 5
         ),
        CTE_TotalRows AS (
			SELECT count(ip.Id) as MaxRows from items_Producto ip
        )
		Select MaxRows, t.* from items_Producto  as t, CTE_TotalRows 
        OPTION (RECOMPILE)

	END
END

GO
/****** Object:  StoredProcedure [dbo].[Producto_Save]    Script Date: 8/08/2020 11:38:58 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE     PROCEDURE [dbo].[Producto_Save] (
	  @Id INT = NULL
	, @Nombre VARCHAR(450)
	, @Descripcion VARCHAR(250)
	, @Precio DECIMAL(18,0)
	, @Cantidad INT
	, @Fecha DATETIME
)

AS

BEGIN

	SET NOCOUNT OFF;
	SET XACT_ABORT ON;

	BEGIN TRY

		BEGIN TRANSACTION

		IF @Id IS NULL
		BEGIN
			INSERT INTO dbo.Producto (Nombre, Descripcion,Precio,Cantidad,Fecha,Borrado)
			VALUES (@Nombre, @Descripcion,@Precio,@Cantidad,@Fecha,0)
		END
		ELSE
		BEGIN
			UPDATE dbo.Producto
			SET    Nombre    = @Nombre
                 , Descripcion = @Descripcion
				 , Precio = @Precio
				 , Cantidad  = @Cantidad
				 , Fecha      = @Fecha
			WHERE Id = @Id
		END

		COMMIT

	END TRY
	BEGIN CATCH
    
		ROLLBACK;
            
		DECLARE @ErrorMessage NVARCHAR(4000);  
		DECLARE @ErrorSeverity INT;  
		DECLARE @ErrorState INT;  

		SELECT   
			@ErrorMessage = ERROR_MESSAGE(),  
			@ErrorSeverity = ERROR_SEVERITY(),  
			@ErrorState = ERROR_STATE();  

		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);  
	END CATCH
END


-- EXEC [dbo].[Producto_Select]
GO
/****** Object:  StoredProcedure [dbo].[Producto_Select]    Script Date: 8/08/2020 11:38:58 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE    PROCEDURE [dbo].[Producto_Select] (
	@Filter NVARCHAR(50) = NULL,
	@SortColumn NVARCHAR(20) = '',
	@SortOrder NVARCHAR(20) = ''	
)

AS

BEGIN
	BEGIN

			WITH items_Producto AS (
			SELECT
					P.Id
				  , P.Nombre
				  , P.Descripcion
				  , P.Precio
				  , P.Cantidad
				  , P.Fecha
			FROM  dbo.Producto P WITH (NOLOCK)
			WHERE P.Borrado = 0
         ),
        CTE_TotalRows AS (
			SELECT count(ip.Id) as MaxRows from items_Producto ip
        )
		Select MaxRows, t.* from items_Producto  as t, CTE_TotalRows 
        OPTION (RECOMPILE)

	END
END


GO
/****** Object:  StoredProcedure [dbo].[ProductoById_Select]    Script Date: 8/08/2020 11:38:58 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE     PROCEDURE [dbo].[ProductoById_Select] (
	@Id INT
)

AS

BEGIN
	SELECT
			  P.Id
			, P.Nombre
			, P.Descripcion
			, P.Precio
			, P.Cantidad
			, P.Fecha
	FROM	dbo.Producto P WITH (NOLOCK)
	WHERE	P.Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[Valor_Vendido_Producto]    Script Date: 8/08/2020 11:38:58 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE    PROCEDURE [dbo].[Valor_Vendido_Producto] (
	@Filter NVARCHAR(50) = NULL	
)

AS

BEGIN
	BEGIN

			WITH items_Producto AS (
			
			SELECT 
				   P.Id, 
				   P.Nombre,
				   P.Precio,
				   SUM(D.Cantidad) Cantidad_Total,
				   (SUM(D.Cantidad) * P.Precio) AS TOTAL_VENDIDO
			FROM   dbo.Factura F
				   INNER JOIN dbo.Detalle D ON D.FacturaId = F.Id
				   INNER JOIN dbo.Producto P on P.Id = D.ProductoId
			WHERE YEAR(F.Fecha) = 2000 AND F.Borrado = 0
			GROUP BY P.Id, 
					 P.Nombre,
					 P.Precio
         ),
        CTE_TotalRows AS (
			SELECT count(ip.Id) as MaxRows from items_Producto ip
        )
		Select MaxRows, t.* from items_Producto  as t, CTE_TotalRows 
        OPTION (RECOMPILE)

	END
END

GO
