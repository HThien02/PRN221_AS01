-- Sử dụng cơ sở dữ liệu master
USE master;
GO 
-- Tạo cơ sở dữ liệu PRN221_AS1
CREATE DATABASE PRN221_AS1;
GO

USE PRN221_AS1;
GO

-- Tạo bảng Product
CREATE TABLE Product (
    ProductId INT  PRIMARY KEY,
    CategoryId INT NOT NULL,
    ProductName VARCHAR(40) NOT NULL,
    Weight VARCHAR(20),
    UnitPrice MONEY NOT NULL,
    UnitslnStock INT NOT NULL
);
GO

-- Tạo bảng Member
CREATE TABLE Member (
    MemberId INT PRIMARY KEY,
    Email VARCHAR(100) NOT NULL,
    CompanyName VARCHAR(40) NOT NULL,
    City VARCHAR(15) NOT NULL,
    Country VARCHAR(15) NOT NULL,
    Password VARCHAR(15) NOT NULL
);
GO

-- Tạo bảng Order
CREATE TABLE Orders (
    OrderId INT PRIMARY KEY,
    MemberId INT NOT NULL,
    OrderDate DATETIME NOT NULL,
    RequiredDate DATETIME,
    ShippedDate DATETIME,
    Freight MONEY,
    FOREIGN KEY (MemberID) REFERENCES Member(MemberID)
);
GO

-- Tạo bảng OrderDetail
CREATE TABLE OrderDetail (
    OrderId INT NOT NULL,
    ProductId INT NOT NULL,
    UnitPrice MONEY NOT NULL,
    Quantity INT NOT NULL,
    Discount FLOAT NOT NULL,
    PRIMARY KEY (OrderID, ProductID),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);
GO

--insert Product
INSERT INTO Product (ProductId, CategoryId, ProductName, Weight, UnitPrice,  UnitslnStock)
VALUES
    (1, 1, 'Iphone 14 pro max', '150', 2500, 100),
    (2, 1, 'Iphone 12 mini', '130', 1900, 150);

--insert member
INSERT INTO Member (MemberId, Email, CompanyName, City, Country, Password)
VALUES
    (1, 'locpx1@gmail.com', 'FPT', 'Ha Noi', 'Viet Nam', '123'),
    (2, 'Vinhpt1@gmail.com', 'Viettel', 'Nam Dinh', 'Viet Nam', '123');

--insert order
INSERT INTO Orders (OrderId, MemberId, OrderDate, RequiredDate, ShippedDate, Freight)
VALUES
    (1, 1, '2023-08-01', '2023-08-10', '2023-08-05', 5.99),
    (2, 1, '2023-08-02', '2023-08-12', '2023-08-06', 8.99);

--insert orderDetail
INSERT INTO OrderDetail (OrderId, ProductId, UnitPrice, Quantity, Discount)
VALUES
    (1, 1, 25.99, 3, 0.1),
    (1, 2, 19.99, 2, 0.05);

