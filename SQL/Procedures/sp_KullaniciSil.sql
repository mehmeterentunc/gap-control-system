USE [GAPtest]
GO
/****** Object:  StoredProcedure [dbo].[sp_KullaniciSil]    Script Date: 2.10.2023 01:22:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_KullaniciSil]
@KullaniciID int,
@username1 varchar(10)
AS
BEGIN
	DECLARE @LogText varchar(max)

	SELECT @LogText =  
		+'ID:'+CONVERT(varchar(10),@KullaniciID)+
		+' username:'+username+
		+' pw:'+pw+
		+' Employees:'+CONVERT(varchar(10),Employees)+
		+' Products:'+CONVERT(varchar(10),Products)+
		+' Orders:'+CONVERT(varchar(10),Orders)+
		+' Customers:'+CONVERT(varchar(10),Customers)+
		+' Suppliers:'+CONVERT(varchar(10),Suppliers)+
		+' Titles:'+CONVERT(varchar(10),Titles)+
		+' Userss:'+CONVERT(varchar(10),Userss)+
		+' Questino:'+Question+
		+' IsActive:'+CONVERT(varchar(10),IsActive)
	FROM Kullanicilar
	WHERE KullaniciID = @KullaniciID


	INSERT INTO LogIslem (Kullanici, LogText, Sayfa, Islem)
	VALUES (@username1, @LogText, 'Kullanicilar', 'Delete')

	DELETE FROM Kullanicilar WHERE KullaniciID = @KullaniciID
END
