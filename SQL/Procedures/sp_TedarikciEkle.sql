USE [GAPtest]
GO
/****** Object:  StoredProcedure [dbo].[sp_TedarikciEkle]    Script Date: 2.10.2023 01:25:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_TedarikciEkle]
@Tedarikci varchar(30),
@username varchar(10)
AS
INSERT INTO 
Tedarikciler(Tedarikci)
VALUES(
@Tedarikci)
-----------------------------------------------------LOG---------------------------------------------------------------------
BEGIN

		INSERT INTO LogIslem(Kullanici,LogText,Sayfa,Islem)
		VALUES
		(	
		@username,
		+'Tedarikci:'+@Tedarikci,
		'Tedarikciler',
		'Insert'
		)

END