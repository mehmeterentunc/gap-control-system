USE [GAPtest]
GO
/****** Object:  StoredProcedure [dbo].[sp_SiparisGetir]    Script Date: 2.10.2023 01:24:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_SiparisGetir]
AS
SELECT s.SiparisID, c.Ad, m.Ad, u.Urun, s.CalisanID, s.MusteriID, s.UrunID from Siparisler s
inner join Calisanlar c on s.CalisanID = c.CalisanlarID
inner join Musteriler m on s.MusteriID = m.MusteriID
inner join Urunler u on s.UrunID = u.UrunID 
ORDER BY s.SiparisID DESC
