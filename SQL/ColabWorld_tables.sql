USE [colabdb]
GO

/****** Object:  Table [dbo].[EMPRESA]    Script Date: 12/11/2017 15:08:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EMPRESA](
	[IDEMPRESA] [int] IDENTITY(1,1) NOT NULL,
	[STRNOME] [varchar](150) NULL,
	[STRCNPJ] [varchar](14) NOT NULL,
	[DTCADASTRO] [date] NULL,
	[STRRAZAOSOCIAL] [varchar](150) NULL,
 CONSTRAINT [PK_EMPRESA] PRIMARY KEY CLUSTERED 
(
	[IDEMPRESA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



CREATE TABLE [dbo].[PESSOA](
	[IDPESSOA] [int] IDENTITY(1,1) NOT NULL,
	[STRCPF] [varchar](11) NULL,
	[DTNASCIMENTO] [date] NULL,
	[DTCADASTRO] [date] NULL,
	[STRNOME] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDPESSOA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



CREATE TABLE [dbo].[COLABORADOR](
	[IDCOLAB] [int] IDENTITY(1,1) NOT NULL,
	[IDPESSOA] [int] NULL,
	[IDEMPRESA] [int] NULL,
	[VLRSALARIO] [numeric](15, 2) NULL,
	[BSTATUS] [bit] NULL,
	[DTCADASTRO] [date] NULL,
	[DTDEMISSAO] [date] NULL,
	[STRCARGO] [varchar](70) NULL,
 CONSTRAINT [PK_COLABORADOR] PRIMARY KEY CLUSTERED 
(
	[IDCOLAB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[COLABORADOR]  WITH CHECK ADD  CONSTRAINT [FK_COLABORADOR_EMPRESA] FOREIGN KEY([IDEMPRESA])
REFERENCES [dbo].[EMPRESA] ([IDEMPRESA])
GO

ALTER TABLE [dbo].[COLABORADOR] CHECK CONSTRAINT [FK_COLABORADOR_EMPRESA]
GO

ALTER TABLE [dbo].[COLABORADOR]  WITH CHECK ADD  CONSTRAINT [FK_COLABORADOR_PESSOA] FOREIGN KEY([IDPESSOA])
REFERENCES [dbo].[PESSOA] ([IDPESSOA])
GO

ALTER TABLE [dbo].[COLABORADOR] CHECK CONSTRAINT [FK_COLABORADOR_PESSOA]
GO



