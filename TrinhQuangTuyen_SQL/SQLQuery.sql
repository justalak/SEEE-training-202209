--******1.Thêm, sửa, xóa tìm kiếm sinh viên********
--1.1 Thêm sinh viên 
INSERT INTO student(STUDENT_ID,STUDENT_NAME,GENDER,BIRTHDAY_STUDENT,EMAIL_STUDENT,PHONENUMBER_STUDENT,SCORE,CLASS_ID)
VALUES(1001,'TRINH QUANG TUYEN','MALE','2001-07-18','TUYEN.TQ196733@SIS.HUST.EDU.VN','0378183599',3.5,6);
--1.2 Sửa thông tin sinh viên
UPDATE  student 
SET STUDENT_NAME='TUYEN TRINH', SCORE=6, CLASS_ID=18
WHERE STUDENT_ID=1001;
--1.3 Tiìm kiếm thông tin sinh viên
SELECT * FROM student WHERE STUDENT_ID=1001;
--1.4 Xoá thông tin sinh viên
DELETE FROM student WHERE STUDENT_ID=1001;

--******2.Thêm, sửa, xóa tìm kiếm giáo viên********
--2.1 Thêm giáo viên
INSERT INTO teacher(TEACHER_ID,TEACHER_NAME,BIRTHDAY_TEACHER,EMAIL_TEACHER,PHONENUMBER_TEACHER,STARTYEAR)
VALUES(101,'NGUYEN THI KIM THOA','1987-08-24','THOA.NK@HUST.EDU.VN','0987654321',2008);
--2.2 Sửa thông tin giáo viên
UPDATE teacher
SET TEACHER_NAME='THOA NGUYEN',PHONENUMBER_TEACHER='0123456789',STARTYEAR=2012  
WHERE  TEACHER_ID=101; 
--2.3 Tìm kiếm thông tin giáo viên
SELECT * FROM teacher WHERE TEACHER_ID=101;
--2.4 Xóa thông tin giáo viên
DELETE FROM teacher WHERE TEACHER_ID=101;

--******3.Thêm, sửa, xóa tìm kiếm lớp học********
--3.1 Thêm thông tin lớp học
INSERT INTO class(CLASS_ID,CLASS_NAME,TEACHER_ID,START_TIME,END_TIME) 
VALUES(51,'KI THUAT PHAN MEM UNG DUNG',18,'2021-05-10','2021-11-10');
--3.2 Sửa thông tin lớp 
UPDATE class
SET CLASS_NAME='DIEN TU SO', TEACHER_ID=16,END_TIME='2021-12-10'
WHERE CLASS_ID=51;
--3.3 Tìm kiếm thông tin lớp 
SELECT * FROM class WHERE CLASS_ID=51;
--3.4 Xóa thông tin lớp
DELETE FROM class WHERE CLASS_ID=51;

--******4.Lấy danh sách sinh viên, giáo viên, lớp********
--4.1 Lấy danh sách sinh viên
SELECT * FROM student;
--4.2 Lấy danh sách giáo viên
SELECT * FROM teacher;
--4.3 Lấy danh sách lớp học
SELECT * FROM class;

--******5.Đếm số lượng sinh viên theo từng lớp********
-- Group student by class_id
SELECT COUNT(*) AS STUDENTCOUNT, student.CLASS_ID
INTO DRAFT
FROM student
GROUP BY student.CLASS_ID
ORDER BY student.CLASS_ID
---show result
SELECT DRAFT.STUDENTCOUNT,DRAFT.CLASS_ID,class.CLASS_NAME 
FROM DRAFT INNER JOIN class ON  DRAFT.CLASS_ID=class.CLASS_ID
GO
--------------------------
DROP TABLE DRAFT

--******6.Thống kê 10 sinh viên có điểm cao nhất các lớp bất kỳ********
SELECT TOP 10* FROM student 
WHERE CLASS_ID=5
ORDER BY SCORE DESC

--******7.Thống kê số học sinh nam trong mỗi lớp********
--Group by class-Id với gender='male'
SELECT COUNT(*) AS MALECOUNT, CLASS_ID 
INTO DRAFT
FROM student 
WHERE GENDER= 'MALE'
GROUP BY CLASS_ID
ORDER BY CLASS_ID
Go

---Show result
SELECT DRAFT.MALECOUNT,DRAFT.CLASS_ID,class.CLASS_NAME 
FROM DRAFT INNER JOIN class ON  DRAFT.CLASS_ID=class.CLASS_ID
GO
----------------------------------
DROP TABLE DRAFT

--******8.Lấy ra điểm trung bình của từng lớp********
--Group by class-Id, lấy điểm trung bình
SELECT AVG(SCORE) AS AVERAGE_SCORE, CLASS_ID 
INTO DRAFT
FROM student 
GROUP BY CLASS_ID 
ORDER BY CLASS_ID
GO

------------------Show result
SELECT DRAFT.AVERAGE_SCORE,DRAFT.CLASS_ID,class.CLASS_NAME 
FROM DRAFT INNER JOIN class ON  DRAFT.CLASS_ID=class.CLASS_ID
GO
-------------------
DROP TABLE DRAFT
GO

--******9.Lấy ra danh sách các lớp mà giáo viên chủ nhiệm********
SELECT class.TEACHER_ID,teacher.TEACHER_NAME,class.CLASS_ID,class.CLASS_NAME 
FROM class INNER JOIN teacher ON class.TEACHER_ID=teacher.TEACHER_ID
ORDER BY class.TEACHER_ID;
GO

--******10.Lấy ra giáo viên chủ nhiệm nhiều lớp nhất********
SELECT COUNT(*) AS TEACHERCOUNT,class.TEACHER_ID 
INTO DRAFT
FROM class
GROUP BY class.TEACHER_ID
ORDER BY class.TEACHER_ID
--------------------------
SELECT DRAFT.TEACHERCOUNT, DRAFT.TEACHER_ID,teacher.TEACHER_NAME 
FROM DRAFT,teacher
WHERE (teacher.TEACHER_ID=DRAFT.TEACHER_ID) 
AND (DRAFT.TEACHERCOUNT= (SELECT MAX(DRAFT.TEACHERCOUNT) FROM DRAFT ))
GO 
---------------------------
DROP TABLE DRAFT

--******I.Nâng cao Thống kê 10 giáo viên khác nhau chủ nhiệm lớp có điểm trung bình cao nhất********

SELECT AVG(SCORE) AS AVERAGE_SCORE, CLASS_ID 
INTO DRAFT
FROM student 
GROUP BY CLASS_ID 
GO
SELECT DRAFT.AVERAGE_SCORE,DRAFT.CLASS_ID,class.CLASS_NAME,teacher.TEACHER_ID,teacher.TEACHER_NAME
FROM DRAFT,class,teacher
WHERE (class.TEACHER_ID=teacher.TEACHER_ID) AND  (DRAFT.CLASS_ID =class.CLASS_ID) AND (DRAFT.AVERAGE_SCORE IN (
SELECT TOP 10 DRAFT.AVERAGE_SCORE
FROM DRAFT
ORDER BY AVERAGE_SCORE DESC )) 
GO
--------------------------------
DROP TABLE DRAFT 
GO




