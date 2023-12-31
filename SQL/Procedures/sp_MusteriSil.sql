USE [GAPtest]
GO
/****** Object:  StoredProcedure [dbo].[sp_MusteriSil]    Script Date: 2.10.2023 01:23:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_MusteriSil]
@MusteriID int,
@username varchar(10)
AS
BEGIN
DECLARE @LogText varchar(max)

	SELECT @LogText =  
		+'ID:'+CONVERT(varchar(10),@MusteriID)+
		+' Ad:'+Ad+
		+' Soyad:'+Soyad+
		+' Iletisim:'+Iletisim+
		+' Cinsiyet:'+Convert(varchar(10),Cinsiyet)+
		+' Adres:'+Adres
	FROM Musteriler
	WHERE MusteriID = @MusteriID


	INSERT INTO LogIslem (Kullanici, LogText, Sayfa, Islem)
	VALUES (@username, @LogText, 'Musteriler', 'Delete')

	DELETE FROM Musteriler WHERE MusteriID = @MusteriID
END