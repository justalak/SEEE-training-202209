create database School

create table Student(
	StudentID int not null unique,
	Student_Name nvarchar(255) not null,
    Dob DATE NOT NULL,
	Gender varchar(1) not null,
	Email varchar(255) not null,
	PhoneNumber varchar(15) not null,
	Score decimal(2,1) not null,
	ClassID int not null,

	constraint pk_student primary key (StudentID)  
)

create table Class(
	ClassID int primary key,
	Class_Name nvarchar(255) not null,
	TeacherID int not null,
	Start_Time time not null,
	End_Time time not null
)

create table Teacher(
	TeacherID int not null,
	Teacher_Name nvarchar(255) not null,
	Dob date not null,
	Start_Teach date not null,
	PhoneNumber varchar(15) not null,
	Email varchar(255) not null,
)

alter table Teacher 
add constraint pk_teacher primary key (TeacherID)

alter table Student
add constraint fk_class_student
foreign key (ClassID) references Class(ClassID)

alter table Class
add constraint fk_teacher_class
foreign key (TeacherID) references Teacher(TeacherID)