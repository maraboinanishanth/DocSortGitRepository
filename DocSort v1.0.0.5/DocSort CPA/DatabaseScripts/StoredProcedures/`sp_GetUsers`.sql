DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_GetUsers`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetUsers`()
BEGIN
SELECT *,CONCAT(FirstName,',',LastName) AS NAME FROM tbl_users WHERE STATUS=1;
END$$

DELIMITER ;