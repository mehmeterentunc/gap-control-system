USE [GAPtest]
GO
/****** Object:  StoredProcedure [dbo].[sp_KategoriGetir]    Script Date: 2.10.2023 01:21:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_KategoriGetir]
AS
SELECT*FROM Kategoriler order by KategoriID desc
