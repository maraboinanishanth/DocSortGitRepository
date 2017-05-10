DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_AdminChangePassword`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_AdminChangePassword`(IN UserName VARCHAR(50),IN Pwd VARCHAR(45))
BEGIN
SELECT * FROM tbl_Users WHERE User_Name=UserName AND PASSWORD=Pwd;
END$$

DELIMITER ;