
create database My_Virtu_alSchool
go
use My_Virtu_alSchool
go

go
create table Teacher(
TeacherId numeric primary key identity(1,1),
IdentitiyNumber varchar(9) ,
FirstName varchar (30),
LastName varchar (20),
Email varchar(30),
Passwordd varchar(10),
statusTeacher bit
)
create table Course(
CoueseId numeric primary key identity(1,1),
CourseName varchar(100),
ImgCourse varchar(max),
TeacherId numeric foreign key references Teacher(TeacherId),
)



go
create table Groups(
GroupsId numeric  primary key identity(1,1),
GroupName varchar (20),
rankGroup  numeric 
)

go
create table CoursesToClsss(
CoursesToClsssId  numeric  primary key identity(1,1),
CourseId numeric foreign key references Course(CoueseId),
IdGroup numeric foreign key references Groups(GroupsId)
)
go

create table Student(
StudentId numeric primary key identity(1,1),
IdentitiyNumber varchar(9) ,
FirstName varchar (30),
LastName varchar (20),
Email varchar(30),
GroupId numeric foreign key references Groups(GroupsId),
statusStudent bit
)
go
create table ScheduleHours(
ScheduleHoursIndex numeric primary key not null,
TimeBeginning DateTime,
TimeEnd DateTime
)
go
create table Schedule(
ScheduleId numeric primary key identity(1,1),
numberDayOfWeek numeric ,
ScheduleHourIndex numeric foreign key references ScheduleHours(ScheduleHoursIndex),
CoursesToClsssId numeric foreign key references CoursesToClsss(CoursesToClsssId),
check(numberDayOfWeek in (1,2,3,4,5,6))
)
go
create table PreparedLesson(
LessonId numeric primary key identity(1,1),
IndexPreparedLesson numeric,
IfAlowLesson bit,
CourseId numeric foreign key references CoursesToClsss(CoursesToClsssId),
)
go
create table LessonsTaken(
LessonsTakenId numeric primary key identity(1,1),
DateAndTime DateTime ,
GroupId numeric foreign key references Groups(GroupsId),
LessonId numeric foreign key references PreparedLesson(LessonId),
)
go
create table LearningFile(
FileId numeric primary key not null,
TypeFile varchar(max) ,
DescriptionFile varchar(max),
SrcDrivFile varchar(max),
SrcPdfFile varchar(max) ,
LessonId numeric foreign key references PreparedLesson(LessonId) 
)
create table presenceInLessons(
presenceInLessonsId numeric primary key identity(1,1),
DateToday Date ,
StudentId numeric foreign key references Student(StudentId) ,
CoursesToClsssId numeric foreign key references CoursesToClsss(CoursesToClsssId) ,
TimeBeginning DateTime,
TimeEnd DateTime
)

