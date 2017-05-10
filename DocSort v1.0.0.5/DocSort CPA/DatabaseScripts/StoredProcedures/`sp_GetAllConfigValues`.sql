DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_GetAllConfigValues`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetAllConfigValues`()
BEGIN
SELECT * FROM tbl_config;
END$$

DELIMITER ;