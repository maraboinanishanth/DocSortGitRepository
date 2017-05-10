DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_GetUserPermissions`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetUserPermissions`(IN RoleId INT)
BEGIN
IF((SELECT COUNT(*) FROM tbl_Useraccesspermission WHERE Role_ID = RoleId) >0) THEN
SELECT * FROM tbl_Useraccesspermission WHERE Role_ID = RoleId;
ELSE 
SELECT * FROM tbl_Useraccesspermission WHERE Role_ID = RoleId;
END IF;
END$$

DELIMITER ;