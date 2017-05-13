DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_DeleteFolderDetails`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteFolderDetails`(IN FolderId INT,IN Isdelete VARCHAR(5))
BEGIN
UPDATE tbl_folder SET
IsDelete=Isdelete
WHERE Folder_ID=FolderId;
END$$

DELIMITER ;