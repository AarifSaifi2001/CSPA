DECLARE @UserID as INT
--------------------------
--Create User
--------------------------
IF not exists (select id from Users where username='Demo')
insert into Users(username,password, passwordKey,email,mobileno,LastUpdatedOn,LastUpdatedBy)
select 'Demo',
0x4D5544D09B8319B423F6D4E054360D5289B57A98781A66B276E00C57919FDCD599BF45623D48CC81F535748F560AF0F70C8C7F3B4C3DB672562B5DD0E5E7C297,
0x44A0BD5BFD689DF399346200A1117C33BEDF5869C17A7CB3DC6D8598A93845DB333B379AA90931D8D4E5F2CC7B1A4A96A7DB71B186DBCDCDC53B0A95440E4EDD7473668627970FBD9BB0BA17530CCAB2D9446A1902BD6AC12FE691FE09DD78A43398B89111056145843060026A414FFA8C5E75B474E187AD753D2872038D9FDD,
'demo@gmail.com',
6398859563,
getdate(),
0

SET @UserID = (select id from Users where username='Demo')

--------------------------
--Seed Body Types
--------------------------
IF not exists (select body from BodyTypes where body='SUV')
insert into BodyTypes(body,LastUpdatedOn,LastUpdatedBy)
select 'SUV', GETDATE(),@UserID

IF not exists (select body from BodyTypes where body='SEDAN')
insert into BodyTypes(body,LastUpdatedOn,LastUpdatedBy)
select 'SEDAN', GETDATE(),@UserID

IF not exists (select body from BodyTypes where body='HATCHBACK')
insert into BodyTypes(body,LastUpdatedOn,LastUpdatedBy)
select 'HATCHBACK', GETDATE(),@UserID

IF not exists (select body from BodyTypes where body='VAN')
insert into BodyTypes(body,LastUpdatedOn,LastUpdatedBy)
select 'VAN', GETDATE(),@UserID

IF not exists (select body from BodyTypes where body='MUV')
insert into BodyTypes(body,LastUpdatedOn,LastUpdatedBy)
select 'MUV', GETDATE(),@UserID

--------------------------
--Seed Fuel Types
--------------------------
IF not exists (select fuel from FuelTypes where fuel='CNG')
insert into FuelTypes(fuel, LastUpdatedOn, LastUpdatedBy)
select 'CNG', GETDATE(),@UserID

IF not exists (select fuel from FuelTypes where fuel='DIESEL')
insert into FuelTypes(fuel, LastUpdatedOn, LastUpdatedBy)
select 'DIESEL', GETDATE(),@UserID

IF not exists (select fuel from FuelTypes where fuel='PETROL')
insert into FuelTypes(fuel, LastUpdatedOn, LastUpdatedBy)
select 'PETROL', GETDATE(),@UserID

IF not exists (select fuel from FuelTypes where fuel='LPG')
insert into FuelTypes(fuel, LastUpdatedOn, LastUpdatedBy)
select 'LPG', GETDATE(),@UserID

--------------------------
--Seed Cities
--------------------------
IF not exists (select top 1 id from Cities)
Insert into Cities(name,LastUpdatedBy,LastUpdatedOn)
select 'New York',@UserID,getdate()
union
select 'Houston',@UserID,getdate()
union
select 'Los Angeles',@UserID,getdate()
union
select 'New Delhi',@UserID,getdate()
union
select 'Bangalore',@UserID,getdate()

--------------------------
--Seed Cars
--------------------------
--Seed car for sell
IF not exists (select top 1 name from Cars where Name='Creta')
insert into Properties(Name,Price,SellRent,km,CitiesId,modelyear,FuelTypeId,carbrand,BodyTypeId,owner,state,cardesc,PostedOn,PostedBy,LastUpdatedOn,LastUpdatedBy)
select 
'Creta', --Name
1800, --Price
1, --Sell Rent
37537, --km
(select top 1 Id from Cities), -- City ID
2020,
(select id from FuelTypes where fuel='PETROL'), --Fuel Type ID
Hyundai, -- carbrand
(select id from BodyTypes where body='SUV'), --Body Type ID,
1, -- owner
UttarPradesh, -- state
'Well Maintained builder floor available for rent at prime location. # property features- - 5 mins away from metro station - Gated community - 24*7 security. # property includes- - Big rooms (Cross ventilation & proper sunlight) - 
Drawing and dining area - Washrooms - Balcony - Modular kitchen - Near gym, market, temple and park - Easy commuting to major destination. Feel free to call With Query.', --Description
GETDATE(), --Posted on
@UserID, --Posted by
GETDATE(), --Last Updated on
@UserID --Last Updated by

---------------------------
--Seed Car for rent
---------------------------
IF not exists (select top 1 name from Cars where Name='Swift')
insert into Properties(Name,Price,SellRent,km,CitiesId,modelyear,FuelTypeId,carbrand,BodyTypeId,owner,state,cardesc,PostedOn,PostedBy,LastUpdatedOn,LastUpdatedBy)
select 
'Swift', --Name
1800, --Price
2, --Sell Rent
37537, --km
(select top 1 Id from Cities), -- City ID
2018,
(select id from FuelTypes where fuel='PETROL'), --Fuel Type ID
Maruti Suzuki, -- carbrand
(select id from BodyTypes where body='SUV'), --Body Type ID,
2, -- owner
UttarPradesh, -- state
'Well Maintained builder floor available for rent at prime location. # property features- - 5 mins away from metro station - Gated community - 24*7 security. # property includes- - Big rooms (Cross ventilation & proper sunlight) - 
Drawing and dining area - Washrooms - Balcony - Modular kitchen - Near gym, market, temple and park - Easy commuting to major destination. Feel free to call With Query.', --Description
GETDATE(), --Posted on
@UserID, --Posted by
GETDATE(), --Last Updated on
@UserID --Last Updated by