SELECT * from SYS.Databases

use CityInfo
select * from sys.tables
select * from Cities

sp_help Cities


USE master;
GO
ALTER DATABASE CityInfo SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO

Drop DATABASE CityInfo