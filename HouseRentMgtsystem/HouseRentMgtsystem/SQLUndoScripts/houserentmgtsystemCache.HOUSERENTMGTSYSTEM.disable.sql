-- This code can be used to disable change tracking within your database
-- Please ensure all tables have stopped using chagne tracking before executing this code
    
IF EXISTS (SELECT * FROM sys.change_tracking_databases WHERE database_id = DB_ID(N'C:\USERS\ADMIN\DOCUMENTS\HOUSERENTMGTSYSTEM.MDF')) 
  ALTER DATABASE [C:\USERS\ADMIN\DOCUMENTS\HOUSERENTMGTSYSTEM.MDF] 
  SET  CHANGE_TRACKING = OFF
GO
