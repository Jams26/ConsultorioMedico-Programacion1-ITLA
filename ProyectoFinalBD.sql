USE [ProyectoFinal]
GO
/****** Object:  Table [dbo].[CitaMedica]    Script Date: 02/12/2019 6:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CitaMedica](
	[Id] [int] NOT NULL,
	[IdPaciente] [int] NULL,
	[IdMedico] [int] NULL,
	[IdClinica] [int] NULL,
	[Fecha] [varchar](10) NOT NULL,
	[Hora] [varchar](10) NOT NULL,
	[Causa] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Clínicas]    Script Date: 02/12/2019 6:29:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clínicas](
	[Id] [int] NOT NULL,
	[Nombre] [varchar](30) NOT NULL,
	[Direccion] [varchar](40) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Medicos]    Script Date: 02/12/2019 6:29:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Medicos](
	[Id] [int] NOT NULL,
	[Cédula] [varchar](13) NOT NULL,
	[Exequátur] [varchar](30) NOT NULL,
	[Nombre] [varchar](30) NOT NULL,
	[Teléfono] [varchar](15) NOT NULL,
	[Email] [varchar](30) NOT NULL,
	[Clínicas] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pacientes]    Script Date: 02/12/2019 6:29:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pacientes](
	[Id] [int] NOT NULL,
	[Cédula] [varchar](13) NOT NULL,
	[Nombre] [varchar](30) NOT NULL,
	[Teléfono] [varchar](15) NOT NULL,
	[Email] [varchar](30) NOT NULL,
	[Dirección] [varchar](40) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[CitaMedica]  WITH CHECK ADD FOREIGN KEY([IdClinica])
REFERENCES [dbo].[Clínicas] ([Id])
GO
ALTER TABLE [dbo].[CitaMedica]  WITH CHECK ADD FOREIGN KEY([IdMedico])
REFERENCES [dbo].[Medicos] ([Id])
GO
ALTER TABLE [dbo].[CitaMedica]  WITH CHECK ADD FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Pacientes] ([Id])
GO
