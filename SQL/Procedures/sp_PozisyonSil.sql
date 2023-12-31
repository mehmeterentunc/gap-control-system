USE [GAPtest]
GO
/****** Object:  StoredProcedure [dbo].[sp_PozisyonSil]    Script Date: 2.10.2023 01:24:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_PozisyonSil]
@PozisyonID int,
@username varchar(10)
AS
BEGIN
DECLARE @LogText varchar(max)

	SELECT @LogText =  
		+'ID: '+CONVERT(VARCHAR(10),@PozisyonID)+
		+' Urun:'+Pozisyon
	FROM Pozisyonlar
	WHERE PozisyonID = @PozisyonID


	INSERT INTO LogIslem (Kullanici, LogText, Sayfa, Islem)
	VALUES (@username, @LogText, 'Pozisyonlar', 'Delete')

	DELETE FROM Pozisyonlar WHERE PozisyonID = @PozisyonID
END

