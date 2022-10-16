CREATE TABLE TEACHER(
IdTeacher int NOT NULL ,
FullName varchar(30) NOT NULL,
DOB date NOT NULL,
EntryYear int NOT NULL,
Phone varchar(15) NOT NULL,
Email varchar(30) NOT NULL,

);

CREATE TABLE CLASS(
IdClass int NOT NULL ,
Class varchar(30) NOT NULL ,
ClassStart date NOT NULL,
CLassEnd date NOT NULL,
Teacher_Id int NOT NULL,

);

CREATE TABLE STUDENTS(
IdStudent int NOT NULL,
FullName varchar(30) NOT NULL,
Gender varchar(30) NOT NULL,
DOB date NOT NULL,
Email varchar(30)NOT NULL,
Phone varchar(15)NOT NULL,
Score float NOT NULL,
Class int NOT NULL,

);

alter table dbo.Teacher 
add constraint pk_teacher primary key (idTeacher)

alter table Students
add constraint fk_class_students
foreign key (idClass) references Class(idClass)

alter table Class
add constraint fk_teacher_class
foreign key (idTeacher) references Teacher(idTeacher)