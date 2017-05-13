DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_GetLogHistoryDetailsGO`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetLogHistoryDetailsGO`(IN LogDate VARCHAR(50))
BEGIN
SELECT * FROM tbl_loghistory WHERE Log_Date=LogDate;
END$$

DELIMITER ;