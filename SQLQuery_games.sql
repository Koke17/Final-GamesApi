USE [GamesDb]

CREATE TABLE dbo.Engine
(
	engine_ID bigint NOT NULL PRIMARY KEY
	,engine_name varchar(50)
	,programming_language varchar(50)
	,engine_developer varchar(50),
);

CREATE TABLE dbo.Developer
(
	developer_ID bigint NOT NULL PRIMARY KEY
	,company_name varchar(50)
	,workers int
	,created_date date NULL,
);

CREATE TABLE dbo.Genre
(
	genre_ID bigint NOT NULL PRIMARY KEY
	,genre_type varchar(50)
);

CREATE TABLE dbo.Videogame
(
	videogame_ID bigint NOT NULL PRIMARY KEY
	,videogame_name varchar(50)
	,mode varchar(50),
	engine_ID bigint NOT NULL
	,FOREIGN KEY (engine_ID) REFERENCES dbo.Engine (engine_ID)
);

CREATE TABLE dbo.Genre_videogame
(
	videogame_ID bigint NOT NULL,
	genre_ID bigint NOT NULL,
	FOREIGN KEY (videogame_ID) REFERENCES dbo.videogame (videogame_ID)
	,FOREIGN KEY (genre_ID) REFERENCES dbo.genre (genre_ID)
);

CREATE TABLE dbo.Developer_videogame
(
	videogame_ID bigint NOT NULL,
	developer_ID bigint NOT NULL,
	FOREIGN KEY (videogame_ID) REFERENCES dbo.videogame (videogame_ID)
	,FOREIGN KEY (developer_ID) REFERENCES dbo.developer (developer_ID)
);

