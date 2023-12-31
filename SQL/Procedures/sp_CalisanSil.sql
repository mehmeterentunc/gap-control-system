USE [GAPtest]
GO
/****** Object:  StoredProcedure [dbo].[sp_CalisanSil]    Script Date: 2.10.2023 01:21:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_CalisanSil]
@CalisanlarID int,
@username varchar(10)
AS
BEGIN
	DECLARE @LogText varchar(max)

	SELECT @LogText =  
	+'ID :'+Convert(varchar(10),@CalisanlarID)+
	' Ad:'+Ad+
	' Soyad:'+Soyad+
	' Pozisyon:'+Convert(varchar(10),PozisyonID)+
	' Tarih:'+Convert(varchar(30),BaslangıcTarih)+
	' Maaş:'+Convert(varchar(10),Maas)+
	' Adres:'+Adres+
	' İletişim:'+Iletisim+
	' Cinsiyet:'+Convert(varchar(10),Cinsiyet)
	FROM Calisanlar
	WHERE CalisanlarID = @CalisanlarID


	INSERT INTO LogIslem (Kullanici, LogText, Sayfa, Islem)
	VALUES (@username, @LogText, 'Urunler', 'Delete')

	DELETE FROM Calisanlar WHERE CalisanlarID = @CalisanlarID
END
	

