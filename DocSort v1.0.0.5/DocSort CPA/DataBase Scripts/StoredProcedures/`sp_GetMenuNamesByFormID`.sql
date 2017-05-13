DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_GetMenuNamesByFormID`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetMenuNamesByFormID`(IN FormId INT)
BEGIN
SET @MenuId:=(SELECT MenuID FROM tbl_forms WHERE Form_ID = FormId);
SET @TempMenuName :=(SELECT MenuName FROM tbl_Menus WHERE MenuID = @MenuId);
SELECT @TempMenuName;
END$$

DELIMITER ;