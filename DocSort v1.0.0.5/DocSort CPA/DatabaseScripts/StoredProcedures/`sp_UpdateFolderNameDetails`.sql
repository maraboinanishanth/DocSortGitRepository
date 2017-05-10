DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_UpdateFolderNameDetails`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_UpdateFolderNameDetails`(IN FolderId INT,IN Foldername VARCHAR(250))
BEGIN
UPDATE tbl_folder SET
Folder_Name=Foldername
WHERE Folder_ID=FolderId;
END$$

DELIMITER ;