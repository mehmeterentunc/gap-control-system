USE [GAPtest]
GO
/****** Object:  StoredProcedure [dbo].[sp_TedarikciGuncelle]    Script Date: 2.10.2023 01:25:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_TedarikciGuncelle]
@TedarikciID int,
@Tedarikci varchar(30),
@username varchar(10)
AS
UPDATE Tedarikciler
SET
Tedarikci=@Tedarikci
WHERE TedarikciID=@TedarikciID
-----------------------------------------------------LOG---------------------------------------------------------------------
BEGIN

		INSERT INTO LogIslem(Kullanici,LogText,Sayfa,Islem)
		VALUES
		(	
		@username,
		+'ID: '+CONVERT(VARCHAR(10),@TedarikciID)+
		+' Tedarikci:'+@Tedarikci,
		'Tedarikciler',
		'Update'
		)

END