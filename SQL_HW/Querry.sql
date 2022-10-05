--1/Thêm, sửa, xóa, tìm kiếm sinh viên

--Thêm
insert into STUDENTS (Student_Id,FullName, Gender, DOB, Email, Phone, Score, Class) values (...,...,...,../../....,...,...,...,...);

--Sửa
UPDATE STUDENTS
SET FullName='...', Gender='...', DOB='../../....',Email='...',Phone='...',Score='...',Class='...'
WHERE Student_Id=1;

--Xóa
DELETE FROM STUDENTS
WHERE Student_Id=1;

--Tìm kiếm
CREATE VIEW [FindStudent] AS
SELECT*FROM STUDENTS
WHERE Student_Id=1;

SELECT*FROM [FindStudent];

--2/Thêm,sửa xóa, tìm kiếm giáo viên

--Thêm
insert into TEACHER (Teacher_Id, FullName, DOB, EntryYear, Phone, Email) values (...,...,../../....,...,...,...);

--Sửa
UPDATE TEACHER
SET FullName='...', DOB='../../....',EntryYear='...',Phone='...',Email='...'
WHERE Teacher_Id=1001;

--Xóa
DELETE FROM TEACHER
WHERE TEACHER_Id=1001;

--Tìm kiếm
CREATE VIEW [FindTeacher] AS
SELECT*FROM TEACHER
WHERE Teacher_Id=1;
SELECT*FROM [FindTeacher];

--3/Thêm,sửa,xóa, tìm kiếm lớp

--Thêm
insert into CLASS (Class_Id, Class, ClassStart, ClassEnd, Teacher_Id) values (...,...,../../....,../../....,...)

--Sửa
UPDATE CLASS
SET Class='...', ClassStart='../../....',CLassEnd='../../....',Teacher_Id='...'
WHERE Class_Id=123001;

--Xóa
DELETE FROM CLASS
WHERE Class_Id=123001;

--Tìm kiếm
CREATE VIEW [FindClass] AS
SELECT*FROM CLASS
WHERE Class_Id=123001;
SELECT*FROM [FindTeacher];

--4/Lấy danh sách sinh viên, giáo viên, lớp

--Tạo danh sách
CREATE VIEW [StudentList] AS
SELECT*FROM STUDENTS;

CREATE VIEW [TeacherList] AS
SELECT*FROM TEACHER;

CREATE VIEW [ClassList] AS
SELECT*FROM CLASS;

--Lấy danh sách
SELECT*FROM [StudentList]
SELECT*FROM [ClassList]
SELECT*FROM [TeacherList]

--5/Đếm số lượng sinh viên theo từng lớp sinh viên

CREATE VIEW ClassInfo AS
	SELECT Class, COUNT(*) as Count 
	FROM STUDENTS
	GROUP BY Class
	;
SELECT*FROM ClassInfo
ORDER BY Class;

--6/Thống kê 10 sinh viên có điểm cao nhất trong lớp bất kì

--Thống kê điểm của sinh viên của một lớp bất kì
CREATE VIEW StudentsScore AS
SELECT Student_Id, FullName, Score FROM STUDENTS
WHERE Class=123019
;
DROP VIEW StudentsScore
--Thống kê top 10 sinh viên điểm cao nhất
SELECT TOP 10*FROM StudentsScore
ORDER BY Score DESC;

--7/Thống kê số học sinh nam mỗi lớp

CREATE VIEW ClassMale AS
	SELECT Class, COUNT(*) as MenNum
	FROM STUDENTS
	WHERE Gender='Male'
	GROUP BY Class
	;
SELECT*FROM ClassMale

--8/Lấy ra điểm trung bình của từng lớp

CREATE VIEW ClassScore AS
	SELECT Class, AVG(Score) as AverageScore
	FROM STUDENTS
	GROUP BY Class
	;
SELECT*FROM ClassScore
ORDER BY Class;

--9/Lấy ra danh sách lớp mà giáo viên chủ nhiệm

CREATE VIEW Teacher_class AS
SELECT TEACHER.Teacher_Id,FullName, Class_Id,Class
FROM TEACHER
RIGHT JOIN CLASS
ON CLASS.Teacher_Id=TEACHER.Teacher_Id
WHERE CLASS.Teacher_Id is NOT NULL

SELECT*FROM Teacher_class
ORDER BY Teacher_id

--10/Lấy ra giáo viên chủ nhiệm nhiều lớp nhất

--Đếm số lớp mỗi giáo viên chủ nhiệm
CREATE VIEW TeacherHost AS
SELECT Teacher_Id,Count(Class_Id) AS ClassNum
FROM CLASS
GROUP BY Teacher_Id;

--Chọn ra giáo viên chủ nhiệm nhiều lớp nhất
SELECT TOP 1*FROM TeacherHost
ORDER BY ClassNum DESC;