CREATE TABLE [dbo].[Autor] (
    [id]       INT          IDENTITY (1, 1) NOT NULL,
    [LastName] VARCHAR (30) NOT NULL,
    [Name]     VARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);
INSERT Autor ([LastName], [Name]) values ('Braun', 'Den'), ('Ain', 'Reind'),('Herman', 'Melwinn'),('Begbeden','Frederik'),('Tolkien', 'Jorg'),('Bartnet','Bill'),('Evans','Deyw'),('Frankl','Viktor'),('Shtashinski','Ivan');
SELECT * from Autor;
CREATE TABLE [dbo].[Book] (
    [id]             INT           IDENTITY (1, 1) NOT NULL,
    [BookName]       VARCHAR (100) NOT NULL,
    [PreviousBookId] INT           NULL,
    [PublisherName]  VARCHAR (100) NOT NULL,
    [CountPage]      INT           NOT NULL,
    [Type]           VARCHAR (100) NOT NULL,
    [Year]           CHAR (4)      NULL,
    [IdAutor]        INT           NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([PreviousBookId]) REFERENCES [dbo].[Book] ([id]),
    FOREIGN KEY ([IdAutor]) REFERENCES [dbo].[Autor] ([id]),
    CHECK ([CountPage]>(0)),
    CHECK ([Year] like '[0-9][0-9][0-9][0-9]')
);
INSERT Book ([BookName], [PublisherName], [CountPage], [Type], [Year], [IdAutor]) values 
('Fountainhead','our format', 750, 'novel', '2016', 2),
('Mobidik', 'family leisure club', 668, 'novel', '2016', 3),
('99 Frank', 'folio', 282, 'novel', '2005', 2),
('Mans search for Meaning', 'folio', 98, 'psychology', '2016', 8), 
('Hand make drinkcs', 'family leisure club', 68, 'hobbi', '2002', 9),
('Inferno - Part 1','our format', 741, 'novel', '2015', 1),
('Atlass - Consistency', 'family leisure club', 426, 'novel', '2016', 2), 
('Lord of the rings - Guardians of the Ring', 'alphabet classics', 704, 'fantasy', '2012', 5);
INSERT Book ([BookName], [PreviousBookId], [PublisherName], [CountPage], [Type], [Year], [IdAutor]) values 
('Da Vinci Code - Part 2', 6, 'our format', 741, 'novel', '2015', 1),
('Atlass - or-or', 7, 'family leisure club', 426, 'novel', '2016', 2), 
('Lord of the rings - Two Towers', 8, 'alphabet classics', 704, 'fantasy', '2012', 5);
SELECT * from Book;

CREATE TABLE [dbo].[LiberyShop] (
    [id]        INT IDENTITY (1, 1) NOT NULL,
    [IdBook]    INT NOT NULL,
    [Count]     INT NOT NULL,
    [CostPrice] MONEY NOT NULL,
    [Price]     MONEY NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([IdBook]) REFERENCES [dbo].[Book] ([id]),
    CHECK ([Count]>=(0)),
    CHECK ([CostPrice]>=(0)),
    CHECK ([Price]>=(0)),
	[Note]   VARCHAR (100) NULL,
);
INSERT [LiberyShop] ([IdBook], [Count], [CostPrice], [Price]) values
(1,5,250,350),
(2,3,240,370),
(4,5,320,490),
(5,3,270,380),
(6,2,240,360),
(7,11,120,260),
(9,5,270,540),
(10,6,280,590),
(1,4,250,490);
INSERT [LiberyShop] ([IdBook], [Count], [CostPrice], [Price], [Note]) values
(3,6,150,240,'New Year Sale -10%'),
(8,5,280,410,'Reserwed 2 books mr.Anderson');
SELECT * from [LiberyShop];

CREATE TABLE [dbo].[Operation] (
    [Id]           INT IDENTITY (1, 1) NOT NULL,
    [Coming]       BIT NOT NULL,
    [IdLiberyShop] INT Not NULL,
    [Count]        INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([IdLiberyShop]) REFERENCES [dbo].[LiberyShop] ([id]),
    CHECK ([Coming]>=(0) AND [Coming]<=(1))
);

CREATE TABLE [dbo].[StoryComing] (
    [id]        INT IDENTITY (1, 1) NOT NULL,
    [IdBook]    INT NOT NULL,
    [Count]     INT NOT NULL,
    [CostPrice] MONEY NOT NULL,
    [Price]     MONEY NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([IdBook]) REFERENCES [dbo].[Book] ([id]),
    CHECK ([Count]>=(0)),
    CHECK ([CostPrice]>=(0)),
    CHECK ([Price]>=(0))
);

CREATE TABLE [dbo].[StoryWriteOff] (
    [id]        INT IDENTITY (1, 1) NOT NULL,
    [IdLiberyShop]    INT NOT NULL,
    [Count]     INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([IdLiberyShop]) REFERENCES [dbo].[LiberyShop] ([id]),
    CHECK ([Count]>=(0))
);
