CREATE TABLE TEACHER(
Teacher_Id int NOT NULL ,
FullName varchar(100) NOT NULL,
DOB date NOT NULL,
EntryYear int NOT NULL,
Phone varchar(100) NOT NULL,
Email varchar(100) NOT NULL,
PRIMARY KEY (Teacher_Id)
);

CREATE TABLE CLASS(
Class_Id int NOT NULL ,
Class varchar(100) NOT NULL ,
ClassStart date NOT NULL,
CLassEnd date NOT NULL,
Teacher_Id int NOT NULL,
PRIMARY KEY (Class_Id),
FOREIGN KEY (Teacher_Id) REFERENCES TEACHER(Teacher_Id)
);

CREATE TABLE STUDENTS(
Student_Id int NOT NULL,
FullName varchar(100) NOT NULL,
Gender varchar(100) NOT NULL,
DOB date NOT NULL,
Email varchar(100)NOT NULL,
Phone varchar(100)NOT NULL,
Score float NOT NULL,
Class int NOT NULL,
PRIMARY KEY (Student_Id),
FOREIGN KEY (Class) REFERENCES CLASS(Class_Id)
);
