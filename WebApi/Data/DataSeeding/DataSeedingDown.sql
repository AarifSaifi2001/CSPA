--------------------
--Seeding Down
--------------------
DECLARE @UserID as int
SET @UserID = (select id from Users where username='Demo')
delete from Users where username='Demo'
delete from FueTypes where LastUpdatedBy=@UserID
delete from BodyTypes where LastUpdatedBy=@UserID
delete from Cities where LastUpdatedBy=@UserID
delete from Cars where PostedBy=@UserId