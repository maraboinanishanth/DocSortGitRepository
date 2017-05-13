DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_GetRoles`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetRoles`()
BEGIN
SELECT * FROM tbl_roles;
END$$

DELIMITER ;