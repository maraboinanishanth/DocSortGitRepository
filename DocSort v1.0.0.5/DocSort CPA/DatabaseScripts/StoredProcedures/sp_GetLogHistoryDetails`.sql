DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_GetLogHistoryDetails`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetLogHistoryDetails`()
BEGIN
SELECT * FROM tbl_loghistory;
END$$

DELIMITER ;