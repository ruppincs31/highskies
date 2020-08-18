--CREATE TABLE Discount_CS (
--	DiscountId int primary key,
--	AirlineCode nvarchar (64) not null,
--	AirportFrom nvarchar (64) not null,
--	AirportTo nvarchar (64) not null,
--	DateFrom datetime not null,
--	DateTo datetime not null,
--	DiscountValue int not null
--);


--INSERT INTO Discount_CS(DiscountId, AirlineCode, AirportFrom, AirportTo, DateFrom, DateTo, DiscountValue)
--VALUES ('4', 'W6' ,'LTN', 'TLV', '2020-06-13', '2020-06-14', 5);

--INSERT INTO Discount_CS(DiscountId, AirlineCode, AirportFrom, AirportTo, DateFrom, DateTo, DiscountValue)
--VALUES ('5', 'W9' ,'LTN', 'TLV', '2020-06-13', '2020-06-15', 8);

select * from Discount_CS

--CREATE TABLE Orders_CS (
--	OrderId int identity(1,1) primary key,
--	PassengersNames nvarchar (512) not null,
--	PassengerEmail nvarchar (512) not null,
--	OrderDate datetime not null
--);

--DELETE FROM Discount_CS;