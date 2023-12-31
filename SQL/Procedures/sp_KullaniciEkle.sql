USE [GAPtest]
GO
/****** Object:  StoredProcedure [dbo].[sp_KullaniciEkle]    Script Date: 2.10.2023 01:21:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_KullaniciEkle]
@username varchar(10),
@pw nvarchar(20),
@Employees bit,
@Products bit,
@Orders bit,
@Customers bit,
@Suppliers bit,
@Titles  bit,
@Userss bit,
@Question varchar(20),
@IsActive bit,
@username1 varchar(10)
AS
BEGIN
INSERT INTO 
Kullanicilar(username,pw,Employees,Products,Orders,Customers,Suppliers,Titles,Userss,Question,IsActive)
VALUES(
@username,
@pw,
@Employees,
@Products, 
@Orders ,
@Customers,
@Suppliers,
@Titles ,
@Userss,
@Question,
@IsActive
)
END
-----------------------------------------------------LOG---------------------------------------------------------------------
BEGIN

		INSERT INTO LogIslem(Kullanici,LogText,Sayfa,Islem)
		VALUES
		(	
		@username1,
		+'username:'+@username+
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
		'Insert'
		)

END