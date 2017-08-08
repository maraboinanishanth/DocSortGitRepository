-- Queries related to Delete Folder Feature

INSERT INTO tbl_menus (MenuName,Description,MainMenuId) 
VALUES ('Delete Folder','Delete Folder Desc', 2)

SELECT * FROM tbl_menus -- This query will let us know the inserted menuid which is 30 in our case

-- Now INSERT INTO tbl_forms with the new MenuID inserted by above INSERT statement. which may be 30 in our case

INSERT INTO tbl_forms (FormClassName,FormName,MenuID,STATUS) 
VALUES ('DeleteCabinetFolder','Delete Cabinet Folder',30,1)