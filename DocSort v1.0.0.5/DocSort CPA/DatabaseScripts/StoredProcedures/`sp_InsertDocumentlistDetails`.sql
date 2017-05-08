DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_InsertDocumentlistDetails`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_InsertDocumentlistDetails`(IN DATE VARCHAR(50),IN Filename VARCHAR(250),IN Processtype VARCHAR(50))
BEGIN
INSERT INTO tbl_documentslist
(
DATE,
File_Name,
ProcessType
)
VALUES
(
DATE,
Filename,
Processtype
);
SELECT LAST_INSERT_ID() DocumentId;
END$$

DELIMITER ;