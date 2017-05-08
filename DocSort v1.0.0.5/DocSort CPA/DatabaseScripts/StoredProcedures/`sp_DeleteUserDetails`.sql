DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_DeleteUserDetails`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteUserDetails`(IN UserId INT)
BEGIN
UPDATE tbl_users
SET STATUS=0
WHERE User_ID=UserId;
END$$

DELIMITER ;