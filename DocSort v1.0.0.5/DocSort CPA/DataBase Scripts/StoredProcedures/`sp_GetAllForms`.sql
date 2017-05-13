DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_GetAllForms`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetAllForms`()
BEGIN
SELECT * FROM tbl_forms;
END$$

DELIMITER ;