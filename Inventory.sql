CREATE DATABASE InventoryDB;
GO

USE InventoryDB;
GO

CREATE TABLE Users (
    UserID INT ,
    Name NVARCHAR(100) NOT NULL,
    Password NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Role NVARCHAR(50) NOT NULL CHECK (Role IN ('Administrator', 'Stock Clerk'))
);
GO

CREATE TABLE Suppliers (
    SupplierID INT PRIMARY KEY ,
    Name NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20),
    Email NVARCHAR(100)
);
GO

CREATE TABLE Products (
    ProductID INT PRIMARY KEY ,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX),
    Quantity INT NOT NULL,
    Price DECIMAL(10, 2),
    SupplierID INT FOREIGN KEY REFERENCES Suppliers(SupplierID)
);
GO
INSERT INTO Users  VALUES
(1,'Ahmed', 'pass123', 'ahmed@example.com', 'Administrator'),
(2,'belal', 'belal123', 'belal@example.com', 'Stock Clerk'),
(3,'ziad', 'ziad123', 'ziad@example.com', 'Stock Clerk');
go
INSERT INTO Suppliers  VALUES
(1,'Global Supplies Inc.', '123-456-7890', 'contact@globalsupplies.com'),
(2,'TechSource Ltd.', '987-654-3210', 'sales@techsource.com'),
(3,'EcoGoods Co.', '555-123-4567', 'info@ecogoods.com');
go
INSERT INTO Products  VALUES
(1,'Wireless Mouse', 'Ergonomic wireless mouse with USB receiver', 150, 19.99, 1),
(2,'Laptop Stand', 'Adjustable aluminum stand for laptops', 75, 29.50, 2),
(3,'Reusable Water Bottle', 'Eco-friendly BPA-free bottle', 200, 12.00, 3),
(4,'USB-C Hub', 'Multiport adapter with HDMI and USB 3.0', 50, 34.99, 2),
(5,'Notebook', 'A5 size ruled notebook', 300, 3.25, 3);
go

	select * from Users
	select * from Suppliers
	select * from Products

