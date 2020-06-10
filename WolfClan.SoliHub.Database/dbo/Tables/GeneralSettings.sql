﻿CREATE TABLE [dbo].[GeneralSettings] (
    [Id]                INT             NOT NULL,
    [TitleEN]           NVARCHAR (100)  NOT NULL,
    [TitleAR]           NVARCHAR (100)  NOT NULL,
    [WelWordsEN]        NVARCHAR (1000) NOT NULL,
    [WelWordsAR]        NVARCHAR (1000) NOT NULL,
    [MetaDesc]          NVARCHAR (1000) NOT NULL,
    [MetaKW]            NVARCHAR (1000) NOT NULL,
    [Facebook]          NVARCHAR (1000) NULL,
    [Twitter]           NVARCHAR (1000) NULL,
    [Instagram]         NVARCHAR (1000) NULL,
    [Youtube]           NVARCHAR (1000) NULL,
    [Linkedin]          NVARCHAR (1000) NULL,
    [AppStore]          NVARCHAR (1000) NULL,
    [GooglePlay]        NVARCHAR (1000) NULL,
    [Address]           NVARCHAR (500)  NULL,
    [Email]             NVARCHAR (50)   NULL,
    [Phone]             NVARCHAR (50)   NULL,
    [Fax]               NVARCHAR (50)   NULL,
    [DefaultCountryId]  INT             NOT NULL,
    [Latitude]          NVARCHAR (50)   NULL,
    [Longitude]         NVARCHAR (50)   NULL,
    [PageSize]          INT             NOT NULL,
    [PageSizeMob]       INT             CONSTRAINT [DF_GeneralSettings_PageSizeMob] DEFAULT ((10)) NOT NULL,
    [AutoActiveUser]    BIT             NOT NULL,
    [AutoActiveArticle] BIT             NOT NULL,
    [AddedOn]           DATETIME        NOT NULL,
    [ModifiedOn]        DATETIME        NULL,
    [AdminUserId]       INT             NULL,
    CONSTRAINT [PK_GeneralSettings] PRIMARY KEY CLUSTERED ([Id] ASC)
);

