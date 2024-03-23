USE [GAPtest]
GO
/****** Object:  StoredProcedure [dbo].[sp_CalisanGetir]    Script Date: 2.10.2023 01:20:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_CalisanGetir]
AS
Select a.CalisanlarID, Ad,Soyad, b.Pozisyon, a.BaslangıcTarih, a.Maas, a.Adres, a.Iletisim, a.Cinsiyet, dbo.fn_OtomatikBuyukHarf(Ad,Soyad),a.PozisyonID From
Calisanlar a
inner join
Pozisyonlar b
on a.PozisyonID=b.PozisyonID
ORDER BY a.CalisanlarID desc





