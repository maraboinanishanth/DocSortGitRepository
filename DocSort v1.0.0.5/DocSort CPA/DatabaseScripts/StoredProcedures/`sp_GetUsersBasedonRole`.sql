DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_GetUsersBasedonRole`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetUsersBasedonRole`(IN RoleId INT)
BEGIN
SELECT * FROM tbl_users WHERE Role_ID =RoleId;
END$$

DELIMITER ;