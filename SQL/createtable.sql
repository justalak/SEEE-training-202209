create table teacher (
	id INT NOT NULL PRIMARY KEY,
	name VARCHAR(50),
	phone VARCHAR(50),
	email VARCHAR(50)
);

create table class (
	id INT NOT NULL PRIMARY KEY,
	nameclass VARCHAR(50),
	time_start VARCHAR(50),
	time_finish VARCHAR(50),
	teacherId INT,
  	FOREIGN KEY (teacherId) REFERENCES teacher(id)
);

create table student (
	id INT NOT NULL PRIMARY KEY,
	name VARCHAR(50),
	gender VARCHAR(50),
	email VARCHAR(50),
	score INT,
	classId INT,
  FOREIGN KEY (classId) REFERENCES class(id)
);