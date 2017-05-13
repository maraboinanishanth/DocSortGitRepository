DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_GetFolderDetails`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetFolderDetails`()
BEGIN
SELECT * FROM tbl_folder;
END$$

DELIMITER ;