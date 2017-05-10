DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_GetNumberOfMatchedDocumentCountUsingDate`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetNumberOfMatchedDocumentCountUsingDate`(IN StartDate VARCHAR(50),IN EndDate VARCHAR(50))
BEGIN
SELECT DISTINCT COUNT(ID) AS NumberOfMatchedDocumentsCount,DATE_FORMAT(S.Date,'%Y-%m-%d') AS DATE 
FROM tbl_scanneddocumentresults S
WHERE (DATE_FORMAT(S.Date,'%Y-%m-%d') BETWEEN StartDate AND EndDate) AND MatchStatus='Matched' GROUP BY DATE_FORMAT(S.Date,'%Y-%m-%d');
END$$

DELIMITER ;