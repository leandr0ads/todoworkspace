/****** Object:  Table [dbo].[Todos]    Script Date: 03/11/2025 07:51:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Todos]') AND type in (N'U'))
DROP TABLE [dbo].[Todos]
GO

/****** Object:  Table [dbo].[Todos]    Script Date: 03/11/2025 07:51:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Todos](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](1000) NULL,
	[DueDate] [datetime2](7) NULL,
	[IsCompleted] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Todos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Todos] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsCompleted]
GO

ALTER TABLE [dbo].[Todos] ADD  DEFAULT (getutcdate()) FOR [CreatedAt]
GO



