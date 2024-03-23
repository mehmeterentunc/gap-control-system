USE [GAPtest]
GO
/****** Object:  StoredProcedure [dbo].[sp_ModelGetir]    Script Date: 2.10.2023 01:23:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_ModelGetir]
AS
SELECT m.ModelID, m.Model, m.KategoriID, k.Kategori from Modeller m 
inner join Kategoriler K on m.KategoriID=K.KategoriID 
ORDER BY m.ModelID DESC