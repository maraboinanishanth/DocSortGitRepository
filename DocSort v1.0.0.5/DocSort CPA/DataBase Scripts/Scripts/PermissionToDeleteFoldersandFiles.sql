-- Queries related to Delete Folder Feature

INSERT INTO tbl_menus (MenuName,Description,MainMenuId) 
VALUES ('Delete Folder','Delete Folder Desc', 2); -- 2 is MainMenuId of Cabinet View

INSERT INTO tbl_forms (FormClassName,FormName,MenuID,STATUS) 
VALUES ('DeleteCabinetFolder','Delete Cabinet Folder',LAST_INSERT_ID(),1);

-- Queries related to Delete User Feature

INSERT INTO tbl_menus (MenuName,Description,MainMenuId) 
VALUES ('Delete User','Delete User Desc', 5) ;-- 5 is MainMenuId of Uses access permission

INSERT INTO tbl_forms (FormClassName,FormName,MenuID,STATUS) 
VALUES ('DeleteUser','Delete User', LAST_INSERT_ID(),1);
