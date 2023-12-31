USE [GAPtest]
GO
/****** Object:  StoredProcedure [dbo].[sp_KullaniciGuncelle]    Script Date: 2.10.2023 01:21:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_KullaniciGuncelle]
@KullaniciID int,
@username varchar(10),
@pw nvarchar(20),
@Employees bit,
@Products bit,
@Orders bit,
@Customers bit,
@Suppliers bit,
@Titles  bit,
@Userss bit,
@Question varchar(10),
@IsActive bit,
@username1 varchar(10)
AS
UPDATE Kullanicilar
SET
username=@username,
pw=@pw,
Employees=@Employees,
Products = @Products ,
Orders = @Orders ,
Customers = @Customers ,
Suppliers =@Suppliers ,
Titles = @Titles  ,
Userss = @Userss ,
Question = @Question,
IsActive = @IsActive
WHERE KullaniciID=@KullaniciID
-----------------------------------------------------LOG---------------------------------------------------------------------
BEGIN

		INSERT INTO LogIslem(Kullanici,LogText,Sayfa,Islem)
		VALUES
		(	
		@username1,
		+'ID:'+CONVERT(varchar(10),@KullaniciID)+
		+' username:'+@username+
		+' pw:'+@pw+
		+' Employees:'+CONVERT(varchar(10),@Employees)+
		+' Products:'+CONVERT(varchar(10),@Products)+
		+' Orders:'+CONVERT(varchar(10),@Orders)+
		+' Customers:'+CONVERT(varchar(10),@Customers)+
		+' Suppliers:'+CONVERT(varchar(10),@Suppliers)+
		+' Titles:'+CONVERT(varchar(10),@Titles)+
		+' Userss:'+CONVERT(varchar(10),@Userss)+
		+' Questino:'+@Question+
		+' IsActive:'+CONVERT(varchar(10),@IsActive),
		'Kullanicilar',
		'Update'
		)

END
