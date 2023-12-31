USE [GAPtest]
GO
/****** Object:  StoredProcedure [dbo].[sp_TedarikciSil]    Script Date: 2.10.2023 01:25:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_TedarikciSil]
@TedarikciID int,
@username varchar(10)
AS
BEGIN
DECLARE @LogText varchar(max)

	SELECT @LogText =  
		+'ID: '+CONVERT(VARCHAR(10),@TedarikciID)+
		+' Tedarikci:'+Tedarikci
	FROM Tedarikciler
	WHERE TedarikciID = @TedarikciID


	INSERT INTO LogIslem (Kullanici, LogText, Sayfa, Islem)
	VALUES (@username, @LogText, 'Tedarikciler', 'Delete')

	DELETE FROM Tedarikciler WHERE TedarikciID = @TedarikciID
END