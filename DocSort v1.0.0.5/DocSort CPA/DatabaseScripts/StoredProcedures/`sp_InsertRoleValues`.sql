DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_InsertRoleValues`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_InsertRoleValues`(IN Rolename VARCHAR(45),IN Roledesc VARCHAR(50),IN Isactive BIT(1))
BEGIN
INSERT INTO tbl_roles
(
Role_Name,
Role_Desc,
IsActive
)
VALUES
(
Rolename,
Roledesc,
Isactive
);
END$$

DELIMITER ;