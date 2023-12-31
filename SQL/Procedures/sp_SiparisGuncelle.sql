USE [GAPtest]
GO
/****** Object:  StoredProcedure [dbo].[sp_SiparisGuncelle]    Script Date: 2.10.2023 01:24:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_SiparisGuncelle]
@SiparisID int,
@CalisanID int,
@MusteriID int,
@UrunID int,
@username varchar(10)
AS
UPDATE Siparisler
SET
CalisanID=@CalisanID,
MusteriID=@MusteriID,
UrunID=@UrunID
WHERE SiparisID=@SiparisID
-----------------------------------------------------LOG---------------------------------------------------------------------
BEGIN

		INSERT INTO LogIslem(Kullanici,LogText,Sayfa,Islem)
		VALUES
		(	
		@username,
		+'ID: '+CONVERT(VARCHAR(10),@SiparisID)+
		+' Calisan: '+CONVERT(VARCHAR(10),@CalisanID)+
		+' Musteri: '+CONVERT(VARCHAR(10),@MusteriID)+
		+' Urun: '+CONVERT(VARCHAR(10),@UrunID),
		'Siparisler',
		'Update'
		)

END
