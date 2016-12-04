Go
create table IngradientCategory(
	CategoryID int IDENTITY(1,1) PRIMARY KEY,
	CategoryName varchar(50) not null
	)
	
Go
create table Ingradient(
	IngradientID int IDENTITY(1,1)  PRIMARY KEY,
	IngradientName varchar(50) not null,
	TotalWeght int not null,
	CategoryID int FOREIGN KEY REFERENCES IngradientCategory(CategoryID)
	)
	
Go
create table Shawarma(
	ShawarmaID int IDENTITY(1,1)  PRIMARY KEY,
	ShawarmaName varchar(50) not null,
	CookingTime int not null
	)
	
Go
create table ShawarmaRecipe(
	ShawarmaRecipeID int IDENTITY(1,1)  PRIMARY KEY,
	Weght int not null,
	IngradientID int FOREIGN KEY REFERENCES Ingradient(IngradientID),
	ShawarmaID int FOREIGN KEY REFERENCES Shawarma(ShawarmaID)
	)
	
Go
create table SellingPointCategory(
	SellingPointCategoryID int IDENTITY(1,1)  PRIMARY KEY,
	SellingPointCategoryName varchar(100) not null
	)
	
Go
create table SellingPoint(
	SellingPointID int IDENTITY(1,1)  PRIMARY KEY,
	Address varchar(200) not null,
	ShawarmaTitile varchar(100) not null,
	SellingPointCategoryID int FOREIGN KEY REFERENCES SellingPointCategory(SellingPointCategoryID)
	)
Go
create table PriceController(
	PriceControllerID int IDENTITY(1,1)  PRIMARY KEY,
	Price int not null,
	Comment text ,
	ShawarmaID int FOREIGN KEY REFERENCES Shawarma(ShawarmaID),
	SellingPointID int FOREIGN KEY REFERENCES SellingPoint(SellingPointID)
	)
	
	
Go
create table Seller(
	SellerID int IDENTITY(1,1)  PRIMARY KEY,
	SellerName varchar(50) not null,
	SellingPointID int FOREIGN KEY REFERENCES SellingPoint(SellingPointID)
	)

Go
create table TimeController(
	TimeControllerID int IDENTITY(1,1)  PRIMARY KEY,
	WorkStart datetime not null,
	WorkEnd datetime not null,
	SellerID int FOREIGN KEY REFERENCES Seller(SellerID)
	)
	
Go
create table OrderHeader(
	OrderHeaderID int IDENTITY(1,1)  PRIMARY KEY,
	OrderDate date not null,
	SellerID int FOREIGN KEY REFERENCES Seller(SellerID)
	)
	
Go
create table OrderDetails(
	Quantity int not null,
	OrderHeaderID int FOREIGN KEY REFERENCES OrderHeader(OrderHeaderID),
	ShawarmaID int FOREIGN KEY REFERENCES Shawarma(ShawarmaID)
	)