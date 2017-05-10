DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_GetDocumentCountReportUsingDate`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetDocumentCountReportUsingDate`(IN StartDate VARCHAR(50),IN EndDate VARCHAR(50))
BEGIN
SELECT COUNT(d.Document_ID) AS DocsCount,d.Date,K.Keyword,K.SubSection FROM tbl_documentslist d
LEFT JOIN tbl_scanneddocumentresults sd ON sd.Document_ID=d.Document_ID
LEFT JOIN tbl_Keywords K ON Sd.Keyword_ID=K.Keyword_ID
WHERE DATE_FORMAT(D.Date,'%Y-%m-%d') BETWEEN StartDate AND EndDate
GROUP BY DATE_FORMAT(D.Date,'%Y-%m-%d %l %p'),K.Keyword,K.SubSection;
END$$

DELIMITER ;