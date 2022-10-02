create database School

create table Student(
	idStudent int not null,
	nameSt nvarchar(255) not null,
	gender varchar(1),
	email varchar(255),
	phoneNumber varchar(15),
	score decimal(2,1),
	idClass int,

	constraint pk_student primary key (idStudent)  -- Xóa được vì có constraint --
)

create table Class(
	idClass int primary key,
	nameCl nvarchar(255) not null,
	idTeacher int,
	startTime date default getdate(),
	endTime date
)

create table Teacher(
	idTeacher int not null,
	nameTc nvarchar(255) not null,
	birthday date,
	startTime date default getdate(),
	phoneNumber varchar(15),
	email varchar(255)
)

alter table dbo.Teacher 
add constraint pk_teacher primary key (idTeacher)

alter table Student
add constraint fk_class_student
foreign key (idClass) references Class(idClass)

alter table Class
add constraint fk_teacher_class
foreign key (idTeacher) references Teacher(idTeacher)

