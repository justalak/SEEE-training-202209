/*
•	Thông tin sinh viên: Họ và tên, giới tính, ngày tháng năm sinh, email, số điện thoại, điểm, lớp học...
•	Thông tin lớp: Mã lớp, tên lớp, giáo viên quản lý, thời gian bắt đầu, thời gian kết thú…
•	Thông tin giáo viên: Họ và tên, ngày tháng năm sinh, năm vào trường học, số điện thoại, địa chỉ email...
*/
/*Tao bang*/
create table Student(
	StudentID int NOT NULL PRIMARY KEY,
	StudentName varchar(255),
	Gender varchar(255),
	BirthdayStudent date,
	EmailStudent varchar(255),
	PhoneNumberStudent varchar(255),
	Score smallint,
	ClassID int NOT NULL FOREIGN KEY REFERENCES Class(ClassID),
);

create table Class(
	ClassID int NOT NULL PRIMARY KEY,
	ClassName varchar(255),
	TimeStart time,
	TimeEnd time,
	TeacherID int NOT NULL FOREIGN KEY REFERENCES Teacher(TeacherID)
);

create table Teacher(
	TeacherID int NOT NULL PRIMARY KEY,
	TeacherName varchar(255),
	BirthdayTeacher date,
	StartTeaching date,
	EmailTeacher varchar(255),
	PhoneNumberTeacher varchar(255),
);

/*Xóa bảng */
DROP TABLE Student;
DROP TABLE Teacher;
DROP TABLE Class;
/*Thêm dữ liệu*/
insert into Student (StudentID, StudentName, Gender, BirthdayStudent, EmailStudent, PhoneNumberStudent, Score, ClassID) values (1, 'Kailey Dmytryk', 'Female', '2001-06-14', 'kdmytryk0@jigsy.com', '833-262-9502', 8.4, 43);


insert into Class (ClassID, ClassName, TimeStart, TimeEnd, TeacherID) 
values (1, 'Realfire', '7:35 AM', '9:28 AM', 67);

insert into Teacher (TeacherID, TeacherName, BirthdayTeacher, StartTeaching, EmailTeacher, PhoneNumberTeacher) 
values (1, 'Bevvy Kindell', '2000-08-09', '2018-02-08', 'bkindell0@abc.net.au', '695-183-2873');

/*Sửa*/

ALTER TABLE Student 

ALTER TABLE Class

ALTER TABLE Teacher


/*Xóa */

DELETE FROM Student WHERE StudentID = 1;
SELECT * FROM Student WHERE StudentID = 1;

DELETE FROM Class WHERE ClassID = 1;
SELECT * FROM Class WHERE ClassID = 1;

DELETE FROM Teacher WHERE TeacherID = 1;
SELECT * FROM Teacher WHERE TeacherID = 1;
/*Tìm kiếm*/
SELECT *
FROM Student
where StudentID % 5 = 0;

SELECT *
FROM Class
where ClassID % 5 = 0;

SELECT *
FROM Teacher
where TeacherID % 5 = 0;

/*4.	Lấy danh sách sinh viên, giáo viên, lớp*/

SELECT *
FROM Student

SELECT *
FROM Class

SELECT *
FROM Teacher

/*5.	Đếm số lượng sinh viên theo từng lớp sinh viên*/

SELECT COUNT(StudentID) as CountStudent, ClassID
FROM Student
GROUP BY ClassID
ORDER BY COUNT(StudentID) DESC

/* 6.	Thống kê top 10 sinh viên có điểm cao nhất trong lớp bất kì*/
SELECT TOP 10 *
FROM Student
WHERE ClassID = 4
ORDER BY Score DESC


/*7.	Thống kê số học sinh nam trong mỗi lớp.*/

SELECT Class.ClassID, COUNT(Student.StudentID) as CountStudent
FROM Student, Class
WHERE Student.Gender = 'male' AND Class.ClassID = Student.ClassID
GROUP BY Class.ClassID

/*8.	Lấy ra điểm trung bình của từng lớp.*/
SELECT Class.ClassID, AVG(Student.Score) as AverageScore
FROM Class, Student
WHERE Class.ClassID = Student.ClassID
GROUP BY Class.CLassID

/*9.	Lấy ra danh sách các lớp mà giáo viên chủ nhiệm
	Chưa hiểu yêu cầu đề bài lắm
*/
SELECT Teacher.TeacherID, Teacher.TeacherName



/*10.	Lấy ra giáo viên chủ nhiệm nhiều lớp nhất*/
SELECT TOP 1 Teacher.TeacherName, Count(Class.ClassID) as CountClass
FROM Teacher, Class
WHERE Teacher.TeacherID = Class.TeacherID
GROUP BY Teacher.TeacherName
ORDER BY Count(Class.ClassID) desc
