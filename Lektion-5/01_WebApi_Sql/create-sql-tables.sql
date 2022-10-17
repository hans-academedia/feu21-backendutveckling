CREATE TABLE Categories (
	Id int not null identity primary key,
	Name nvarchar(100) not null unique
)
GO

CREATE TABLE SubCategories (
	Id int not null identity primary key,
	Name nvarchar(100) not null unique,
	CategoryId int not null references Categories(Id)
)
GO

CREATE TABLE Products (
	Id int not null identity primary key,
	Name nvarchar(200) not null,
	Price money not null,
	CategoryId int not null references Categories(Id),
	VendorArticleNumber nvarchar(200) null
)
GO