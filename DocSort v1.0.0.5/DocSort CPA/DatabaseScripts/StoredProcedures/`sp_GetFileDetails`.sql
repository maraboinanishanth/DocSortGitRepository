DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_GetFileDetails`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetFileDetails`()
BEGIN
SELECT * FROM tbl_files;
END$$

DELIMITER ;