DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_InsertUpdateUserAccessPermissions`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_InsertUpdateUserAccessPermissions`(IN RoleId INT,IN FormId INT,IN Isview BIT(1))
BEGIN
IF((SELECT COUNT(*) FROM tbl_useraccesspermission WHERE Role_ID =RoleId AND Form_ID = FormId  ) >0 ) THEN
UPDATE tbl_UserAccessPermission
SET
IsView = Isview
WHERE Role_ID = RoleId AND Form_ID = FormId;
ELSE
INSERT INTO tbl_UserAccessPermission
(
Role_ID,
Form_ID,
IsView
)
VALUES
(
RoleId,
FormId,
Isview
);
END IF;
END$$

DELIMITER ;