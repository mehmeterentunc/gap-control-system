USE [GAPtest]
GO
/****** Object:  StoredProcedure [dbo].[sp_UrunSil]    Script Date: 2.10.2023 01:26:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_UrunSil]
@UrunID int,
@username varchar(10)
AS
BEGIN
	DECLARE @LogText varchar(max)

	SELECT @LogText =  
		+'ID: '+CONVERT(VARCHAR(10),@UrunID)+
		+'Urun:'+Urun+
		' Model:'+CONVERT(varchar(10),ModelID)+
		' Fiyat:'+CONVERT(varchar(10),Fiyat)+
		' Stok :'+CONVERT(varchar(10),StokSayısı)+
		' Tedarikci:'+CONVERT(varchar(10),TedarikciID)
	FROM Urunler
	WHERE UrunID = @UrunID


	INSERT INTO LogIslem (Kullanici, LogText, Sayfa, Islem)
	VALUES (@username, @LogText, 'Calisanlar', 'Delete')

	DELETE FROM Urunler WHERE UrunID = @UrunID
END
