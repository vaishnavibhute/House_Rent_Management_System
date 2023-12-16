IF NOT EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[TenantTb1]')) 
   ALTER TABLE [dbo].[TenantTb1] 
   ENABLE  CHANGE_TRACKING
GO
