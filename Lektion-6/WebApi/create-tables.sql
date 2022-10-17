CREATE TABLE  Categories (
	Id int not null identity primary key,
	CategoryName nvarchar(100) not null
)
GO

CREATE TABLE Products (
	Id int not null identity primary key,
	Name nvarchar(200) not null,
	Price money not null,
	CategoryId int not null references Categories (Id)
)
