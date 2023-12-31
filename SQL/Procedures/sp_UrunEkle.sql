USE [GAPtest]
GO
/****** Object:  StoredProcedure [dbo].[sp_UrunEkle]    Script Date: 2.10.2023 01:25:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_UrunEkle]
@Urun nvarchar(50),
@ModelID int,
@Fiyat int,
@StokSayısı int,
@TedarikciID int,
@username varchar(10)
AS
INSERT INTO 
Urunler(Urun,ModelID,Fiyat,StokSayısı,TedarikciID)
VALUES(
@Urun,
@ModelID,
@Fiyat,
@StokSayısı,
@TedarikciID)
-----------------------------------------------------LOG---------------------------------------------------------------------
BEGIN

		INSERT INTO LogIslem(Kullanici,LogText,Sayfa,Islem)
		VALUES
		(	
		@username,
		+'Urun:'+@Urun+
		' Model:'+CONVERT(varchar(10),@ModelID)+
		' Fiyat:'+CONVERT(varchar(10),@Fiyat)+
		' Stok :'+CONVERT(varchar(10),@StokSayısı)+
		' Tedarikci:'+CONVERT(varchar(10),@TedarikciID),
		'Urunler',
		'Insert'
		)

END





