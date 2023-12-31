USE [GAPtest]
GO
/****** Object:  StoredProcedure [dbo].[sp_ModelSil]    Script Date: 2.10.2023 01:23:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_ModelSil]
@ModelID int,
@username varchar(10)
AS
BEGIN
DECLARE @LogText varchar(max)

	SELECT @LogText =  
		+'ID: '+CONVERT(VARCHAR(10),@ModelID)+
		+' Model:'+Model+
		+' Kategori:'+CONVERT(VARCHAR(10),KategoriID)
	FROM Modeller
	WHERE ModelID = @ModelID


	INSERT INTO LogIslem (Kullanici, LogText, Sayfa, Islem)
	VALUES (@username, @LogText, 'Modeller', 'Delete')

	DELETE FROM Modeller WHERE ModelID = @ModelID
END

select*from LogHata