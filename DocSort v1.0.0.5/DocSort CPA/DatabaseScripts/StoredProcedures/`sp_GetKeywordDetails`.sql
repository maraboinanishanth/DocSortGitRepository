DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_GetKeywordDetails`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetKeywordDetails`()
BEGIN
SELECT * FROM tbl_keywords;
END$$

DELIMITER ;