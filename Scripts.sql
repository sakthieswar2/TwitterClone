USE [FSE]
GO
/****** Object:  Table [dbo].[following]    Script Date: 29-11-2018 18:43:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[following](
	[user_id] [varchar](25) NULL,
	[following_id] [varchar](25) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[person]    Script Date: 29-11-2018 18:43:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[person](
	[user_id] [varchar](25) NOT NULL,
	[password] [varchar](50) NULL,
	[fullname] [varchar](30) NULL,
	[email] [varchar](50) NULL,
	[joined] [datetime] NULL,
	[active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tweet]    Script Date: 29-11-2018 18:43:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tweet](
	[tweet_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [varchar](25) NULL,
	[message] [varchar](140) NULL,
	[craeted] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[tweet_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[following]  WITH CHECK ADD FOREIGN KEY([following_id])
REFERENCES [dbo].[person] ([user_id])
GO
ALTER TABLE [dbo].[following]  WITH CHECK ADD FOREIGN KEY([user_id])
REFERENCES [dbo].[person] ([user_id])
GO
ALTER TABLE [dbo].[tweet]  WITH CHECK ADD FOREIGN KEY([user_id])
REFERENCES [dbo].[person] ([user_id])
GO
