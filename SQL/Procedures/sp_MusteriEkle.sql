USE [GAPtest]
GO
/****** Object:  StoredProcedure [dbo].[sp_MusteriEkle]    Script Date: 2.10.2023 01:23:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_MusteriEkle] 
@Ad varchar(20),
@Soyad varchar(20),
@Iletisim varchar(20),
@Cinsiyet bit,
@Adres varchar(50),
@username varchar(10)
AS
INSERT INTO 
Musteriler(Ad,Soyad,Iletisim,Cinsiyet,Adres)
VALUES(
@Ad,
@Soyad,
@Iletisim,
@Cinsiyet,
@Adres)
-----------------------------------------------------LOG---------------------------------------------------------------------
BEGIN

		INSERT INTO LogIslem(Kullanici,LogText,Sayfa,Islem)
		VALUES
		(	
		@username,
		+'Ad:'+@Ad+
		+' Soyad:'+@Soyad+
		+' Iletisim:'+@Iletisim+
		+' Cinsiyet:'+Convert(varchar(10),@Cinsiyet)+
		+' Adres:'+@Adres,
		'Musteriler',
		'Insert'
		)

END