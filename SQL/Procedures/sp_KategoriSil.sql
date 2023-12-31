USE [GAPtest]
GO
/****** Object:  StoredProcedure [dbo].[sp_KategoriSil]    Script Date: 2.10.2023 01:21:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_KategoriSil]
@KategoriID int,
@username varchar(10)
AS
BEGIN
DECLARE @LogText varchar(max)

	SELECT @LogText =  
		+'ID: '+CONVERT(VARCHAR(10),@KategoriID)+
		+'Urun:'+Kategori
	FROM Kategoriler
	WHERE KategoriID = @KategoriID


	INSERT INTO LogIslem (Kullanici, LogText, Sayfa, Islem)
	VALUES (@username, @LogText, 'Kategoriler', 'Delete')

	DELETE FROM Kategoriler WHERE KategoriID = @KategoriID
END