USE [GAPtest]
GO
/****** Object:  StoredProcedure [dbo].[sp_KullaniciGetir]    Script Date: 2.10.2023 01:21:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_KullaniciGetir]
AS
SELECT*from Kullanicilar ORDER BY KullaniciID DESC