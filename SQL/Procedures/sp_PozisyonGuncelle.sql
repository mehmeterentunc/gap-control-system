USE [GAPtest]
GO
/****** Object:  StoredProcedure [dbo].[sp_PozisyonGuncelle]    Script Date: 2.10.2023 01:24:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_PozisyonGuncelle]
@PozisyonID int,
@Pozisyon varchar(20),
@username varchar(10)
AS
UPDATE Pozisyonlar
SET
Pozisyon=@Pozisyon
WHERE PozisyonID=@PozisyonID
-----------------------------------------------------LOG---------------------------------------------------------------------
BEGIN

		INSERT INTO LogIslem(Kullanici,LogText,Sayfa,Islem)
		VALUES
		(	
		@username,
		+'ID: '+CONVERT(VARCHAR(10),@PozisyonID)+
		+' Pozisyon:'+@Pozisyon,
		'Pozisyonlar',
		'Update'
		)

END
