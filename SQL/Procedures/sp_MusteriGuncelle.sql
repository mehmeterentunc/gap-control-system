USE [GAPtest]
GO
/****** Object:  StoredProcedure [dbo].[sp_MusteriGuncelle]    Script Date: 2.10.2023 01:23:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_MusteriGuncelle]
@MusteriID int,
@Ad varchar(20),
@Soyad varchar(20),
@Iletisim varchar(20),
@Cinsiyet bit,
@Adres varchar(50),
@username varchar(10)
AS
UPDATE Musteriler
SET
Ad=@Ad,
Soyad=@Soyad,
Iletisim=@Iletisim,
Cinsiyet=@Cinsiyet,
Adres=@Adres
WHERE MusteriID=@MusteriID
-----------------------------------------------------LOG---------------------------------------------------------------------
BEGIN

		INSERT INTO LogIslem(Kullanici,LogText,Sayfa,Islem)
		VALUES
		(	
		@username,
		+'ID:'+CONVERT(varchar(10),@MusteriID)+
		+' Ad:'+@Ad+
		+' Soyad:'+@Soyad+
		+' Iletisim:'+@Iletisim+
		+' Cinsiyet:'+Convert(varchar(10),@Cinsiyet)+
		+' Adres:'+@Adres,
		'Musteriler',
		'Update'
		)

END
