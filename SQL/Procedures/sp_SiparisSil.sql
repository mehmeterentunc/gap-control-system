USE [GAPtest]
GO
/****** Object:  StoredProcedure [dbo].[sp_SiparisSil]    Script Date: 2.10.2023 01:24:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_SiparisSil]
@SiparisID int,
@username varchar(10)
AS
BEGIN
DECLARE @LogText varchar(max)

	SELECT @LogText =  
		+'ID:'+CONVERT(VARCHAR(10),@SiparisID)+
		+' Calisan:'+CONVERT(VARCHAR(10),CalisanID)+
		+' Musteri:'+CONVERT(VARCHAR(10),MusteriID)+
		+' Urun:'+CONVERT(VARCHAR(10),UrunID)
	FROM Siparisler
	WHERE SiparisID = @SiparisID


	INSERT INTO LogIslem (Kullanici, LogText, Sayfa, Islem)
	VALUES (@username, @LogText, 'Siparisler', 'Delete')

	DELETE FROM Siparisler WHERE SiparisID = @SiparisID
END