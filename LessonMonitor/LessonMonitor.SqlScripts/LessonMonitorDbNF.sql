
--CREATE DATABASE LessonMonitorDbNF

--DROP DATABASE LessonMonitorDbNF

USE [LessonMonitorDbNF]

/*==============================================================*/
/* Table: ACCOUNTS                                              */
/*==============================================================*/
create table ACCOUNTS (
   [ID] INT NOT NULL PRIMARY KEY IDENTITY (1, 1), 
   [NAME] NVARCHAR(50) NOT NULL, 
   [TYPE] INT NULL,
   [CREATED_DATE] DATETIME2 DEFAULT GETDATE()
)

/*==============================================================*/
/* Table: ACHIEVEMENTS                                          */
/*==============================================================*/
create table ACHIEVEMENTS (
   [ID] INT NOT NULL PRIMARY KEY IDENTITY (1, 1), 
   [NAME] NVARCHAR(100) NOT NULL, 
   [RANK] NVARCHAR(150) NOT NULL
)

/*==============================================================*/
/* Table: LECTURES                                              */
/*==============================================================*/
create table LECTURES ( 
   [ID] INT NOT NULL PRIMARY KEY IDENTITY (1, 1), 
   [NAME] NVARCHAR(100) NOT NULL, 
   [DESCRIPTION] NVARCHAR(MAX) NOT NULL,
   [CREATED_DATE] DATETIME2 DEFAULT GETDATE()
)

/*==============================================================*/
/* Table: NICKNAMES                                             */
/*==============================================================*/
create table NICKNAMES (
   [ID] INT NOT NULL PRIMARY KEY IDENTITY (1, 1), 
   [NAME] NVARCHAR(100) NOT NULL, 
   [ACCOUNT_ID] INT NOT NULL,
   CONSTRAINT [FK_NICKNAMES_REFERENCE_ACCOUNTS] FOREIGN KEY (ACCOUNT_ID) REFERENCES ACCOUNTS(ID)
)

/*==============================================================*/
/* Table: SKILLS                                                */
/*==============================================================*/
create table SKILLS (
   [ID] INT NOT NULL PRIMARY KEY IDENTITY (1, 1), 
   [NAME] NVARCHAR(100) NOT NULL, 
   [GRADE] INT NOT NULL
)

/*==============================================================*/
/* Table: ACCOUNTS_ACHIEVEMENT                                  */
/*==============================================================*/
create table ACCOUNTS_ACHIEVEMENTS (
   [ID] INT NOT NULL IDENTITY (1, 1),
   [ACCOUNT_ID] INT NOT NULL,
   [ACHIEVEMENT_ID] INT NOT NULL,
   [ACHIEVEMENT_DATE] DATETIME2 DEFAULT GETDATE(),
    CONSTRAINT [PK_ACCOUNT_ID_ACHIEVEMENT_ID] PRIMARY KEY (ACCOUNT_ID, ACHIEVEMENT_ID),
    CONSTRAINT [FK_ACCACH_REFERENCE_ACCOUNTS] FOREIGN KEY (ACCOUNT_ID) REFERENCES ACCOUNTS(ID),
    CONSTRAINT [FK_ACCACH_REFERENCE_ATTAINME] FOREIGN KEY (ACHIEVEMENT_ID) REFERENCES ACHIEVEMENTS(ID)
)

/*==============================================================*/
/* Table: ACCOUNTS_LECTURES                                    */
/*==============================================================*/
create table ACCOUNTS_LECTURES (
   [ID] INT NOT NULL IDENTITY (1, 1),
   [ACCOUNT_ID] INT NOT NULL,
   [LECTURE_ID] INT NOT NULL,
    CONSTRAINT [PK_ACCOUNT_ID_LECTURE_ID] PRIMARY KEY (ACCOUNT_ID, LECTURE_ID),
    CONSTRAINT [FK_ACCLESS_REFERENCE_ACCOUNTS] FOREIGN KEY (ACCOUNT_ID) REFERENCES ACCOUNTS(ID),
    CONSTRAINT [FK_ACCLESS_REFERENCE_LECTURES] FOREIGN KEY (LECTURE_ID) REFERENCES LECTURES(ID)
)

/*==============================================================*/
/* Table: SKILLS_LECTURES                                      */
/*==============================================================*/
create table SKILLS_LECTURES (
   [ID] INT NOT NULL IDENTITY (1, 1),
   [SKILL_ID]  INT NOT NULL,
   [LECTURE_ID]  INT NOT NULL,
   [SKILL_DATE] DATETIME2 DEFAULT GETDATE(),
    CONSTRAINT [PK_SKILL_ID_LECTURE_ID] PRIMARY KEY (SKILL_ID, LECTURE_ID),
    CONSTRAINT [FK_SKILLSLEC_REFERENCE_SKILLS] FOREIGN KEY (SKILL_ID) REFERENCES SKILLS(ID),
    CONSTRAINT [FK_SKILLSLEC_REFERENCE_LECTURES] FOREIGN KEY (LECTURE_ID) REFERENCES LECTURES(ID)
)
