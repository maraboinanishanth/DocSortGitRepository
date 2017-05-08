DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_InsertKeywordDetails`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_InsertKeywordDetails`(IN keyword VARCHAR(50),IN subsection VARCHAR(50),IN startwith VARCHAR(50),IN endwith VARCHAR(50))
BEGIN
INSERT INTO tbl_keywords
(
Keyword,
SubSection,
StartWith,
EndWith
)
VALUES
(
keyword,
subsection,
startwith,
endwith
);
SELECT LAST_INSERT_ID() AS KeywordId;
END$$

DELIMITER ;