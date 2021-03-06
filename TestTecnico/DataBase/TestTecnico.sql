USE [TestColas]
GO
/****** Object:  Table [dbo].[Cola]    Script Date: 11/7/2022 5:20:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cola](
	[id] [int] NOT NULL,
	[nombre] [varchar](200) NOT NULL,
	[cola] [int] NOT NULL,
	[fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_Cola3] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertCola]    Script Date: 11/7/2022 5:20:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertCola]
(@id int,@nombre varchar(200))
AS
BEGIN
	declare @cola1 int, @cola2 int,@diferencia int


set @cola1=(select count(*) from Cola  where Cola=1)
set @cola2=(select count (*) from Cola where Cola=2)

if(@cola1=@cola2)
begin
 INSERT INTO [dbo].[Cola]
           ([id]
           ,[nombre]
		   ,[cola]
           ,[fecha])
     VALUES
           (@id
           ,LTRIM(RTRIM(@nombre))
		   ,1
           ,GETDATE())

end
else if (@cola1>@cola2)
begin
set @diferencia=@cola1-@cola2
	if(@diferencia>1)
	begin
	INSERT INTO [dbo].[Cola]
			   ([id]
			   ,[nombre]
			   ,[cola]
			   ,[fecha])
		 VALUES
			   (@id
			   ,LTRIM(RTRIM(@nombre))
			   ,2
			   ,GETDATE())

	end
	else
	begin
		INSERT INTO [dbo].[Cola]
			   ([id]
			   ,[nombre]
			   ,[cola]
			   ,[fecha])
				VALUES
			   (@id
			   ,LTRIM(RTRIM(@nombre))
			   ,1
			   ,GETDATE())
	end
end
else
begin
		INSERT INTO [dbo].[Cola]
			   ([id]
			   ,[nombre]
			   ,[cola]
			   ,[fecha])
				VALUES
			   (@id
			   ,LTRIM(RTRIM(@nombre))
			   ,1
			   ,GETDATE())


end
END

GO
/****** Object:  StoredProcedure [dbo].[sp_ListCola]    Script Date: 11/7/2022 5:20:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_ListCola]
(@cola int)
	-- Add the parameters for the stored procedure here
AS
BEGIN

delete from Cola where datediff(minute,fecha,getdate())>2 and cola=1
delete from Cola where datediff(minute,fecha,getdate())>3 and cola=2

if(@cola=1)
begin


select id from Cola
where cola=@cola
 order by fecha asc

END
if (@cola=2)
begin

select id from Cola
where cola=@cola
 order by fecha asc


end


END


GO
/****** Object:  StoredProcedure [dbo].[sp_ValidarRegistro]    Script Date: 11/7/2022 5:20:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

CREATE	 PROCEDURE [dbo].[sp_ValidarRegistro]
(@id int)
AS
BEGIN

select count(*) from cola where id=@id

END




GO
