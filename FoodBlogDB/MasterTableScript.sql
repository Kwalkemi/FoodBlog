/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
Declare @PostDate datetime 

Set @PostDate = '2020-04-25 23:27:20.497'

IF NOT EXISTS(SELECT 1 FROM Food_Blog_Master where Food_Blog_Post_Unique_Id = 'Gobi_Aalo')
BEGIN
	INSERT INTO Food_Blog_Master VALUES(1, 'Gobi_Aalo', 'Gobi Aloo', @PostDate)
END

Set @PostDate = DateAdd(day,2,@PostDate)

IF NOT EXISTS(SELECT 1 FROM Food_Blog_Master where Food_Blog_Post_Unique_Id = 'Methi_Aalo')
BEGIN
	INSERT INTO Food_Blog_Master VALUES(2, 'Methi_Aalo', 'Methi Aloo', @PostDate)
END

Set @PostDate = DateAdd(day,3,@PostDate)

IF NOT EXISTS(SELECT 1 FROM Food_Blog_Master where Food_Blog_Post_Unique_Id = 'Veg_Kofta')
BEGIN
	INSERT INTO Food_Blog_Master VALUES(3, 'Veg_Kofta', 'Veg Kofta', @PostDate)
END