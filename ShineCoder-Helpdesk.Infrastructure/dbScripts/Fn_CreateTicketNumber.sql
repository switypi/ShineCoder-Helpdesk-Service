USE [ShineCoder-HelpdeskDB]
GO

/****** Object:  Table [dbo].[Tickets]    Script Date: 20-01-2024 09:31:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER TABLE [dbo].[Tickets] 
ADD Tkt_Number as dbo.Fn_CreateTicketNumber('SCT-', CAST(Id as nvarchar(10)),4,'0')
GO


CREATE FUNCTION Fn_CreateTicketNumber (
 @Prefix NVARCHAR(10),
 @Id INT,
 @Length INT,
 @PaddingChar CHAR(1) = '0'
)
RETURNS NVARCHAR(MAX)
AS
BEGIN

RETURN (
 SELECT @Prefix + RIGHT(REPLICATE(@PaddingChar, @Length) + CAST(@Id as nvarchar(10)), @Length)
)

END
GO


select dbo.Fn_CreateTicketNumber('SNC-', CAST(1000 as nvarchar(10)),4,'0')