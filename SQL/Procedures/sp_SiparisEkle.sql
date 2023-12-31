USE [GAPtest]
GO
/****** Object:  StoredProcedure [dbo].[sp_SiparisEkle]    Script Date: 2.10.2023 01:24:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_SiparisEkle]
@CalisanID int,
@MusteriID int,
@UrunID int,
@username varchar(10)
AS
INSERT INTO 
Siparisler(CalisanID,MusteriID,UrunID)
VALUES(
@CalisanID,
@MusteriID,
@UrunID)
-----------------------------------------------------LOG---------------------------------------------------------------------
BEGIN

		INSERT INTO LogIslem(Kullanici,LogText,Sayfa,Islem)
		VALUES
		(	
		@username,
		+'Calisan:'+CONVERT(varchar(10),@CalisanID)+
		+' Musteri:'+CONVERT(varchar(10),@MusteriID)+
		+' Urun:'+CONVERT(varchar(10),@UrunID),
		'Siparisler',
		'Insert'
		)

END

