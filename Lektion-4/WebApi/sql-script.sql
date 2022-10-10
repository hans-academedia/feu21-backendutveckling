CREATE TABLE Categories (
	Id int not null identity primary key,
	Name nvarchar(150) not null
)
GO

CREATE TABLE Products (
	Id int not null identity primary key,
	Name nvarchar(150) not null,
	Description nvarchar(max) null,
	Price decimal not null,
	Quantity int not null,
	CategoryId int not null references Categories(Id)
)
GO

INSERT INTO Categories (Name) VALUES ('TV'),('Multimedia'),('Telefoni')

INSERT INTO Products (Name, Price, Quantity, CategoryId) 
	VALUES ('Product 1', 100, 20, 1), ('Product 2', 200, 52, 3)

SELECT * FROM Categories
SELECT * FROM Products

SELECT
	p.Id, p.Name, p.Price, p.Quantity,
	c.Name as Category
FROM Products p
JOIN Categories c ON c.Id = p.CategoryId