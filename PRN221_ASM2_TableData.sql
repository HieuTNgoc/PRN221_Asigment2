Create database PizzaStore_01

-------------------------------------------------------------------------
create table Customers(
	CustomerID int primary key identity(1,1),
	[Password] varchar(50), 
	ContactName varchar(50),
	[Address] varchar(255),
	Phone varchar(15),
)

Create table  Orders(
	OrderID int primary key identity(1,1), 
	OrderDate DateTime,
	RequiredDate DateTime,
	ShippedDate DateTime,
	Freght money,
	ShipAddress varchar(255),
	CustomerID  int foreign key references Customers(CustomerID),
)


create table Categories(
	CategoryID int primary key identity(1,1),
	CategoryName varchar(255),
	[Description] nvarchar(max),
)

create table Suppliers(
	SupplierID int primary key identity(1,1),
	CompanyName varchar(255),
	[Address] varchar(255),
	Phone varchar(15),
)

create table Products(
	ProductID int primary key identity(1,1),
	ProductName varchar(255),
	QuantityPerUnit int,
	UnitPrice int,
	ProductImage varchar(255),
	SupplierID int foreign key references Suppliers(SupplierID),
	CategoryID int foreign key references Categories(CategoryID),
)

Create table OrderDetails(
	OrderID int foreign key references Orders(OrderID),
	ProductID int foreign key references Products(ProductID),
	Primary Key (OrderID, ProductID),
	UnitPrice int,
	Quantity int,
)

create table Account(
	AccountID int primary key identity(1,1),
	UserName varchar(50),
	[Password] varchar(50),
	FullName varchar(255),
	[Type] smallint
)