USE [GAPtest]
GO
/****** Object:  StoredProcedure [dbo].[sp_CalisanGuncelle]    Script Date: 2.10.2023 01:20:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_CalisanGuncelle]
@CalisanlarID int,
@Ad varchar(20), 
@Soyad varchar(20),  
@PozisyonID int,
@BaslangicTarih date,   
@Maas int ,
@Adres varchar(50),  
@Iletisim varchar(20), 
@Cinsiyet bit,
@username varchar(10)
AS
BEGIN 
UPDATE Calisanlar 
SET 
Ad=@Ad, 
Soyad=@Soyad, 
PozisyonID=@PozisyonID,
BaslangıcTarih=@BaslangicTarih, 
Maas=@Maas, 
Adres=@Adres, 
Iletisim=@Iletisim, 
Cinsiyet=@Cinsiyet
where CalisanlarID=@CalisanlarID
END

BEGIN

		INSERT INTO LogIslem(Kullanici,LogText,Sayfa,Islem)
		VALUES
		(	
		@username,
		+'ID: '+CONVERT(varchar(10),@CalisanlarID)+
		' Ad:'+@Ad+
		' Soyad:'+@Soyad+
		' Pozisyon:'+CONVERT(varchar(10),@PozisyonID)+
		' Tarih:'+CONVERT(varchar(30),@BaslangicTarih)+
		' Maaş:'+CONVERT(varchar(10),@Maas)+
		' Adres:'+	@Adres+
		' İletişim:'+@Iletisim+
		' Cinsiyet:'+CONVERT(varchar(10),@Cinsiyet),
		'Calisanlar',
		'Update'
		)
END


