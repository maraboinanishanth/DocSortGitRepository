DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_DeleteFileCabinetDetails`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteFileCabinetDetails`(IN FilecabinetId INT,IN Isdelete VARCHAR(5))
BEGIN
UPDATE tbl_filecabinet SET
IsDelete=Isdelete
WHERE FileCabinet_ID=FilecabinetId;
END$$

DELIMITER ;