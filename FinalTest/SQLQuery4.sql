CREATE TABLE Student (
    StudentID int not null IDENTITY(1, 1),
    StudentName nvarchar(200) not null,
    StudentGender nvarchar(20),
	StudentEmail nvarchar(200),
	StudentPhoneNumber nvarchar(20),
	StudentScore float,
	ClassID int not null,
	PRIMARY KEY (StudentID),
	CONSTRAINT fk_student
	FOREIGN KEY (ClassID) 
	REFERENCES Class(ClassID),
);

CREATE table Teacher(
	TeacherID int not null IDENTITY(1, 1),
	TeacherName nvarchar(200),
	PRIMARY KEY (TeacherID)
);
CREATE table Class(
	ClassID int not null IDENTITY(1, 1),
	ClassName nvarchar(200),
	TeacherID int not null,
	
	PRIMARY KEY (ClassID),
	CONSTRAINT fk_class
	FOREIGN KEY (TeacherID) 
	REFERENCES Teacher(TeacherID),
);

create table Manager(
	ManagerID int not null IDENTITY(1, 1),
	ManagerName nvarchar(200),
	ManagerUserName nvarchar(200),
	ManagerPassWord nvarchar(200),

);

drop table Class;
drop table Teacher;
drop table Student;