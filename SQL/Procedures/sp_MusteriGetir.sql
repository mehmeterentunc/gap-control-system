USE [GAPtest]
GO
/****** Object:  StoredProcedure [dbo].[sp_MusteriGetir]    Script Date: 2.10.2023 01:23:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_MusteriGetir]
AS
SELECT*FROM Musteriler ORDER BY MusteriID DESC