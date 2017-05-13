DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_ShowScannedDocuments`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_ShowScannedDocuments`()
BEGIN
SELECT d.*,f.*,sd.*,k.Keyword FROM tbl_documentslist d INNER JOIN
tbl_files f ON d.document_ID=f.File_ID LEFT JOIN
tbl_scanneddocumentresults sd ON d.Document_ID=sd.Document_ID
LEFT JOIN tbl_keywords k ON k.Keyword_ID=sd.Keyword_ID WHERE f.IsDelete='True';
END$$

DELIMITER ;