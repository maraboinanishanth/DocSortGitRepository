DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_DeleteFileDetails`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteFileDetails`(IN FileId INT,IN Isdelete VARCHAR(5))
BEGIN
UPDATE tbl_files SET IsDelete=Isdelete WHERE File_ID=FileId;
END$$

DELIMITER ;