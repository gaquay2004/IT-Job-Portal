Use ITJobDb
GO

CREATE TABLE CANDIDATE
(
	CandidateID int references USER_ACCOUNT(UserID),
	CandidatePicture varchar(100),
	CandidatePhone NVARCHAR(50),
	CandidateDoB date,
	CandidateIntroduction NVARCHAR(500),
	Qualification NVARCHAR(500),
	Skill NVARCHAR(500),
	YearOfExperience NVARCHAR(500),
	Likes int default 0,
	PRIMARY KEY(CandidateID)
)
GO

CREATE TABLE COMPANY
(
	CompanyID int references USER_ACCOUNT(UserID),
	CompanyLogo varchar(100),
	CompanyPhone NVARCHAR(50),
	CompanyDescription NVARCHAR(500),
	JobNumber int default 0,
	PRIMARY KEY(CompanyID)
)
GO

go
CREATE TABLE JOB
(
	JobID INT IDENTITY(1,1),
	CompanyID int REFERENCES COMPANY(CompanyID),
	JobName NVARCHAR(100),
	JobType NVARCHAR(50) ,
	JobSalary NVARCHAR(50),
	JobDescription NVARCHAR(500),
	JobQualification NVARCHAR(500),
	JobLocation NVARCHAR(50),
	JobSkills NVARCHAR(50),
	JobPostDate DATE DEFAULT CONVERT(date, GETDATE()),
	JobStatus bit,
	primary key (JobID)
)
GO

create table USER_ACCOUNT
(
	UserID int IDENTITY(1,1),
	Username nvarchar(50),
	UserPassword nvarchar(50),
	Fullname nvarchar(50),
	UserRole nvarchar(50),
	UserEmail nvarchar(50),
	PRIMARY KEY (UserID)
)
GO

create Table JOB_NOTIFICATION
(
    CandidateID int references CANDIDATE(CandidateID),
	JobID int references JOB(JobID),
	CompanyID int references COMPANY(CompanyID),
	ReasonToJoin nvarchar(100),
	DateSent DATE DEFAULT CONVERT(date, GETDATE()),
	primary key (CandidateID, JobID)
)
go

create table COMPANY_REPLY
(
	CompanyID int REFERENCES COMPANY(CompanyID),
	JobID int references JOB(JobID),
	CandidateID int references CANDIDATE(CandidateID),
	Reply  nvarchar(100),
	DateSent DATE DEFAULT CONVERT(date, GETDATE()),
	Accept_denied bit,
	primary key (CompanyID,JobID, CandidateID)
)

create table LIKE_CANDIDATE_PROFILE
(
	CompanyID int REFERENCES COMPANY(CompanyID),
	CandidateID int references CANDIDATE(CandidateID),
	LikeStatus bit default 0,
	primary key(CompanyID,CandidateID)
)

create trigger [dbo].[autoID_FOR_Role] on [dbo].[USER_ACCOUNT]
FOR INSERT
AS
DECLARE @UserID int, @UserRole nvarchar(50)
select @UserID = inserted.UserID, @UserRole = inserted.UserRole FROM INSERTED
BEGIN
	IF(@UserRole ='Candidate')
	BEGIN
		INSERT INTO CANDIDATE(CandidateID) values (@UserID)
	END

	ELSE
	BEGIN
		INSERT INTO COMPANY(CompanyID) values (@UserID)
	END
END
GO

