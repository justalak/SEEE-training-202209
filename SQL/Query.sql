--update diem hoc sinh
UPDATE student SET score = 10 WHERE id = 6;

--Câu lenh xoa sinh vien : 
DROP teacher WHERE id = 3;

--Tim kiem sinh vien voi id = 11 :
SELECT student.name, student.gender, student.score FROM student WHERE id = 11;

--Lay danh sach sinh vien, giao vien, lop:
SELECT * FROM student;
SELECT * FROM teacher;
SELECT * FROM class;

--Ðem so sinh vien trong moi lop
SELECT class.nameclass ,COUNT(student.id) AS 'so sinh vien'
FROM student, class
WHERE student.classId = class.id
GROUP BY class.nameclass;

--10 sinh vien co diem cao nhat lop bat ki
SELECT TOP 3 student.name,COUNT(student.score) AS 'diemcaonhat'
FROM student
WHERE student.classId = 11
GROUP BY student.name;

--so hoc sinh nam moi lop
SELECT class.nameclass ,COUNT(student.id) AS 'so sinh vien nam'
FROM student, class
WHERE student.classId = class.id AND student.gender = 'Male'
GROUP BY class.nameclass;

--Lay diem trung binh tung lop
SELECT class.nameclass ,AVG(student.score) AS 'diemtrungbinh'
FROM student, class
WHERE student.classId = class.id
GROUP BY class.nameclass;

--Lay ra danh sach lop cua mot giao vien gia su muon lay danh sach giao vien co id la 1
SELECT teacher.name, class.nameclass
FROM teacher,class
WHERE teacher.id = 1; 

--Lay ra giao vien chu nhiem nhieu lop nhat
SELECT TOP 1 teacher.name,COUNT(class.id) AS 'So lop chu nhiem'
FROM teacher,class
WHERE teacher.id = class.teacherId
GROUP BY teacher.name
HAVING COUNT(class.id) >= ALL(SELECT COUNT(class.id)
FROM teacher,class
WHERE teacher.id = class.teacherId
GROUP BY teacher.name)