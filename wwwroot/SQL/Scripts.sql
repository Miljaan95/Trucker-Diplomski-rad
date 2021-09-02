CREATE TABLE UserRoles
(
	Id int Primary Key, 
	Name nvarchar(50)
);

INSERT INTO UserRoles
(Id, Name)
VALUES
(1, 'Admin'),
(2, 'Driver'),
(3, 'Tenant')


CREATE TABLE UserRoleMapping
(
	UserId int FOREIGN KEY REFERENCES Users (Id), 
	RoleId int FOREIGN KEY REFERENCES UserRoles (Id)
)

CREATE TABLE DriverProfile
(
	UserId int FOREIGN KEY REFERENCES Users (Id), 
	DrivingExperience int,
	Country nvarchar(30),
	DrivingLicenceFrom DateTime,
	CompanyName nvarchar(50)
);