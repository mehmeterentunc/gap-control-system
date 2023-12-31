USE [GAPtest]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_OtomatikBuyukHarf]    Script Date: 2.10.2023 01:26:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER FUNCTION [dbo].[fn_OtomatikBuyukHarf](@ad varchar(100), @soyad varchar(20))
RETURNS VARCHAR(121)
AS
BEGIN
    DECLARE @sonuc VARCHAR(121)
	DECLARE @table TABLE(adlar varchar(100))

	INSERT INTO @table
	SELECT VALUE FROM string_split(@ad,' ')

	Select @sonuc = STRING_AGG(UPPER(SUBSTRING(adlar,1,1)) + LOWER(SUBSTRING(adlar,2,len(adlar))),' ')+' '+UPPER(@soyad) from @table

    RETURN @sonuc
END