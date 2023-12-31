USE [GAPtest]
GO
/****** Object:  StoredProcedure [dbo].[sp_CalisanEkle]    Script Date: 2.10.2023 01:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_CalisanEkle] 
@Ad varchar(20),
@Soyad varchar(20),
@PozisyonID int, 
@BaslangicTarih date, 
@Maas int, 
@Adres varchar(50), 
@Iletisim varchar(20), 
@Cinsiyet bit,
@username varchar(10)
AS

BEGIN
		INSERT INTO 
		Calisanlar(Ad,Soyad,PozisyonID,BaslangıcTarih,Maas,Adres,Iletisim,Cinsiyet) 
		VALUES(
		@Ad, 
		@Soyad, 
		@PozisyonID, 
		@BaslangicTarih, 
		@Maas, 
		@Adres,
		@Iletisim, 
		@Cinsiyet)

END

-----------------------------------------------------LOG---------------------------------------------------------------------
BEGIN

		INSERT INTO LogIslem(Kullanici,LogText,Sayfa,Islem)
		VALUES
		(	
		@username,
		+'Ad:'+@Ad+
		' Soyad:'+@Soyad+
		' Pozisyon:'+CONVERT(varchar(10),@PozisyonID)+
		' Tarih:'+CONVERT(varchar(30),@BaslangicTarih)+
		' Maaş:'+CONVERT(varchar(10),@Maas)+
		' Adres:'+@Adres+
		' İletişim:'+@Iletisim+
		' Cinsiyet:'+CONVERT(varchar(10),@Cinsiyet),
		'Calisanlar',
		'Insert'
		)

END



