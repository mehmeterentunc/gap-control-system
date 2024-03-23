USE [GAPtest]
GO
/****** Object:  StoredProcedure [dbo].[sp_KategoriEkle]    Script Date: 2.10.2023 01:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_KategoriEkle]
@Kategori varchar(50),
@username varchar(10)
AS
INSERT INTO 
Kategoriler(Kategori)
VALUES (@Kategori)
-----------------------------------------------------LOG---------------------------------------------------------------------
BEGIN

		INSERT INTO LogIslem(Kullanici,LogText,Sayfa,Islem)
		VALUES
		(	
		@username,
		+'Kategori:'+@Kategori,
		'Kategoriler',
		'Insert'
		)

END
