DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_CheckDuplicateUser`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_CheckDuplicateUser`(IN Username VARCHAR(50))
BEGIN
SELECT * FROM tbl_users WHERE User_Name=Username;
END$$

DELIMITER ;