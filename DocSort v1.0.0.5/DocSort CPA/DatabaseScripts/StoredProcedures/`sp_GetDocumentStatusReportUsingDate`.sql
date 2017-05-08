DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_GetDocumentStatusReportUsingDate`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetDocumentStatusReportUsingDate`(IN StartDate VARCHAR(50),IN EndDate VARCHAR(50))
BEGIN
SELECT d.*,sd.MatchStatus,k.Keyword,k.SubSection FROM tbl_documentslist d LEFT JOIN
tbl_scanneddocumentresults sd ON sd.Document_ID=d.Document_ID
LEFT JOIN tbl_keywords k ON sd.Keyword_ID=k.Keyword_ID
WHERE DATE_FORMAT(d.Date,'%Y-%m-%d') BETWEEN StartDate AND EndDate;
END$$

DELIMITER ;