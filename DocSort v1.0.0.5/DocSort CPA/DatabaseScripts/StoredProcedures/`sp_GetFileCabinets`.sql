DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_GetFileCabinets`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetFileCabinets`()
BEGIN
SELECT * FROM tbl_filecabinet WHERE IsDelete='True';
END$$

DELIMITER ;