
select * from Teacher
select * from Student
select * from Class

-- insert --
insert into Teacher values
(101, 'Vũ Dũng', '2001-03-18', '2019-05-25', '0988877296', 'lvdund@gmail.com'),
(102, 'Linh Bong', '2005-09-14', '2020-05-25', '0385810618', 'giang25577@gmail.com'),
(103, 'Cam Dang', '2002-04-19', '2020-05-25', '0385810618', 'giang25577@gmail.com'),
(104, 'Thanh Dang', '2002-04-19', '2020-05-25', '0385810618', 'giang25577@gmail.com'),
(105, 'Vu Dung', '2002-04-19', '2020-05-25', '0385810618', 'giang25577@gmail.com')

-- delete --
delete from Teacher where idTeacher between 101 and 105

-- find --
select * from Teacher where birthday between '1987-11-21' and '1990-02-25' or nameTc like 'Vũ Dũng'

-- count --
select COUNT(idTeacher) from Teacher where nameTc like 'Vu Dung'

-- 10 học sinh có điểm cao nhât --
select top 10 nameSt, score 
from Student
where Student.idClass = 1
order by score desc

-- Số học sinh Nam --
select COUNT(idStudent) from Student where gender like 'm'

-- Thống kê số học sinh Nam mỗi lớp --
select Class.idClass, Class.nameCl, COUNT(Student.idStudent) as 'count male'
from Student, Class
where Student.idClass = Class.idClass and Student.gender = 'm'
group by Class.idClass, Class.nameCl

select Class.idClass, Class.nameCl, count(idStudent) as 'male count' from 
Class inner join Student
on Class.idClass = Student.idClass and Student.gender = 'm'
group by Class.idClass, Class.nameCl


-- Điểm trung bình từng lớp --
select Class.idClass, Class.nameCl, AVG(Student.score) as 'average score'
from Class, Student
where Student.idClass = Class.idClass
group by Class.idClass, Class.nameCl
order by AVG(Student.score) desc

-- Các lớp mà giáo viên chủ nhiệm --
select Teacher.nameTc, Count(Class.idClass)
from Teacher, Class
where Teacher.idTeacher = Class.idTeacher
group by Teacher.nameTc
order by Count(Class.idClass) desc




-- Giáo viên chủ nhiệm lướp nhiều nhất --
select top 1 Teacher.nameTc, Count(Class.idClass)
from Teacher, Class
where Teacher.idTeacher = Class.idTeacher
group by Teacher.nameTc
order by Count(Class.idClass) desc




-- 10 giáo viên có lớp có điểm trung bình cao nhất --
select top 10 Teacher.nameTc, AVG(Student.score) as 'avg score'
from Teacher, Student, Class
where Teacher.idTeacher = Class.idTeacher and Student.idClass = Class.idClass
group by Teacher.nameTc
order by AVG(Student.score) desc

SELECT top 10 nameTc, AVG(score) as 'avg'
from ((Teacher 
inner join Class on Teacher.idTeacher = Class.idTeacher)
INNER join Student on Class.idClass = Student.idClass)
group by nameTc



/*
full outer join		: gộp 2 bảng, bên nào ko có dữ liệu đặt là null
cross join			: gộp 2 bảng, 1 record bên A với tất cả bên B
left join			: gộp 2 bảng, bên trái có, phải ko có thì đặt null
union				: gộp 2 bảng
select * into		: clone bảng



*/