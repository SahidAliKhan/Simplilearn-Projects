use Rainbow_School

create table Class( ClassID int primary key, ClassName varchar(10) )

create table Students( StudentID int primary key, StudentName varchar(10), ClassID int foreign key references Class(ClassID), SubjectName varchar(20), Marks int )

create table Subjects( SubjectID int primary key, SubjectName varchar(20), ClassID int foreign key references Class(ClassID))