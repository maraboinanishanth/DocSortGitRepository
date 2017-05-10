DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_GetNumberOfDocumentCountDetailsUsingDate`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetNumberOfDocumentCountDetailsUsingDate`(IN StartDate VARCHAR(50),IN EndDate VARCHAR(50))
BEGIN
SELECT DISTINCT COUNT(D.Document_ID) AS NumberOfDocumentsCount,DATE_FORMAT(D.Date,'%Y-%m-%d') AS DATE
FROM tbl_documentslist D 
WHERE D.ProcessType='Automated' AND (DATE_FORMAT(D.Date,'%Y-%m-%d') BETWEEN StartDate AND EndDate) GROUP BY DATE_FORMAT(D.Date,'%Y-%m-%d');
SELECT DISTINCT COUNT(D.Document_ID) AS NumberOfManualDocumentsCount,DATE_FORMAT(D.Date,'%Y-%m-%d') AS DATE
FROM tbl_documentslist D 
WHERE D.ProcessType='Manual' AND (DATE_FORMAT(D.Date,'%Y-%m-%d') BETWEEN StartDate AND EndDate) GROUP BY DATE_FORMAT(D.Date,'%Y-%m-%d');
END$$

DELIMITER ;