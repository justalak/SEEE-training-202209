
-- thêm --
insert into Teacher values (51, 'Danh Khue', '8/3/2001', '10/4/2022', '037-410-8243', 'ndkhue030801@gmail.com');

-- sửa -- 
UPDATE Teacher 
set Teacher_Name = 'Danh Khue'
WHERE TeacherID = 1

-- xoá --
delete from Class where Class.TeacherID LIKE 10

-- tìm kiếm --
select * from Student where Dob between '2000-01-01' and '2000-12-31' 

-- lấy danh sách sinh viên --
SELECT * From Student

-- số sinh viên theo từng lớp --
select Student.ClassID, COUNT(Student.StudentID) as 'Class Member'
FROM Student, Class
WHERE Class.ClassID = Student.ClassID
GROUP by Student.ClassID
ORDER by ClassID

-- 10 học sinh có điểm cao nhât --
select top 10 Student_Name, Score 
from Student
where Student.ClassId = 10
order by score desc

-- Thống kê số học sinh Nam mỗi lớp --

select Class.ClassID, Class.Class_Name, count(Student.StudentID) as 'Male Count' 
from Class inner join Student
on Class.ClassID = Student.ClassID and Student.gender = 'm'
group by Class.ClassID, Class.Class_Name


-- Điểm trung bình từng lớp --
select Class.ClassID, Class.Class_Name, AVG(Student.score) as 'Average Score'
from Class, Student
where Student.ClassID = Class.ClassID
group by Class.ClassID, Class.Class_Name
order by AVG(Student.score) asc

-- Các lớp mà giáo viên chủ nhiệm --
select Teacher.Teacher_Name, Count(Class.ClassID) as 'Number of Class Teach'
from Teacher, Class
where Teacher.TeacherID = Class.TeacherID
group by Teacher.Teacher_Name
order by Count(Class.ClassID) ASC




-- Giáo viên chủ nhiệm nhiều lớp nhất --
select top 1 Teacher.Teacher_Name, Count(Class.ClassID) as 'NUmber of Class Teach'
from Teacher, Class
where Teacher.TeacherID = Class.TeacherID
group by Teacher.Teacher_Name
order by Count(Class.ClassID) DESC


-- 10 giáo viên có lớp có điểm trung bình cao nhất --
select top 10 Teacher.Teacher_Name, Class.Class_Name, AVG(Student.score) as 'Avg Score'
from Teacher, Student, Class
where Teacher.TeacherID = Class.TeacherID and Student.ClassID = Class.ClassID
group by Teacher.Teacher_Name, Class.Class_Name
order by AVG(Student.score) desc

-- Tìm kiếm sinh viên theo giới tính --
SELECT * FROM Student
WHERE Student.Gender = 'M'
