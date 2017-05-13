DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_InsertScannedDocumentResults`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_InsertScannedDocumentResults`(IN DATE VARCHAR(50),IN KeywordId INT,IN DocumentId INT,IN DocumentPath LONGTEXT,IN matchstatus VARCHAR(15))
BEGIN
INSERT INTO tbl_scanneddocumentresults
(
DATE,
Keyword_ID,
Document_ID,
Document_Path,
MatchStatus
)
VALUES
(
DATE,
KeywordId,
DocumentId,
DocumentPath,
matchstatus
);
END$$

DELIMITER ;