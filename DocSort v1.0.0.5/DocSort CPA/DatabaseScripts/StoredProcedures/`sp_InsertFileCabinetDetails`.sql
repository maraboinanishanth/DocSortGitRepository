DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_InsertFileCabinetDetails`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_InsertFileCabinetDetails`(IN FileCabinetname VARCHAR(250),IN Isdelete VARCHAR(5))
BEGIN
INSERT INTO tbl_filecabinet
(
FileCabinet_Name,
IsDelete
)
VALUES
(
FileCabinetname,
Isdelete
);
SELECT LAST_INSERT_ID() AS CabinetID;
END$$

DELIMITER ;