DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_InsertFileDetails`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_InsertFileDetails`(IN FolderId INT,IN FilecabinetId INT,IN Filename VARCHAR(250),IN Filepath LONGTEXT,IN Isdelete VARCHAR(5))
BEGIN
INSERT INTO tbl_files
(
Folder_ID,
FileCabinet_ID,
File_Name,
File_Path,
IsDelete
)
VALUES
(
FolderId,
FilecabinetId,
Filename,
Filepath,
Isdelete
);
SELECT LAST_INSERT_ID() FileId;
END$$

DELIMITER ;