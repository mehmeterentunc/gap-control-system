USE [GAPtest]
GO
/****** Object:  StoredProcedure [dbo].[sp_ModelGuncelle]    Script Date: 2.10.2023 01:23:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_ModelGuncelle]
@ModelID int,
@Model varchar(50),
@KategoriID int ,
@username varchar(10)
AS
BEGIN 
UPDATE Modeller
SET
Model=@Model,
KategoriID=@KategoriID
WHERE ModelID=@ModelID
END
-----------------------------------------------------LOG---------------------------------------------------------------------
BEGIN

		INSERT INTO LogIslem(Kullanici,LogText,Sayfa,Islem)
		VALUES
		(	
		@username,
		+'ID: '+CONVERT(VARCHAR(10),@ModelID)+
		+'Model:'+@Model+
		' Kategori:'+convert(varchar(10),@KategoriID),
		'Modeller',
		'Update'
		)

END
