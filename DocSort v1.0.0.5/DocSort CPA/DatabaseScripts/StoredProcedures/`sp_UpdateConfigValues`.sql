DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_UpdateConfigValues`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_UpdateConfigValues`(IN ConfigId INT,IN ConfigValue LONGTEXT)
BEGIN
UPDATE tbl_config SET Config_Value=ConfigValue
WHERE Config_ID=ConfigId;
END$$

DELIMITER ;