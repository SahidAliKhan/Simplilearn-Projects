use CustomerDB

create table UserInfo(UserID int primary key, Email nvarchar(100), Password nvarchar(20))

create table CustLogInfo(LogID int primary key, CustEmail nvarchar(100), CustName nvarchar(50),
LogStatus nvarchar(50), UserID int foreign key references UserInfo(UserID), Description nvarchar(50))

insert into UserInfo values(1,'sahid@gmail.com','Hello@123456')
insert into UserInfo values(2,'ramy@gmail.com','Hello@123456')
insert into UserInfo values(3,'david@gmail.com','Hello@123456')

select * from UserInfo
select * from CustLogInfo