DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_UpdateAdminPassword`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_UpdateAdminPassword`(IN UserName VARCHAR(50),IN Pwd VARCHAR(45))
BEGIN
UPDATE tbl_users SET PASSWORD=Pwd WHERE User_Name=UserName;
END$$

DELIMITER ;