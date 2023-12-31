USE [GAPtest]
GO
/****** Object:  StoredProcedure [dbo].[sp_UrunGuncelle]    Script Date: 2.10.2023 01:25:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_UrunGuncelle]
@UrunID int,
@Urun nvarchar(50),
@ModelID int,
@Fiyat int,
@StokSayısı int,
@TedarikciID int,
@username varchar(10)
AS
UPDATE Urunler
SET
Urun=@Urun,
ModelID=@ModelID,
Fiyat=@Fiyat,
StokSayısı=@StokSayısı,
TedarikciID=@TedarikciID
WHERE UrunID=@UrunID
-----------------------------------------------------LOG---------------------------------------------------------------------
BEGIN

		INSERT INTO LogIslem(Kullanici,LogText,Sayfa,Islem)
		VALUES
		(	
		@username,
		+'ID: '+CONVERT(VARCHAR(10),@UrunID)+
		+' Urun:'+@Urun+
		' Model:'+CONVERT(varchar(10),@ModelID)+
		' Fiyat:'+CONVERT(varchar(10),@Fiyat)+
		' Stok :'+CONVERT(varchar(10),@StokSayısı)+
		' Tedarikci:'+CONVERT(varchar(10),@TedarikciID),
		'Urunler',
		'Update'
		)

END

