create database Job_Database

use Job_Database

create table admin_tb
(
	Admin_ID int identity primary key,
	Name nvarchar(60),
	Email nvarchar(60),
	MobileNo nvarchar(60),
	UserName nvarchar(60),
	Password nvarchar(60),
	EntryDate datetime,
)
create table jobseeker_tb
(
	JS_ID int identity primary key,
	FirstName nvarchar(60),
	LastName nvarchar(60),
	Address nvarchar(60),
	City nvarchar(60),
	State nvarchar(60),
	DateOfBirth nvarchar(60),
	Gender nvarchar(60),
	MobileNo nvarchar(60),
	EmailID nvarchar(60),
	UserName nvarchar(60),
	Password nvarchar(60),
	EntryDate datetime,
)
create table Education_tb
(
EID int identity primary key,
Job_seeker_ID int foreign key references jobseeker_tb(JS_ID),
CollageName nvarchar(60),
Enrollment_Number nvarchar(60),
Semester nvarchar(60),
Education nvarchar(60),
Branch nvarchar(60),
Passyear nvarchar(60),
CPI nvarchar(60),
CGPA nvarchar(60),
Skill nvarchar(60),
ExtraSkill nvarchar(60),
Resume nvarchar(100),
EntryDate datetime,
)

create table Company_tb
(
	CID int identity primary key,
	CNAME nvarchar(60),
	Address nvarchar(MAX),
	City nvarchar(60),
	State nvarchar(60),
	ContactPerson nvarchar(60),
	MobileNo nvarchar(60),
	ContactNumber nvarchar(60),
	Email nvarchar(60),
	UserName nvarchar(60),
	Password nvarchar(60),
	Website nvarchar(60),
	EntryDate datetime,
)

create table job_categorytb
(
	job_cat_id int identity primary key,
	job_cat_name nvarchar(50),
	entry_date datetime,
)

create table Job_location
(
JobLocation_ID int identity primary key,
Location_Name nvarchar(50),
EntryDate datetime,
)


create table PostJob_tb
(
	JobID int identity primary key,
	Company_ID int foreign key references Company_tb(CID),
	job_cat_id int foreign key references job_categorytb(job_cat_id),
	RequiredSkill nvarchar(60),
	Role nvarchar(60),
	Min_Qualification nvarchar(60),
	ExtraSkill nvarchar(60),
	Max_age nvarchar(60),
	Expected_salary int,
	Job_location int foreign key references Job_location(JobLocation_ID),
	Working_Hour nvarchar(60),
	Job_Desc nvarchar(60),
	LastApplyDate datetime,
	EntryDate datetime,
)

create table ApplyJob_tb
(
	AJ_ID int identity primary key,
	JobID int foreign key references PostJob_tb(JobID),
	Company_ID int foreign key references Company_tb(CID),
	Job_seekerID int foreign key references jobseeker_tb(JS_ID),
	Status nvarchar(60),
	EntryDate datetime,
)

create table inbox_tb
(
ID int identity primary key,
Names nvarchar(60),
Froms nvarchar(60),
Tos nvarchar(60),
Messages nvarchar(MAX),
Statuss nvarchar(60),
EntryDate datetime,
)

