DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_InsertLogHistoryDetails`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_InsertLogHistoryDetails`(IN logdatetme VARCHAR(50),IN loggeduser VARCHAR(50),IN description LONGTEXT,IN logintype VARCHAR(50),IN LogDate VARCHAR(50))
BEGIN
INSERT INTO tbl_LogHistory
(
log_datetme,
loggedIn_user,
Description,
TYPE,
Log_Date
)
VALUES
(
logdatetme,
loggeduser,
description,
logintype,
LogDate
);
END$$

DELIMITER ;