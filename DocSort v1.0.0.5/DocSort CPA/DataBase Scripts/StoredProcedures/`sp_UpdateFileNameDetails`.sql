DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_UpdateFileNameDetails`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_UpdateFileNameDetails`(IN FileId INT,IN Filename VARCHAR(250))
BEGIN
UPDATE tbl_files SET
File_Name=Filename
WHERE File_ID=FileId;
END$$

DELIMITER ;