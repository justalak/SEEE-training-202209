select * from Teacher
select * from Students
select * from Class
-- STUDENT --

-- Add 
insert into STUDENTS (IdStudent,FullName, Gender, DOB, Email, Phone, Score, IdClass) 
values (1502,'DangHieu','Male','20011111','htg','20011922',1,123);

-- update
UPDATE STUDENTS
SET FullName='HIEU', Gender='MALE', DOB='20011111',Email='1212',Phone='12322',Score='1',Class='1'
WHERE IdStudent=1;

-- delete
DELETE FROM STUDENTS
WHERE IdStudent=1;

-- search
select * from Students where IdStudent=1; 

select * from Students where IdStudent=25;

 -- select with birthday
select * from Students where DOB between '1997-11-21' and '2001-02-25'

--CLASS
-- Add 
insert into CLASS (IdClass,Class, ClassStart, ClassEnd, IdTeacher) 
values (1502,'Giai tích 1','20011111','20091111',1023);

-- update
UPDATE CLASS
SET Class='HIEU', ClassStart='20011111',ClassEnd='20181212',IdTeacher='1023'
WHERE IdClass=1502;

--delete
DELETE FROM STUDENTS
WHERE IdClass=1502;

-- search
select * from Class where IdClass=1502; 

select * from Class where IdStudent=123111;

select * from Class where ClassEnd between '1997-11-21' and '2024-02-25'

select * from Class where ClassStart between '1997-11-21' and '2022-02-25'

-- TEACHER

-- top 10 Student with the highest score in class
select top 10 FullName, score 
from Students
where Students.IdClass = 123001
order by score desc 

-- AVG score of Class
select Class.IdClass, Class.Class, AVG(Students.score) as 'average score'
from Class, Students
where Students.IdClass = Class.IdClass
group by Class.IdClass, Class.Class
order by AVG(Students.score) desc

-- Search Class By Teacher
select Teacher.FullName, Count(Class.IdClass)
from Teacher, Class
where Teacher.IdTeacher = Class.IdTeacher
group by Teacher.FullName
order by Count(Class.IdClass) desc

-- top 10 Teacher with the highest averga score 

select top 10 Teacher.FullName, AVG(Students.score) as 'avg score'
from Teacher, Students, Class
where Teacher.IdTeacher = Class.IdTeacher and Students.IdClass = Class.IdClass
group by Teacher.FullName
order by AVG(Students.score) desc

SELECT top 10 FullName, AVG(score) as 'avg'
from (
(Teacher inner join Class on Teacher.IdTeacher = Class.IdTeacher)
INNER join Student on Class.IdClass = Student.IdClass)
group by FullName

--Teacher have the most class

select top 1 Teacher.FullName, Count(Class.IdClass)
from Teacher, Class
where Teacher.IdTeacher = Class.IdTeacher
group by Teacher.FullName
order by Count(Class.IdClass) desc

-- count male
select Class.IdClass, Class.Class, COUNT(Students.IdStudent) as 'count male'
from Students, Class
where Students.IdClass = Class.IdClass and Students.Gender = 'male'
group by Class.IdClass, Class.Class

select Class.IdClass, Class.Class, count(IdStudent) as 'male count' from 
Class inner join Students
on Class.IdClass = Students.IdClass and Students.Gender = 'male'
group by Class.IdClass, Class.Class

