DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_GetUserDetailsUsingUserID`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetUserDetailsUsingUserID`(IN UserId INT)
BEGIN
SELECT * FROM tbl_users WHERE User_ID=UserId;
END$$

DELIMITER ;